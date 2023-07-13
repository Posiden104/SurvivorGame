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
    [SerializeField]
    protected GameObject myPrefab;
    [SerializeField]
    protected float lootDropProbability;
    [SerializeField]
    protected int lootValue;

    protected Rigidbody2D rb;
    protected EnemyMovement em;
    protected bool canDamage = true;
    protected bool collidingWithPlayer = false;
    protected int timer = 0;
    protected Player player;

    private void Start()
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

    public override void Kill()
    {
        var rnd = Random.Range(0, 100);
        if(rnd <= lootDropProbability)
        {
            var l = Instantiate(GameManager.Instance.ScrapPrefab, transform.position, transform.rotation, GameManager.Instance.LootContainer.transform);
            l.GetComponent<LootScript>().Value = lootValue;
        }
        GameManager.Instance.player.TotalKills++;
        base.Kill();
    }
}
