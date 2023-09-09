using System.Text;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class TimeBomb : Weapon
    {

        private Transform spawnLoc;

        // Level Up Items
        private float radius = 1f;
        private float delay = 5f;

        private float delayScale = 1.2f;
        private float delayMin = 0.1f;
        private float radiusScale = 1.2f;
        private float radiusMax = 10f;

        public TimeBomb(Transform projSpawn) : base(projSpawn)
        {
            damage = 5;
            spawnLoc = projSpawn;
            weaponName = "Time Bomb";
            onCooldown = true;
            weaponCooldown = 5f;
        }

        public override void Activate()
        {
            var bomb = Object.Instantiate(GameManager.Instance.TimeBombPrefab, spawnLoc.position, new Quaternion());
            var bombScript = bomb.GetComponent<TimeBombScript>();
            bombScript.Setup(delay, radius, damage);

            onCooldown = true;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            if (weaponLevel == 1) return;
            delay = Mathf.Max(delay / delayScale, delayMin);
            radius = Mathf.Min(radius * radiusScale, radiusMax);
        }

        public override string GetLevelUpStats()
        {
            var baseStr = base.GetLevelUpStats();
            var sb = new StringBuilder();

            sb.Append(baseStr);
            sb.Append($"Fuse Time: {delay}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Max(delay / delayScale, delayMin):n2}");
            sb.Append($"Blast Radius: {radius}");
            sb.AppendLine(weaponLevel == 0 ? "" : $" => {Mathf.Min(radius * radiusScale, radiusMax):n2}");

            return sb.ToString();
        }


    }
}
