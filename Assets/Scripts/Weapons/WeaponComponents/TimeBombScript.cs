using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBombScript : MonoBehaviour, IHasLifetime
{
    public AOEDamage aoeDamage;
    private WeaponLifetime lifetime;

    [SerializeField]
    private Image bombImage;
    [SerializeField]
    private Image rangeImage;
    [SerializeField]
    private Image timerImage;

    public void OnLifetimeStart()
    {
    }

    public void OnLifetimeEnd()
    {
        aoeDamage.DoDamage();
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
        rangeImage.rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
        timerImage.rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = lifetime.GetLifeUsedPercentage();
    }
}
