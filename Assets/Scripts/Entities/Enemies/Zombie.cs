using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void Kill()
    {
        Instantiate(myPrefab, GameManager.Instance.zombieSpawner.transform);
        base.Kill();
    }
}
