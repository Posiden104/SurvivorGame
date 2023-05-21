using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    //[SerializeField]
    //private Transform opt1, opt2, opt3;
    [SerializeField]
    private Button opt1Btn, opt2Btn, opt3Btn;

    // Start is called before the first frame update
    void Start()
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OptionPicked()
    {
        GameManager.Instance.player.LevelUpDone();
    }

    public void Show()
    {
        opt1Btn.onClick.RemoveAllListeners();
        opt1Btn.onClick.AddListener(delegate { GameManager.Instance.player.weaponManager.WeaponUpgrade(0); });
        opt1Btn.GetComponentInChildren<TextMeshProUGUI>().text = "Gun";

        opt2Btn.onClick.RemoveAllListeners();
        opt2Btn.onClick.AddListener(delegate { GameManager.Instance.player.weaponManager.WeaponUpgrade(1); });
        opt2Btn.GetComponentInChildren<TextMeshProUGUI>().text = "Sword";

        opt3Btn.onClick.RemoveAllListeners();
        opt3Btn.onClick.AddListener(delegate { GameManager.Instance.player.weaponManager.WeaponUpgrade(2); });
        opt3Btn.GetComponentInChildren<TextMeshProUGUI>().text = "Overwatch";

        opt1Btn.onClick.AddListener(OptionPicked);
        opt2Btn.onClick.AddListener(OptionPicked);
        opt3Btn.onClick.AddListener(OptionPicked);

        GameManager.Instance.levelUpScreen.SetActive(true);
    }
}
