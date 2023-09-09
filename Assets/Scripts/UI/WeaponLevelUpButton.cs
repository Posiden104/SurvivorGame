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
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI text;



    public void OptionPicked()
    {
        WeaponManager.Instance.WeaponUpgrade(id);
        GameManager.Instance.GetPlayer().LevelUpDone();
    }

    public void SetUpgrade(int weaponId)
    {
        id = weaponId;
        title.text = WeaponManager.Instance.GetWeaponName(id);
        text.text = WeaponManager.Instance.GetLevelUpStats(id);
    }
}
