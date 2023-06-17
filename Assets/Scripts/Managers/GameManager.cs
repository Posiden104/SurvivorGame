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
    public GameObject CrosshairPrefab;

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
    public LevelUpScreen levelUpScreenScript;

    // PRIVATE

    void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        Time.timeScale = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
