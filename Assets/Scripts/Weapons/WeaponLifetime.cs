using Assets.Scripts.Weapons;
using UnityEngine;

public class WeaponLifetime : MonoBehaviour
{
    [SerializeField]
    protected float lifetime;
    protected float lifetimeTimer;

    protected IHasLifetime lifetimeManager;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    void FixedUpdate()
    {
        lifetimeTimer--;
        if (lifetimeTimer <= 0)
            Deactivate();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
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

    void ResetTimer()
    {
        lifetimeTimer = lifetime * GameManager.fixedUpdatesPerSec;
    }
}
