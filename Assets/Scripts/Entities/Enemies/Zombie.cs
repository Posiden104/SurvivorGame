using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    public override void Kill()
    {
        GameObject.Instantiate(this, GameManager.Instance.zombieSpawner.transform);
        base.Kill();
    }
}
