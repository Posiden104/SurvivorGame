using System;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }


    public bool TryGetClosestObjectToPlayer(out GameObject closest)
    {
        var closestDistance = float.MaxValue;
        closest = null;
        var targets = FindObjectsOfType<DistanceToPlayer>();
        foreach (var target in targets)
        {
            var distance = target.GetDistance();
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = target.gameObject;
            }
        }
        return closest != null;
    }

    public bool TryGetClosestEnemyToPlayer(out GameObject closest)
    {
        var closestDistance = float.MaxValue;
        closest = null;
        var targets = FindObjectsOfType<DistanceToPlayer>();
        foreach (var target in targets)
        {
            var distance = target.GetDistance();
            if (distance < closestDistance && target.CompareTag("Enemy"))
            {
                closestDistance = distance;
                closest = target.gameObject;
            }
        }
        return closest != null;
    }

    public GameObject GetObjectsInRange(float range)
    {
        throw new NotImplementedException();
    }
}
