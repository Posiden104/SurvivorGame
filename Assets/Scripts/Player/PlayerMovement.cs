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

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 dir = new(moveH, moveV, 0);
        dir = speed * dir.normalized;
        player.SetDir(dir);
        rigidBody.MovePosition(rigidBody.transform.position + dir);
    }

    //void SetPlayerDirs(Vector3 dir)
    //{
    //    Debug.Log(dir);
    //    if (dir != Vector3.zero) player.dirTrue = dir;

    //    if (moveV < 0)
    //    {
    //        player.dirOrth = Vector3.up;
    //    }
    //    else if (moveV > 0)
    //    {
    //        player.dirOrth = Vector3.down;
    //    }

    //    if (moveH > 0)
    //    {
    //        player.dirOrth = Vector3.right;
    //    }
    //    else if (moveH < 0)
    //    {
    //        player.dirOrth = Vector3.left;
    //    }
    //    Debug.Log("player dir" + player.dirOrth);
    //}
}
