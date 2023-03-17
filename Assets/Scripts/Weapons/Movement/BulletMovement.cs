using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 normalizedDir;

    [SerializeField]
    private float speed;
    //[SerializeField]
    //private float damage;
    //[SerializeField]
    //private int hitsToDie = 1;

    private Rigidbody2D rb2d;

    //public void Hit(Enemy enemy)
    //{
    //    enemy.Damage(damage);
    //    hitsToDie--;
    //    if(hitsToDie == 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
    //    {
    //        Hit(enemy);
    //    }
    //}
}
