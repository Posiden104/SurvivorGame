using Assets.Scripts.Pickups;
using UnityEngine;

public class LootScript : PickupBase
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

    public override void OnPlayerPickup()
    {
        GameManager.Instance.GetPlayer().PickupScrap(Mathf.Max(Value, 1));
        base.OnPlayerPickup();
    }
}
