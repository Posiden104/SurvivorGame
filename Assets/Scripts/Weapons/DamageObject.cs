using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private bool causesKnockback, canBreak;

    [SerializeField]
    [DrawIf("canBreak", true)]
    private int hitsToDie;

    public void Hit(Enemy enemy)
    {
        enemy.Damage(damage);
        if (!canBreak) return;
        hitsToDie--;
        if (hitsToDie == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            Hit(enemy);
            if(causesKnockback && enemy.TryGetComponent<Knockback>(out var kb)){
                kb.PlayFeedback(gameObject);
            }
        }
    }
}
