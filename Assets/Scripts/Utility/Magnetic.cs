using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public bool isMagnitized = false;
    private float speed = 10f;

    private Transform target;

    public void Magnetize(Transform target)
    {
        this.target = target;
        isMagnitized = true;
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

        } else if(GetComponent<DistanceToPlayer>().GetDistance() < GameManager.Instance.player.magnetRange)
        {
            Magnetize(GameManager.Instance.player.transform);
        }
    }
}
