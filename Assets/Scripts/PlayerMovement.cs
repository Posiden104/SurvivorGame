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
    private Player player;
    private Vector3 dir;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        dir = new(moveH, moveV, 0);
        dir = speed * dir.normalized;
        rigidBody.MovePosition(rigidBody.transform.position + dir);
    }

    void SetPlayerDirs()
    {
        if (dir != Vector3.zero) player.dirTrue = dir;

        if (moveV < 0)
        {
            player.dirOrth = Vector3.up;
        }
        else if (moveV > 0)
        {
            player.dirOrth = Vector3.down;
        }

        if (moveH > 0)
        {
            player.dirOrth = Vector3.right;
        }
        else if (moveH < 0)
        {
            player.dirOrth = Vector3.left;
        }
    }
}
