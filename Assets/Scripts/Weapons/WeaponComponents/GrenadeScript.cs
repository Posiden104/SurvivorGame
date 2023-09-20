using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeScript : MonoBehaviour
{
    public AOEDamage aoeDamage;
    private WeaponLifetime lifetime;

    [SerializeField]
    private Image bombImage;
    [SerializeField]
    private Image rangeImage;

    public void OnLifetimeStart()
    {
    }

    public void TargetReached()
    {
        aoeDamage.DoDamage();
        Destroy(gameObject);
    }

    public void Setup(float travelTime, float radius, float damage, Vector3 target)
    {
        aoeDamage = GetComponent<AOEDamage>();
        aoeDamage.Setup(radius, damage);
        rangeImage.rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
        var tm = GetComponent<ThrownMovement>();
        tm.RegisterOnTargetReached(TargetReached);
        tm.target = target;
        tm.travelTime = travelTime;
    }
}
