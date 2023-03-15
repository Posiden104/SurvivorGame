using UnityEngine;

public class Weapon
{
    public Transform projectileSpawn;
    public float damage = 1f;
    public float activateFrequencyInSec = 1f;
    public int Level = 1;

    private float timer = 0;
    private float fixedUpdatesPerActivation;

    public Weapon()
    {
        fixedUpdatesPerActivation = activateFrequencyInSec * GameManager.fixedUpdatesPerSec;
    }

    public virtual void FixedUpdate()
    {
        timer++;
        if (timer >= fixedUpdatesPerActivation)
        {
            Activate();
            timer = 0;
        }
    }

    protected virtual void Activate()
    {

    }

    public virtual void LevelUp()
    {

    }
}
