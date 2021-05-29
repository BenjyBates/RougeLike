using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{

    [Header("Battle")]
    public GameObject UIBattle;

    [Header("Free Roam")]
    public Image Reticle;
    public Text InteractName;
    public static string InteractString;
    public static bool ShowInteractString;

    [Header("Player Info")]
    public Text HealthNumber;   
    public Text WeaponName;
    public Image WeaponImage;

    [Header("Elevator")]
    public Text FloorText;
    private string FloorNum;

    private Player PlayerUIReference;

    void Update()
    {
        PlayerUIReference = GameManager.playerProfile;

        FreeRoamInfo();
        ElevatorInfo();
        ShowHealth();
        ShowWeapon();
        ShowBattleInfo();
    }

    void ShowHealth()
    {
        HealthNumber.text = PlayerUIReference.health.ToString();
    }

    void ShowWeapon()
    {
        WeaponName.text = PlayerUIReference.CurrentWeapon.Name;
        WeaponImage.sprite = PlayerUIReference.CurrentWeapon.image;
    }

    void ShowBattleInfo()
    {
        if(GameManager.CurrentActivity == Activity.Battle)
        {
            UIBattle.gameObject.SetActive(true);
        }
        else
            UIBattle.gameObject.SetActive(false);
    }

    void FreeRoamInfo()
    {

        if (MouseLook.fpsCamOn)
        {
            Reticle.gameObject.SetActive(true);
        }
        else
        {
            Reticle.gameObject.SetActive(false);
        }

        InteractName.text = InteractString;

        if(ShowInteractString)
        {
            InteractName.gameObject.SetActive(true);
        }
        else
        {
            InteractName.gameObject.SetActive(false);
        }
    }

    void ElevatorInfo()
    {
        if (GameManager.CurrentActivity == Activity.Quest)
        {
            FloorText.gameObject.SetActive(true);
        }
        else
            FloorText.gameObject.SetActive(false);
    }
}
