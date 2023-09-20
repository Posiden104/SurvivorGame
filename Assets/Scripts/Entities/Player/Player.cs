using Assets.Scripts.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Entity
{
    public Vector3 dirOrth { get; private set; }
    public Vector3 dirTrueNormalized { get; private set; }
    public WeaponId StartingWeapon;
    public float magnetRange;
    public int TotalKills;

    private WeaponManager weaponManager { get; set; }
    [SerializeField]
    private int scrap = 9;
    private int level = 1;
    private int scrapToNextLevel = 10;
    private float hpScale = 1.2f;
    private float xpScale = 1.2f;
    [SerializeField]
    private Transform projectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        dirOrth = Vector3.right;
        dirTrueNormalized = Vector3.right;

        weaponManager = WeaponManager.Instance;
        weaponManager.Setup((int)StartingWeapon, projectileSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    public override void Kill()
    {
        GameManager.Instance.PlayerDied();
    }


    public void SetNormalizedDir(Vector3 dir)
    {
        if (dir != Vector3.zero) dirTrueNormalized = dir;

        if (dir.y > 0)
        {
            dirOrth = Vector3.up;
        }
        else if (dir.y < 0)
        {
            dirOrth = Vector3.down;
        }

        if (dir.x > 0)
        {
            dirOrth = Vector3.right;
        }
        else if (dir.x < 0)
        {
            dirOrth = Vector3.left;
        }
    }

    public void PickupScrap(int scrapValue)
    {
        scrap += scrapValue;
        if(scrap >= scrapToNextLevel)
        {
            scrap -= scrapToNextLevel;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        scrapToNextLevel = (int)(scrapToNextLevel * xpScale);
        MaxHP = (int) (MaxHP * hpScale);
        HP = (int) (HP * hpScale);

        Time.timeScale = 0;
        GameManager.Instance.levelUpScreenScript.Show();
    }

    public void LevelUpDone()
    {
        GameManager.Instance.levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public float GetExpPercentage()
    {
        return (float) (scrap) / scrapToNextLevel;
    }

    public float GetHpPercentage()
    {
        return HP / MaxHP;
    }
}
