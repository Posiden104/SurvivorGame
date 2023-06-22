using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    [SerializeField]
    private List<WeaponLevelUpButton> UIButtons;

    private int numWeapons;
    private IList<int> weaponIds;

    // Update is called once per frame
    void Update()
    {
        
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

    void SetUpgradeOptions()
    {
        for(int i = 0; i < UIButtons.Count; i++)
        {
            UIButtons.ElementAt(i).SetUpgrade(weaponIds[i]);
        }
    }

    public void Show()
    {
        ShuffleWeaponIds();
        SetUpgradeOptions();

        GameManager.Instance.levelUpScreen.SetActive(true);
    }
}
