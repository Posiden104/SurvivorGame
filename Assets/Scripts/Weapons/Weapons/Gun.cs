using UnityEngine;
namespace Assets.Scripts.Weapons
{
    public class Gun : Weapon
    {
        public Gun(Player p) : base(p)
        {
            onCooldown = false;
            weaponName = "Gun";
        }

        public override void Activate()
        {
            var b = Object.Instantiate(GameManager.Instance.BulletPrefab, projectileSpawn);
            var bm = b.GetComponent<BulletMovement>();
            bm.normalizedDir = player.dirOrth;
            var dobj = b.GetComponent<DamageObject>();
            dobj.RegisterOnHit(DidDamage);
            onCooldown = true;
        }
    }
}
