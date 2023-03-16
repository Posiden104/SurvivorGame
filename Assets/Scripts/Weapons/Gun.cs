using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : Weapon
{
    public Gun(Player p) : base(p)
    {
    }

    public override void Activate()
    {
        var b = Object.Instantiate(GameManager.bulletPrefab, projectileSpawn);
        var bm = b.GetComponent<BulletMovement>();
        bm.normalizedDir = player.dirOrth;
    }
}
