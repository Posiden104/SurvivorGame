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
        private float PauseDuration = 2f;
        private float crosshairMaxScale = 0.1f;
        private float percentageMin = 0.25f;
        private float percentageScale;


        public Overwatch(Player p) : base(p) 
        {
            damage = 10f;
            onCooldown = false;
            weaponCooldown = 5f;
            weaponName = "Overwatch";

            percentageScale = 1f - percentageMin;
        }

        public override void Setup()
        {
            Debug.Log("overwatch setup");
            base.Setup();
            crosshair = Object.Instantiate(GameManager.Instance.CrosshairPrefab, player.transform);

            lifetime = crosshair.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);

            cm = crosshair.GetComponent<CrosshairMovement>();
            cm.RegisterOnTargetDeath(NoTarget);
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
            damage *= dmgScale;
        }

        private bool AcquireTarget()
        {
            var hasTarget = DistanceManager.Instance.TryGetClosestObjectToPlayer(out var closest);
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
            if (lifetimeIsPaused)
            {
                pauseTimer += Time.deltaTime;
                if(pauseTimer >= PauseDuration)
                {
                    lifetime.Activate();
                }
            }
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
