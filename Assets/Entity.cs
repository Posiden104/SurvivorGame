using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float HP { get; protected set; }
    public float MaxHP { get; protected set; }

    public virtual float Damage(float dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            HP = 0;
            //Kill();
        }
        return HP;
    }

    public virtual float Heal(float amt)
    {
        return HP += amt;
    }

    public virtual void SetMaxHp(float max)
    {
        MaxHP = max;
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
