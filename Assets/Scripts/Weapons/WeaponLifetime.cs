using Assets.Scripts.Weapons;
using UnityEngine;

public class WeaponLifetime : MonoBehaviour
{
    [SerializeField]
    protected float timeActive;
    protected float lifetimeTimer;

    protected IHasLifetime lifetimeManager;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    void FixedUpdate()
    {
        if (lifetimeTimer > 0) 
        { 
            lifetimeTimer--;
            if (lifetimeTimer <= 0)
                Deactivate();
        }
    }

    public void Deactivate()
    {
        DeactivateNoEndHook();
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

    public void DeactivateNoEndHook()
    {
        gameObject.SetActive(false);
    }

    void ResetTimer()
    {
        lifetimeTimer = timeActive * GameManager.fixedUpdatesPerSec;
    }
}
