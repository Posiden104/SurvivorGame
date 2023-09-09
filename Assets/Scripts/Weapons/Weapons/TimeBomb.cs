using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class TimeBomb : Weapon
    {

        private Transform spawnLoc;

        // Level Up Items
        private float radius = 1f;
        private float delay = 5f;

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


    }
}
