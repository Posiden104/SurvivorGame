using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Sword : Weapon
    {
        // knockback

        public Sword(Player p) : base(p) { }

        public override void Activate()
        {
            var s = Object.Instantiate(GameManager.swordPrefab, player.transform);
            var rm = s.GetComponent<RotationalMovement>();
        }


    }
}
