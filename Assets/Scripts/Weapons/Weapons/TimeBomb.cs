using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Weapons
{
    public class TimeBomb : Weapon, IHasLifetime
    {
        public TimeBomb() : base()
        {

        }

        public void OnLifetimeEnd()
        {
            throw new NotImplementedException();
        }

        public void OnLifetimeStart()
        {
            throw new NotImplementedException();
        }
    }
}
