using System.Text;
using System.Transactions;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Overwatch : Weapon, IHasLifetime
    {
        private GameObject crosshair;
        private CrosshairMovement cm;
        private WeaponLifetime lifetime;
        private Entity target;

        private bool lifetimeIsPaused;
        private float pauseTimer;
        private float pauseDuration = 2f;
        private readonly float crosshairMaxScale = 0.1f;
        private readonly float percentageMin = 0.25f;
        private readonly float percentageScale;

        private readonly float lifetimeMin = 0.1f;
        private readonly float lifetimeScale = 0.9f;


        public Overwatch(Player p) : base(p) 
        {
            damage = 10f;
            onCooldown = false;
            weaponCooldown = 5f;
            weaponName = "Overwatch";

            percentageScale = 1f - percentageMin;
            crosshair = Object.Instantiate(GameManager.Instance.CrosshairPrefab, player.transform);

            lifetime = crosshair.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);

            cm = crosshair.GetComponent<CrosshairMovement>();
            cm.RegisterOnTargetDeath(NoTarget);

            crosshair.SetActive(false);
        }

        public override void Setup()
        {
            base.Setup();
            crosshair.SetActive(true);
            OnLifetimeStart();
        }

        public override void Activate()
        {
            if (!lifetime.Activate())
            {
                Debug.LogError("overwatch fail");
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            if (weaponLevel == 1) return;
            lifetime.SetLifetime(Mathf.Max(lifetime.GetLifetime() * lifetimeScale, lifetimeMin));
            pauseDuration *= lifetimeScale;
        }

        public override string GetLevelUpStats()
        {
            var baseStr = base.GetLevelUpStats();
            var sb = new StringBuilder();

            sb.Append(baseStr);
            sb.Append($"Targeting Time: {lifetime.GetLifetime()}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Max(lifetime.GetLifetime() * lifetimeScale, lifetimeMin):n2}");
            sb.AppendLine();

            return sb.ToString();
        }

        private bool AcquireTarget()
        {
            var hasTarget = DistanceManager.Instance.TryGetClosestEnemyToPlayer(out var closest);
            var isEntity = closest.TryGetComponent(out target);
            return (hasTarget && isEntity);
        }

        public void OnLifetimeEnd()
        {
            target.Damage(damage);
            DidDamage(damage);
            onCooldown = true;
        }

        public void OnLifetimeStart()
        {
            if (!AcquireTarget())
            {
                Debug.LogError("overwatch target fail");
                NoTarget();
                return;
            }
            cm.targetTransform = target.transform;
            onCooldown = false;
        }

        public override void Update()
        {
            base.Update();
            if (lifetimeIsPaused)
            {
                pauseTimer += Time.deltaTime;
                if(pauseTimer >= pauseDuration)
                {
                    lifetime.Activate();
                }
                return;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            var p = (lifetime.GetRemainingLifetimePercentage() * percentageScale + percentageMin) * crosshairMaxScale;
            crosshair.transform.localScale = new Vector3(p, p, p);
        }

        private void NoTarget()
        {
            lifetime.DeactivateNoEndHook();
            Pause();

        }

        private void Pause()
        {
            pauseTimer = 0;
            lifetimeIsPaused = true;
        }
    }
}
