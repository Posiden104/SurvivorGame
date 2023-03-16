using Assets.Scripts.Weapons;
using System;
using UnityEngine;

public class Weapon : IWeapon
{
    public Transform projectileSpawn;
    public float damage = 1f;
    public float activateFrequencyInSec = 1f;
    public int Level = 1;

    protected float timer = 0;
    protected float fixedUpdatesPerActivation;
    protected Player player;

    public Weapon(Player p)
    {
        player = p;
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

    public virtual void Activate()
    {
        throw new NotImplementedException();
    }

    public virtual void LevelUp()
    {
        throw new NotImplementedException();
    }

    public virtual void Update()
    {
        throw new NotImplementedException();
    }
}
