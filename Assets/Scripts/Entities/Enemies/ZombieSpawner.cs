using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public float SpawnDelay = 5f;
    public float InitialDelay;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Instantiate(GameManager.Instance.zombiePrefab, transform.position, transform.rotation, transform);
        //Instantiate(GameManager.Instance.zombieSlowPrefab, transform.position, transform.rotation);
        timer -= InitialDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= SpawnDelay)
        {
            var num = Random.value;
            GameObject enemy; // = GameManager.Instance.zombieSlowPrefab;
            if (num >= 0.5f)
                enemy = GameManager.Instance.ZombiePrefab;
            else
                enemy = GameManager.Instance.ZombieSlowPrefab;
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
