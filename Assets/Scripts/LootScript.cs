using UnityEngine;

public class LootScript : MonoBehaviour
{
    public int Value { get; set; } = 1;

    static Object[] images;

    private void Awake()
    {
        images ??= Resources.LoadAll("ScrapImages", typeof(Sprite));
    }

    // Start is called before the first frame update
    void Start()
    {
        var idx = Random.Range(0, images.Length);
        GetComponent<SpriteRenderer>().sprite = Instantiate(images[idx]) as Sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.PickupScrap(Mathf.Max(Value, 1));
            Destroy(gameObject);
        }
    }
}
