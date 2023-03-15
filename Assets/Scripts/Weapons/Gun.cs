using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : Weapon
{
    private Player player;

    // Start is called before the first frame update
    public Gun(Player _player) : base()
    {
        player = _player;
    }

    protected override void Activate()
    {
        var b = GameObject.Instantiate(GameManager.Instance.bulletPrefab, projectileSpawn);
        var bm = b.GetComponent<BulletMovement>();
        bm.normalizedDir = player.dirOrth;
    }
}
