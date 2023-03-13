using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float hp;
    protected float maxHp;

    public virtual float Damage(float dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            hp = 0;
            Kill();
        }
        Debug.Log($"Damage! {dmg}");
        return hp;
    }

    public virtual float Heal(float amt)
    {
        return hp += amt;
    }

    public virtual void SetMaxHp(float max)
    {
        maxHp = max;
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
