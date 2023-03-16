using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons
{
    public class Sword : Weapon
    {
        // knockback

        public Sword(Player p) : base(p) { }

        public override void Activate()
        {
            base.Activate();
        }
    }
}
