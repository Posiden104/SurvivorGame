using Assets.Scripts.Weapons;
using UnityEngine;

public class WeaponLifetime : MonoBehaviour
{
    [SerializeField]
    protected float timeActive;
    protected float lifetimeTimer;
    public bool deactivateOnLifeEnd = true;

    protected IHasLifetime lifetimeManager;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (lifetimeTimer > 0) 
        { 
            lifetimeTimer -= Time.deltaTime;
            if (lifetimeTimer <= 0)
                Deactivate();
        }
    }

    public void Deactivate()
    {
        if(deactivateOnLifeEnd) DeactivateNoEndHook();
        lifetimeManager.OnLifetimeEnd();
    }

    public bool Activate()
    {
        if (gameObject.activeSelf) return false;
        ResetTimer();
        gameObject.SetActive(true);
        lifetimeManager.OnLifetimeStart();
        return true;
    }

    public void SetWeapon(IHasLifetime w)
    {
        lifetimeManager = w;
    }

    public void SetLifetime(float time)
    {
        timeActive = time;
    }

    public float GetLifetime()
    {
        return timeActive;
    }

    public float GetCurrentTimer()
    {
        return lifetimeTimer;
    }

    public float GetLifeLeftPercentage()
    {
        return lifetimeTimer / timeActive;
    }

    public float GetLifeUsedPercentage()
    {
        return 1 - GetLifeLeftPercentage();
    }

    public void DeactivateNoEndHook()
    {
        gameObject.SetActive(false);
    }

    void ResetTimer()
    {
        lifetimeTimer = timeActive;
    }

    public float GetRemainingLifetimePercentage()
    {
        return lifetimeTimer / timeActive;
    }
}
