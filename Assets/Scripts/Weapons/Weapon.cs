using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform projectileSpawn;
    public float damage = 1f;
    public float activateFrequency = 1f;

    private float timer;

    private void Awake()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        timer++;
        if (timer >= activateFrequency)
        {
            Activate();
            timer = 0;
        }
    }

    protected virtual void Activate()
    {

    }
}
