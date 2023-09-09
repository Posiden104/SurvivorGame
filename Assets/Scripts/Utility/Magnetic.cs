using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public bool isMagnitized = false;
    public bool isSuperMagnetic = true;
    private float speed = 10f;

    private Transform target;

    private void Start()
    {
        target = GameManager.Instance.GetPlayer().transform;
    }

    public void Magnetize()
    {
        isMagnitized = true;
    }

    public void SuperMagnetize()
    {
        if (isSuperMagnetic)
        {
            Magnetize();
        }
    }

    public void DeMagnetize()
    {
        isMagnitized = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnitized)
        {
            var heading = (target.position - transform.position).normalized;
            transform.position += heading * speed * Time.deltaTime;

        } else if(GetComponent<DistanceToPlayer>().GetDistance() < GameManager.Instance.GetPlayer().magnetRange)
        {
            Magnetize();
        }
    }
}
