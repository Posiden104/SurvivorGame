using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
    }

    protected override void Activate()
    {
        var b = Instantiate(GameManager.Instance.bulletPrefab, projectileSpawn);
        var bm = b.GetComponent<BulletMovement>();
        bm.normalizedDir = player.dirOrth;
    }
}
