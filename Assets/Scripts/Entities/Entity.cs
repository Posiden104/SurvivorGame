using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float HP;
    public float MaxHP;

    [SerializeField]
    private bool ShowDamageLog = false;

    private void Awake()
    {
        HP = MaxHP;
    }

    public virtual void Damage(float dmg)
    {
        HP -= dmg;
        if(ShowDamageLog) Debug.Log($"{gameObject.name} - damage! health: {HP}/{MaxHP}");
        if(HP <= 0)
        {
            HP = 0;
            Kill();
        }
    }

    public virtual void Heal(float amt)
    {
        HP += amt;
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
