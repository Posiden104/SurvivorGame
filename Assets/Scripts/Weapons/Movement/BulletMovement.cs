using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 normalizedDir;

    [SerializeField]
    private float speed;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.transform.position + (normalizedDir * speed));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
