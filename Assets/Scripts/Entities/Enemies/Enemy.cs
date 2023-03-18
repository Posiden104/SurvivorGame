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


    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
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
            if(timer >= GameManager.fixedUpdatesPerSec * damageCooldown)
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
        timer = (int) (GameManager.fixedUpdatesPerSec * damageCooldown - GameManager.fixedUpdatesPerSec * dmgResetCooldown);
        collidingWithPlayer = false;
    }
}
