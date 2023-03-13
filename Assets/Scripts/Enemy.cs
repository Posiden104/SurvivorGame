using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    private float damage;
    [SerializeField] 
    private float damageFrequencyInSec;
    [SerializeField] 
    private float onColExitDamageDelayInSec;

    private Rigidbody2D rb;
    private EnemyMovement em;
    private bool canDamage = true;
    private bool collidingWithPlayer = false;
    private int timer = 0;
    private int fixedUpdatesPerSec = 50;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        em = GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collidingWithPlayer && canDamage)
        {
            canDamage = false;
            player.Damage(damage);
        }
    }

    // 50x/sec
    void FixedUpdate()
    {
        if (!canDamage)
        {
            timer++;
            if(timer >= damageFrequencyInSec * fixedUpdatesPerSec)
            {
                canDamage = true;
                timer = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            collidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        timer = fixedUpdatesPerSec - (int)(onColExitDamageDelayInSec * fixedUpdatesPerSec);
        collidingWithPlayer = false;
    }
}
