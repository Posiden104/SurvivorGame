using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    public readonly static int weaponCount = 3;
    public readonly static int GunSlot = 0;
    public readonly static int SwordSlot = 1;
    public readonly static int OverwatchSlot = 2;

    private Weapon[] weapons;
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
        projectileSpawn = p.transform.GetComponentsInChildren<Transform>().First(c => c.name == "ProjectileSpawn");

        gun = new Gun(p, projectileSpawn);
        sword = new Sword(p);
        overwatch = new Overwatch(p);

        weapons[GunSlot] = gun;
        weapons[SwordSlot] = sword;
        weapons[OverwatchSlot] = overwatch;
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
