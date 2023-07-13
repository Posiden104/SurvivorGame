using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Sword : Weapon, IHasLifetime
    {
        private GameObject sword;
        private RotationalMovement rm;
        private WeaponLifetime lifetime;

        private readonly float lifetimeMax = 0.1f;
        private readonly float lifetimeScale = 1.2f;

        public Sword(Player p) : base(p)
        {
            weaponName = "Sword";
            weaponCooldown = 3f;
        }

        public override void Setup() {
            sword = Object.Instantiate(GameManager.Instance.SwordPrefab, player.transform);
            rm = sword.GetComponent<RotationalMovement>();
            rm.SetRotationPoint(player.transform);
            lifetime = sword.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);

            var dobj = sword.GetComponent<DamageObject>();
            dobj.baseWeapon = this;
            dobj.RegisterOnHit(DidDamage);
        }

        public override void Activate()
        {
            if (weaponLevel == 0) return;
            lifetime.Activate();
        }

        public override void LevelUp()
        {
            base.LevelUp();
            if (weaponLevel == 1) return;
            lifetime.SetLifetime(Mathf.Min(lifetime.GetLifetime() * lifetimeScale, lifetimeMax));
        }

        public void OnLifetimeEnd()
        {
            onCooldown = true;
        }

        public void OnLifetimeStart()
        {
            onCooldown = false;
        }
    }
}
