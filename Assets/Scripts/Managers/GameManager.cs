using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int fixedUpdatesPerSec = 50;

    [SerializeField]
    private Player player;

    // WEAPONS
    public GameObject BulletPrefab;
    public GameObject SwordPrefab;
    public GameObject CrosshairPrefab;
    public GameObject TimeBombPrefab;
    public GameObject GrenadePrefab;

    // ENEMIES
    public GameObject ZombiePrefab;
    public GameObject ZombieSlowPrefab;

    // LOOT
    public GameObject ScrapPrefab;

    // CONTAINERS
    public GameObject LootContainer;
    public GameObject EnemyContainer;
    public GameObject ProjectileContainer;

    // SPAWNERS
    public GameObject ZombieSpawner;

    // UI Objects
    public GameObject gameStartUI;
    public GameObject levelUpScreen;
    public GameObject gameOverUI;
    public GameObject endGameStatsScreen;

    // UI Scripts
    public Timer timer;
    public GameEndScreen gameEndScreenScript;
    public LevelUpScreen levelUpScreenScript;


    // PRIVATE

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        Time.timeScale = 0;
        SetupStartingUI();
    }

    private void SetupStartingUI()
    {
        gameStartUI.SetActive(true);
        levelUpScreen.SetActive(false);
        endGameStatsScreen.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private void Start()
    {
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
        gameEndScreenScript.DisplayStats(WeaponManager.Instance.GetWeaponStats());
        endGameStatsScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        endGameStatsScreen.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public Player GetPlayer()
    {
        return player;
    }
}
