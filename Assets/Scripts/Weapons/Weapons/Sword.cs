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
            onCooldown = true;
            sword = Object.Instantiate(GameManager.Instance.SwordPrefab, player.transform);
            rm = sword.GetComponent<RotationalMovement>();
            rm.SetRotationPoint(player.transform);
            lifetime = sword.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);
            weaponCooldown = 3f;
            weaponName = "Sword";

            var dobj = sword.GetComponent<DamageObject>();
            dobj.RegisterOnHit(DidDamage);
        }

        public override void Activate()
        {
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
