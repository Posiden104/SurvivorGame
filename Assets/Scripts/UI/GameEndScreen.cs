using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI weaponStatsTMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStats(List<WeaponStats> stats)
    {
        StringBuilder sb = new();
        foreach (var ws in stats)
        {
            sb.AppendLine($"{ws.Name} - Total Damage: {ws.DamageDealt} | DPS: {ws.DPS:0.00}");
        }

        weaponStatsTMP.text = sb.ToString();
    }
}
