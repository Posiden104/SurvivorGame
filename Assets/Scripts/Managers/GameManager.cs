using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int fixedUpdatesPerSec = 50;

    public Player player { get; private set; }

    // WEAPONS
    public GameObject bulletPrefab;
    public GameObject swordPrefab;

    // SPAWNERS
    public GameObject zombieSpawner;

    // UI
    public Timer timer;
    public GameObject gameOverUI;

    // PRIVATE

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PlayerDied()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
