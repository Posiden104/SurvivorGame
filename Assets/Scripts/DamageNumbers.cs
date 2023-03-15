using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{

    public GameObject damageNumberPrefab;
    public float damageNumberLifetime = 1f;
    private TextMeshPro tmp;

    // Call this method to display a damage number
    public void Show(int damageAmount)
    {
        GameObject damageNumber = Instantiate(damageNumberPrefab, transform.position, Quaternion.identity);

        damageNumber.GetComponentInChildren<TextMeshPro>().text = damageAmount.ToString();

        // Destroy the damage number after a set amount of time
        Destroy(damageNumber, damageNumberLifetime);
    }
}
