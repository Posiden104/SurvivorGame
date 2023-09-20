using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class MagnetPickup : PickupBase
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnPlayerPickup()
        {
            FindObjectsOfType<Magnetic>().ToList().ForEach(o => o.SuperMagnetize());
            base.OnPlayerPickup();
        }

    }
}