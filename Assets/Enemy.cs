using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    private float damage;
    private Rigidbody2D rb;
    private EnemyMovement em;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemy start");
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        em = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(damage);
        }
    }

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    Debug.Log("Exit collision");
    //    em.canMove = true;
    //}
}
