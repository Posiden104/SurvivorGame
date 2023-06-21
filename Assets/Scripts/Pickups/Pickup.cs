using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class PickupBase : MonoBehaviour, IPickup
    {

        public virtual void OnPlayerPickup()
        {
            Destroy(gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerPickupSensor"))
            {
                OnPlayerPickup();
            }
        }
    }
}