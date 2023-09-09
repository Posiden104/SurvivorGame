using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombScript : MonoBehaviour, IHasLifetime
{
    private AOEDamage aoeDamage;
    private WeaponLifetime lifetime;

    public void OnLifetimeStart()
    {
    }

    public void OnLifetimeEnd()
    {
        aoeDamage.DoDamage();
        Debug.Log("now destroy this go");
        Destroy(gameObject);
    }

    public void Setup(float delay, float radius, float damage)
    {
        aoeDamage = GetComponent<AOEDamage>();
        aoeDamage.Setup(radius, damage);

        lifetime = GetComponent<WeaponLifetime>();
        lifetime.SetLifetime(delay);
        lifetime.SetWeapon(this);
        lifetime.Activate();
        lifetime.deactivateOnLifeEnd = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
