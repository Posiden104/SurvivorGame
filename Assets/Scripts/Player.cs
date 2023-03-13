using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public List<Weapon> weapons;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        weapons = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
