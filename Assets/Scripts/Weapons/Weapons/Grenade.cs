using System.Text;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Grenade : Weapon
    {

        private float throwDistance = 10f;

        // Level Up Items
        private float radius = 0.6f;
        private float travelTime = 2f;

        private float travelTimeScale = 1.2f;
        private float travelTimeMin = 0.1f;
        private float radiusScale = 1.2f;
        private float radiusMax = 10f;

        public Grenade(Transform projSpawn) : base(projSpawn)
        {
            damage = 5;
            projectileSpawn = projSpawn;
            weaponName = "Grenade";
            onCooldown = true;
            weaponCooldown = 5f;
        }

        public override void Activate()
        {
            var grenade = Object.Instantiate(GameManager.Instance.GrenadePrefab, projectileSpawn.position, new Quaternion(), GameManager.Instance.ProjectileContainer.transform);
            var grenadeScript = grenade.GetComponent<GrenadeScript>();
            var target = GameManager.Instance.GetPlayer().transform.position + (GameManager.Instance.GetPlayer().dirTrueNormalized * throwDistance);
            grenadeScript.Setup(travelTime, radius, damage, target);
            grenadeScript.aoeDamage.RegisterOnHitAction(DidDamage);

            onCooldown = true;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            if (weaponLevel == 1) return;
            travelTime = Mathf.Max(travelTime / travelTimeScale, travelTimeMin);
            radius = Mathf.Min(radius * radiusScale, radiusMax);
        }

        public override string GetLevelUpStats()
        {
            var baseStr = base.GetLevelUpStats();
            var sb = new StringBuilder();

            sb.Append(baseStr);
            sb.Append($"Travel Time: {travelTime}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Max(travelTime / travelTimeScale, travelTimeMin):n2}");
            sb.Append($"Blast Radius: {radius}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Min(radius * radiusScale, radiusMax):n2}");

            return sb.ToString();
        }


    }
}
