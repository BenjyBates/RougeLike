using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Enemy[] MonsterManual;   
    private Enemy CurrentEnemy;
    private Items LootDrop;

    [Header("Seats")]
    public GameObject EnemySeat;
    public GameObject LootSeat;

    public static bool BattleInteract;
    public static bool IsLooting;


    [Header("UI Ammo")]
    public Text AmmoText;
    public Text AmmoMaxText;
    [Header("UI Enemy")]
    public Text EnemyName;
    public Text EnemyHealthDebug;
    public Image EnemyHealth;
    public Image EnemyStamina;
    [Header("UI Reload")]
    public GameObject Reloader;
    public Image ReloadBar;
    public Button ReloadButton;

    //Logic
    private bool EnemyDying;
    private int TempAmmo;
    private int TempMaxAmmo;
    private bool Loaded;
    private bool ReloadingGun;
    private float ReloadTime;
    public bool fightStarted;
    private bool fightFinished;




    private void Awake()
    {
        BattleInteract = false;
        spawnEnemy();
    }

    private void Update()
    {
        UserInterfaceBattle();

        if(fightStarted && !fightFinished)
        {
            EnemyLogic();

            ReloadCheck();

            if (BattleInteract)
            {
                if (CurrentEnemy.health > 0)
                {
                    if (Loaded)
                    {
                        CurrentEnemy.health -= GameManager.playerProfile.CurrentWeapon.damage;
                        TempAmmo--;
                    }
                    else
                    {

                    }
                }

                BattleInteract = false;
            }
        
            if (CurrentEnemy.health <= 0)
            {
                EnemyDeath();
            }
            else if (GameManager.playerProfile.health <= 0)
            {
                fightFinished = true;
            }
            else
            {

            }
        
        
        }



        LootingCheck();
    }

    void spawnEnemy()
    {
        CurrentEnemy = Instantiate(MonsterManual[Random.Range(0,MonsterManual.Length)], new Vector3(EnemySeat.transform.position.x, EnemySeat.transform.position.y, EnemySeat.transform.position.z), Quaternion.identity);
        CurrentEnemy.health = CurrentEnemy.maxHealth;

    }

    void UserInterfaceBattle()
    {
        TempMaxAmmo = GameManager.playerProfile.CurrentWeapon.ammoCount;

        EnemyName.text = CurrentEnemy.Name;
        EnemyHealth.fillAmount = Mathf.Clamp(CurrentEnemy.health / CurrentEnemy.maxHealth, 0, 1f);
        EnemyHealthDebug.text = CurrentEnemy.health.ToString();

        AmmoText.text = TempAmmo.ToString();
        AmmoMaxText.text = GameManager.playerProfile.CurrentWeapon.ammoCount.ToString();

        ReloadBar.fillAmount = Mathf.Clamp(ReloadTime / 100, 0, 1f);
        
        if(!Loaded)
        {
            ReloadButton.gameObject.SetActive(true);
        }
        else
        {
            ReloadButton.gameObject.SetActive(false);
        }
    }

    void EnemyLogic()
    {

        if(CurrentEnemy.health > 0)
        {
            if(EnemyStamina.fillAmount <= 0)
            {
                GameManager.playerProfile.health -= CurrentEnemy.attackDamage;
                EnemyStamina.fillAmount = 1f;
            }
            else
            {
                EnemyStamina.fillAmount -= CurrentEnemy.attackDelay * Time.deltaTime;
            }
        }
    }

    void EnemyDeath()
    {
        LootDrop = Instantiate(CurrentEnemy.Loot[Random.Range(0, CurrentEnemy.Loot.Length)], new Vector3(LootSeat.transform.position.x, LootSeat.transform.position.y, LootSeat.transform.position.z), Quaternion.identity);
        Object.Destroy(CurrentEnemy.gameObject);
        fightFinished = true;
    }

    void ReloadCheck()
    {
        if(TempAmmo <= 0)
        {
            Loaded = false;
        }
        else
        {
            Loaded = true;
        }

        if(ReloadingGun)
        {
            if(ReloadTime < 100)
            {
                ReloadTime += GameManager.playerProfile.CurrentWeapon.reloadTime * Time.deltaTime;
            }
            else if(ReloadTime >= 100)
            {
                TempAmmo = TempMaxAmmo;
                ReloadingGun = false;
            }

        }
    }

    public void ReloadButtonPress()
    {
        if(!Loaded)
        {
            ReloadTime = 0;
            ReloadingGun = true;
        }
    }

    void LootingCheck()
    {
        if (IsLooting)
        {
            GameManager.playerProfile.health += LootDrop.HealthRegen;

            Object.Destroy(LootDrop.gameObject);
            IsLooting = false;
        }
        else
        {

        }
    }
}
