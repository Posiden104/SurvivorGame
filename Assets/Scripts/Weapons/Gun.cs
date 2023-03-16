using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : Weapon
{
    public Gun(Player p) : base(p)
    {
    }

    public override void Activate()
    {
        var b = GameObject.Instantiate(GameManager.Instance.bulletPrefab, projectileSpawn);
        var bm = b.GetComponent<BulletMovement>();
        bm.normalizedDir = player.dirOrth;
    }
}
