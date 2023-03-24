using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int fixedUpdatesPerSec = 50;

    public Player player { get; private set; }

    // WEAPONS
    public GameObject BulletPrefab;
    public GameObject SwordPrefab;

    // ENEMIES
    public GameObject ZombiePrefab;
    public GameObject ZombieSlowPrefab;

    // LOOT
    public GameObject LootContainer;
    public GameObject ScrapPrefab;

    // SPAWNERS
    public GameObject ZombieSpawner;

    // UI
    public Timer timer;
    public GameObject gameEndUI;
    public GameEndScreen gameEndScreenScript;
    public GameObject gameOverUI;
    public GameObject gameStartUI;
    public GameObject levelUpScreen;

    // PRIVATE

    void Awake()
    {
        Instance = this;
        Time.timeScale = 0;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Begin()
    {
        Time.timeScale = 1;
        gameStartUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PlayerDied()
    {
        gameEndScreenScript.DisplayStats(player.GetWeaponStats());
        gameEndUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameEndUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
