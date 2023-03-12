using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rigidBody;
    private float moveH;
    private float moveV;

    void Start()
    {
    }


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        Vector3 tv = new(moveH, moveV, 0);
        tv = speed * tv.normalized;
        rigidBody.MovePosition(rigidBody.transform.position + tv);
    }
}
