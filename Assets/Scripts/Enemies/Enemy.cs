using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    protected float damage;
    [SerializeField] 
    protected float damageCooldown;
    [SerializeField] 
    protected float dmgResetCooldown;

    protected Rigidbody2D rb;
    protected EnemyMovement em;
    protected bool canDamage = true;
    protected bool collidingWithPlayer = false;
    protected int timer = 0;
    protected Player player;
    protected float fixedUpdatesDmgCooldown;
    protected float fixedUpdatesDmgResetCooldown;


    // Start is called before the first frame update
    void Start()
    {
        MaxHP = HP;
        fixedUpdatesDmgCooldown = GameManager.fixedUpdatesPerSec * damageCooldown;
        fixedUpdatesDmgResetCooldown = GameManager.fixedUpdatesPerSec * dmgResetCooldown;
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

    void FixedUpdate()
    {
        if (!canDamage)
        {
            timer++;
            if(timer >= fixedUpdatesDmgCooldown)
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.TryGetComponent<BulletMovement>(out var bullet))
    //    {
    //        bullet.Hit(this);
    //    }
    //}

    private void OnCollisionExit2D(Collision2D other)
    {
        timer = (int) (fixedUpdatesDmgCooldown - fixedUpdatesDmgResetCooldown);
        collidingWithPlayer = false;
    }
}
