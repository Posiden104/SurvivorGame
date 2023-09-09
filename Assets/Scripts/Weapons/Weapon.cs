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
    protected bool onCooldown;
    protected float startSeconds;
    protected float lifetimeDamage;

    protected float dmgScale = 0.2f;
    protected float cooldownMin = 0.1f;
    protected float cooldownScale = 0.005f;

    public Weapon(Transform projSpawn)
    {
        onCooldown = true;
        projectileSpawn = projSpawn;
    }
    public Weapon()
    {
        onCooldown = true;
    }

    public virtual void Update()
    {
        if (!onCooldown) return;
        if (weaponLevel == 0) return;
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
        //Debug.Log($"level up {weaponName} to level {weaponLevel + 1}");
        weaponLevel++;
        if (weaponLevel == 1)
        {
            startSeconds = GameManager.Instance.timer.GetSeconds();
            Setup();
            return;
        }
        damage += (weaponLevel + 1) * dmgScale;
        weaponCooldown = Mathf.Max(cooldownMin, weaponCooldown -= (weaponLevel + 1) * cooldownScale);
    }

    public virtual string GetLevelUpStats()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Lv: {weaponLevel} => {weaponLevel + 1}");
        sb.AppendLine();
        sb.Append($"Damage: {damage:n2}");
        sb.AppendLine(weaponLevel == 0 ? "": $" => {(damage + ((weaponLevel + 1) * dmgScale)):n2}");
        sb.Append($"Cooldown: {weaponCooldown:n2}");
        sb.AppendLine(weaponLevel == 0 ? "" : $" => {(Mathf.Max(cooldownMin, weaponCooldown - ((weaponLevel + 1) * cooldownScale))):n2}");

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
