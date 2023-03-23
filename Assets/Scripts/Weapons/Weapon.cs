using Assets.Scripts.Weapons;
using System;
using UnityEngine;

public struct WeaponStats
{
    public string Name;
    public float Seconds;
    public float DamageDealt;
    public float DPS { get { return DamageDealt / Seconds; } }
}

public class Weapon : IWeapon
{
    public Transform projectileSpawn;
    public float damage = 1f;
    public float weaponCooldown = 1f;
    public int weaponLevel = 1;
    public string weaponName;

    protected float weaponCooldownTimer = 0;
    protected Player player;
    protected bool onCooldown;
    protected float startSeconds;
    protected float lifetimeDamage;

    public Weapon(Player p)
    {
        player = p;
        startSeconds = GameManager.Instance.timer.GetSeconds();
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
    
    public WeaponStats GetStats()
    {
        var sec = GameManager.Instance.timer.GetSeconds() - startSeconds;
        var ws = new WeaponStats
        {
            Seconds = sec,
            DamageDealt = lifetimeDamage,
            Name = weaponName
        };

        return ws;
    }

    public virtual void DidDamage(float dmg)
    {
        lifetimeDamage += dmg;
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
