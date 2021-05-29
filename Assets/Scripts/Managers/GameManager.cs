using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Activity { Home, Quest, Battle}

public class GameManager : MonoBehaviour
{
    public Activity startingActivity;

    public static Player playerProfile;
    public Player ThePlayer;

    public static Activity CurrentActivity;


    public Camera Cam;
    public GameObject[] CameraSeats;

    private void Awake()
    {       
        CurrentActivity = startingActivity;
    }

    private void Update()
    {
        playerProfile = ThePlayer;

        GoTo();


    }
    
    
    public void GoTo()
    {
      

        switch(CurrentActivity)
        {
            case Activity.Home:
                Cam.transform.position = CameraSeats[0].transform.position;
                MouseLook.fpsCamOn = true;
                break;

            case Activity.Quest:
                Cam.transform.position = CameraSeats[1].transform.position; Cam.transform.rotation = CameraSeats[1].transform.rotation;
                MouseLook.fpsCamOn = false;
                break;

            case Activity.Battle:
                Cam.transform.position = CameraSeats[2].transform.position; Cam.transform.rotation = CameraSeats[1].transform.rotation;
                MouseLook.fpsCamOn = false;
                break;

        }
    }
}
