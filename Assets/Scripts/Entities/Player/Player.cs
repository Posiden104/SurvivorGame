using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public Vector3 dirOrth { get; private set; }
    public Vector3 dirTrue { get; private set; }

    private List<IWeapon> weapons;
    private Transform projectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new();
        projectileSpawn = transform.GetComponentsInChildren<Transform>().First(c => c.name == "ProjectileSpawn");
        dirOrth = Vector3.right;
        dirTrue = Vector3.right;

        //AddWeapon(new Gun(this));
        AddWeapon(new Sword(this));
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
        foreach(var weapon in weapons)
        {
            weapon.FixedUpdate();
        }
    }

    void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        w.projectileSpawn = projectileSpawn;
    }

    public void SetDir(Vector3 dir)
    {
        if (dir != Vector3.zero) dirTrue = dir;

        if (dir.y > 0)
        {
            dirOrth = Vector3.up;
        }
        else if (dir.y < 0)
        {
            dirOrth = Vector3.down;
        }

        if (dir.x > 0)
        {
            dirOrth = Vector3.right;
        }
        else if (dir.x < 0)
        {
            dirOrth = Vector3.left;
        }
    }
}
