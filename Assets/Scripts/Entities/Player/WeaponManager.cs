using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static int GunSlot = 0;
    public static int SwordSlot = 1;

    private Weapon[] weapons;
    private Transform projectileSpawn;

    // WEAPONS
    private Gun gun;
    private Sword sword;

    void Start()
    {
        weapons = new Weapon[2];
        projectileSpawn = transform.GetComponentsInChildren<Transform>().First(c => c.name == "ProjectileSpawn");
        var p = gameObject.GetComponent<Player>();

        gun = new Gun(p, projectileSpawn);
        sword = new Sword(p);
        weapons[GunSlot] = gun;
        weapons[SwordSlot] = sword;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var weapon in weapons)
        {
            weapon.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var weapon in weapons)
        {
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
}
