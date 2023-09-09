using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Weapons
{ 
    public class AOEDamage : MonoBehaviour
    {
        public CircleCollider2D damageCollider;

        public float damage;
        public float radius;
        public Action<float> onHitActions;

        private List<Enemy> enemiesInRange;
        private bool doingDamage = false;

        private void Start()
        {
            damageCollider = GetComponent<CircleCollider2D>();
            enemiesInRange = new();
        }

        public void Setup(float radius, float damage)
        {
            this.radius = radius;
            damageCollider.radius = radius;
            this.damage = damage;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (doingDamage) return;
            if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                if (!enemiesInRange.Contains(enemy))
                {
                    enemiesInRange.Add(enemy);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (doingDamage) return;
            if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }

        public void DoDamage()
        {
            doingDamage = true;
            foreach (var enemy in enemiesInRange)
            {
                enemy.Damage(damage);
                onHitActions?.Invoke(damage);
            }
            doingDamage = false;
        }

        public void RegisterOnHitAction(Action<float> onHitAction)
        {
            onHitActions += onHitAction;
        }

        public void UnRegisterOnHitAction(Action<float> onHitAction)
        {
            onHitActions -= onHitAction;
        }
    }
}
