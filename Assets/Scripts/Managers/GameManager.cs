using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int fixedUpdatesPerSec = 50;

    public Player player { get; private set; }
    public GameObject bulletPrefab;


    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

}
