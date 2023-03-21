using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons
{
    public interface IWeapon
    {
        void Update();
        void Activate();
        void LevelUp();
        void FixedUpdate();
        void DidDamage(float dmg);
        WeaponStats GetStats();
    }
}
