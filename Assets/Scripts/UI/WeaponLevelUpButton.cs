using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponLevelUpButton : MonoBehaviour 
{
    //public string text;
    private int id;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI tmp;

    public void OptionPicked()
    {
        WeaponManager.Instance.WeaponUpgrade(id);
        GameManager.Instance.player.LevelUpDone();
    }

    public void SetUpgrade(int weaponId)
    {
        id = weaponId;
        tmp.text = WeaponManager.Instance.GetLevelUpStats(id);
    }
}
