using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{

    [SerializeField]
    private Button opt1Btn, opt2Btn, opt3Btn;

    private string opt1Text, opt2Text, opt3Text;
    private int opt1Id, opt2Id, opt3Id;
    private int numWeapons;
    private IList<int> weaponIds;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OptionPicked()
    {
        GameManager.Instance.player.LevelUpDone();
    }

    void PopulateWeaponIds()
    {
        numWeapons = WeaponManager.weaponCount;
        weaponIds = new List<int>();
        for(int i = 0; i < numWeapons; i++)
        {
            weaponIds.Add(i);
        }
    }

    void ShuffleWeaponIds()
    {
        if (weaponIds == null)
            PopulateWeaponIds();
        for (int i = 0; i < weaponIds.Count; i++)
        {
            int temp = weaponIds[i];
            int randomIndex = Random.Range(i, weaponIds.Count);
            weaponIds[i] = weaponIds[randomIndex];
            weaponIds[randomIndex] = temp;
        }
    }

    void GetUpgradeOptions()
    {
        opt1Id = weaponIds[0];
        opt2Id = weaponIds[1];
        opt3Id = weaponIds[2];
        opt1Text = WeaponManager.Instance.GetWeaponName(opt1Id);
        opt2Text = WeaponManager.Instance.GetWeaponName(opt2Id);
        opt3Text = WeaponManager.Instance.GetWeaponName(opt3Id);
    }

    public void Show()
    {
        ShuffleWeaponIds();
        GetUpgradeOptions();

        opt1Btn.onClick.RemoveAllListeners();
        opt1Btn.onClick.AddListener(delegate { WeaponManager.Instance.WeaponUpgrade(opt1Id); });
        opt1Btn.GetComponentInChildren<TextMeshProUGUI>().text = opt1Text;

        opt2Btn.onClick.RemoveAllListeners();
        opt2Btn.onClick.AddListener(delegate { WeaponManager.Instance.WeaponUpgrade(opt2Id); });
        opt2Btn.GetComponentInChildren<TextMeshProUGUI>().text = opt2Text;

        opt3Btn.onClick.RemoveAllListeners();
        opt3Btn.onClick.AddListener(delegate { WeaponManager.Instance.WeaponUpgrade(opt3Id); });
        opt3Btn.GetComponentInChildren<TextMeshProUGUI>().text = opt3Text;

        opt1Btn.onClick.AddListener(OptionPicked);
        opt2Btn.onClick.AddListener(OptionPicked);
        opt3Btn.onClick.AddListener(OptionPicked);

        GameManager.Instance.levelUpScreen.SetActive(true);
    }
}
