using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool canMove = true;

    [SerializeField]
    private float speed;
    private Rigidbody2D rigidBody;
    private Vector3 targetPos;
    private Rigidbody2D player;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = player.transform.position;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            dir = (targetPos - transform.position).normalized;
            dir *= speed;
            rigidBody.MovePosition(rigidBody.transform.position + dir);
        }
    }
}
