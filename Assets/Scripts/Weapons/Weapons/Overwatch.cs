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
        private float PauseDuration = 5f;

        public Overwatch(Player p) : base(p) 
        {
            damage = 10f;
            onCooldown = false;
            weaponCooldown = 5f;
            weaponName = "Overwatch";

            crosshair = Object.Instantiate(GameManager.Instance.CrosshairPrefab, player.transform);

            lifetime = crosshair.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);

            cm = crosshair.GetComponent<CrosshairMovement>();
            cm.RegisterOnTargetDeath(NoTarget);
            OnLifetimeStart();
        }

        public override void Activate()
        {
            lifetime.Activate();
        }

        public override void LevelUp()
        {
            base.LevelUp();
            damage *= dmgScale;
        }

        public void OnLifetimeEnd()
        {
            target.Damage(damage);
            DidDamage(damage);
            onCooldown = true;
        }

        public void OnLifetimeStart()
        {
            if(!DistanceManager.Instance.TryGetClosestObjectToPlayer(out var closest) || !closest.TryGetComponent(out target))
            {
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
