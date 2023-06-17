using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Image expBar;

    private Player player;

    void Start()
    {
        player = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.GetHpPercentage();
        expBar.fillAmount = player.GetExpPercentage();
    }
}