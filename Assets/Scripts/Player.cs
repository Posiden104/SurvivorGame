using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public List<Weapon> weapons;
    public Vector3 dirOrth;
    public Vector3 dirTrue;

    private Transform projectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new();
        projectileSpawn = transform.GetComponentsInChildren<Transform>().First(c => c.name == "ProjectileSpawn");
        dirOrth = Vector3.right;

        AddWeapon(new Gun());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        w.projectileSpawn = projectileSpawn;
    }
}
