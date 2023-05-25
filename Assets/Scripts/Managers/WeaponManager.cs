using Assets.Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    public readonly static int weaponCount = Enum.GetNames(typeof(WeaponId)).Length;

    public Weapon[] weapons;
    private Transform projectileSpawn;

    // WEAPONS
    private Gun gun;
    private Sword sword;
    private Overwatch overwatch;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    void Start()
    {
        weapons = new Weapon[weaponCount];
        var p = GameManager.Instance.player;
        projectileSpawn = p.GetComponentsInChildren<Transform>().First(c => c.name == "ProjectileSpawn");

        gun = new Gun(p, projectileSpawn);
        sword = new Sword(p);
        overwatch = new Overwatch(p);

        weapons[(int) WeaponId.GUN] = gun;
        weapons[(int) WeaponId.SWORD] = sword;
        weapons[(int) WeaponId.OVERWATCH] = overwatch;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var weapon in weapons)
        {
            if(weapon != null)
                weapon.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var weapon in weapons)
        {
            if(weapon != null)
                weapon.FixedUpdate();
        }
    }

    public List<WeaponStats> GetWeaponStats()
    {
        List<WeaponStats> weaponStats = new();
        foreach (Weapon weapon in weapons)
        {
            if (weapon.weaponLevel == 0) continue;
            weaponStats.Add(weapon.GetStats());
            //Debug.Log($"{ws.Name} - Total Damage: {ws.DamageDealt} | DPS: {ws.DPS})");
        }
        return weaponStats;
    }

    public void WeaponUpgrade(int slot)
    {
        //Debug.Log($"Clicked button upgrade for weapon {weapons[slot].weaponName}");
        weapons[slot].LevelUp();
    }

    public string GetWeaponName(int slot)
    {
        return weapons[slot].weaponName;
    }
}
