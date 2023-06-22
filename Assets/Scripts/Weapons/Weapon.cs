using Assets.Scripts.Weapons;
using System;
using System.Text;
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
    public int weaponLevel = 0;
    public string weaponName;

    protected float weaponCooldownTimer = 0;
    protected Player player;
    protected bool onCooldown;
    protected float startSeconds;
    protected float lifetimeDamage;

    protected float dmgScale = 1.2f;
    protected float cooldownMin = 0.1f;
    protected float cooldownScale = 0.9f;

    public Weapon(Player p, Transform projSpawn)
    {
        player = p;
        onCooldown = true;
        projectileSpawn = projSpawn;
    }
    public Weapon(Player p)
    {
        player = p;
        onCooldown = true;
    }

    public virtual void Update()
    {
        if (!onCooldown) return;
        weaponCooldownTimer += Time.deltaTime;
        if (weaponCooldownTimer >= weaponCooldown)
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

    public virtual void LevelUp()
    {
        Debug.Log($"level up {weaponName} to level {weaponLevel + 1}");
        weaponLevel++;
        if (weaponLevel == 1)
        {
            startSeconds = GameManager.Instance.timer.GetSeconds();
            Setup();
            return;
        }
        damage *= dmgScale;
        weaponCooldown = Mathf.Max(cooldownMin, weaponCooldown *= cooldownScale);
    }

    public string GetLevelUpStats()
    {
        var sb = new StringBuilder();

        sb.AppendLine(weaponName);
        sb.Append("Damage ");
        sb.Append(damage);
        sb.Append(" -> ");
        sb.Append(damage * dmgScale);
        sb.AppendLine();

        return sb.ToString();
    }

    #region empty base methods
    public virtual void Activate()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Setup()
    {
    }
    #endregion
}
