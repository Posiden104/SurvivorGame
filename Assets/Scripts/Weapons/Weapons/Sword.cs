using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Sword : Weapon, IHasLifetime
    {
        // knockback

        private GameObject sword;
        private RotationalMovement rm;
        private WeaponLifetime lifetime;

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
            dobj.RegisterOnHit(DidDamage);
        }

        public override void Activate()
        {
            if (weaponLevel == 0) return;
            lifetime.Activate();
        }

        public void OnLifetimeEnd()
        {
            onCooldown = true;
        }

        public void OnLifetimeStart()
        {
            onCooldown = false;
        }

        public override void Update()
        {

        }
    }
}
