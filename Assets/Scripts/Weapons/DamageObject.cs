using System;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.Weapons;

public class DamageObject : MonoBehaviour
{
    [SerializeField]
    private bool causesKnockback, canBreak;
    public Weapon baseWeapon;

    [SerializeField]
    //[DrawIf("canBreak", true)]
    private int hitsToDie;

    private Action<float> onHitActions;

    public void Hit(Enemy enemy)
    {
        enemy.Damage(baseWeapon.damage);
        onHitActions(baseWeapon.damage);
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

    public void RegisterOnHit(Action<float> act)
    {
        onHitActions += act;
    }

}
