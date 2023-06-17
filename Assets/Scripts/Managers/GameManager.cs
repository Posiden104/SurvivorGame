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

    // ENEMIES
    public GameObject zombiePrefab;
    public GameObject zombieSlowPrefab;

    // UI
    public Timer timer;
    public GameObject gameEndUI;
    public GameEndScreen gameEndScreenScript;
    public GameObject gameOverUI;
    public GameObject gameStartUI;

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
