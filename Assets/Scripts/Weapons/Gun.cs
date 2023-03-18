using UnityEngine;
namespace Assets.Scripts.Weapons
{
    public class Gun : Weapon
    {
        public Gun(Player p) : base(p)
        {
            onCooldown = true;
        }

        public override void Activate()
        {
            var b = Object.Instantiate(GameManager.Instance.bulletPrefab, projectileSpawn);
            var bm = b.GetComponent<BulletMovement>();
            bm.normalizedDir = player.dirOrth;
            onCooldown = true;
        }
    }
}
