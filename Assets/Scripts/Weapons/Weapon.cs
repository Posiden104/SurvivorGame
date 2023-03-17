using Assets.Scripts.Weapons;
using System;
using UnityEngine;

public class Weapon : IWeapon
{
    public Transform projectileSpawn;
    public float damage = 1f;
    public float weaponCooldown = 1f;
    public int weaponLevel = 1;

    protected float weaponCooldownTimer = 0;
    protected Player player;
    protected bool onCooldown;

    public Weapon(Player p)
    {
        player = p;
    }

    public virtual void FixedUpdate()
    {
        if (!onCooldown) return;
        weaponCooldownTimer++;
        if (weaponCooldownTimer >= weaponCooldown * GameManager.fixedUpdatesPerSec)
        {
            onCooldown = false;
            weaponCooldownTimer = 0;
            Activate();
        }
    }

    public virtual void Activate()
    {
    }

    public virtual void LevelUp()
    {
        throw new NotImplementedException();
    }

    public virtual void Update()
    {
    }
}
