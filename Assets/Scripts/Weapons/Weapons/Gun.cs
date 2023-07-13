using UnityEditor;
using UnityEngine;
namespace Assets.Scripts.Weapons
{
    public class Gun : Weapon
    {

        public Gun(Player p, Transform projSpawn) : base(p, projSpawn)
        {
            weaponName = "Gun";
        }

        public override void Activate()
        {
            if (weaponLevel == 0) return;

            var b = Object.Instantiate(GameManager.Instance.BulletPrefab, projectileSpawn);
            var bm = b.GetComponent<BulletMovement>();
            bm.normalizedDir = player.dirOrth;
            var dobj = b.GetComponent<DamageObject>();
            dobj.baseWeapon = this;
            dobj.RegisterOnHit(DidDamage);
            onCooldown = true;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            if (weaponLevel == 1) return;
        }
    }
}
