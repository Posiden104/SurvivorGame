using System.Text;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Sword : Weapon, IHasLifetime
    {
        private GameObject sword;
        private RotationalMovement rm;
        private WeaponLifetime lifetime;

        private readonly float lifetimeMax = 30f;
        private readonly float lifetimeScale = 1.2f;

        public Sword(Player p) : base(p)
        {
            weaponName = "Sword";
            weaponCooldown = 3f;

            sword = Object.Instantiate(GameManager.Instance.SwordPrefab, player.transform);
            rm = sword.GetComponent<RotationalMovement>();
            rm.SetRotationPoint(player.transform);
            lifetime = sword.GetComponent<WeaponLifetime>();
            lifetime.SetWeapon(this);
            sword.SetActive(false);
        }

        public override void Setup() {
            sword.SetActive(true);

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
        public override string GetLevelUpStats()
        {
            var baseStr = base.GetLevelUpStats();
            var sb = new StringBuilder();

            sb.Append(baseStr);
            sb.Append($"Active Time: {lifetime.GetLifetime()}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Min(lifetime.GetLifetime() * lifetimeScale, lifetimeMax):n2}");
            sb.AppendLine();

            return sb.ToString();
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
