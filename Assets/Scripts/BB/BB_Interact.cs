using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Interact : MonoBehaviour
{
    RaycastHit hit;
    public float distance;
    public GameObject PickupMessage;
    private float RayDist;
    private bool canSeePickup = false;


    [Header("Door Interactions")]

    public string[] Door_EntMessage;

    private void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        RayDist = distance;
    }


    private void Update()
    {
        DoorEnt();
        DoorInteract();



        if(canSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDist = 1000f;
        }
        else
        {
            PickupMessage.gameObject.SetActive(false);
            RayDist = distance;
        }
    }


    void DoorInteract()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDist))
        {
            //Sees the door
            if (hit.transform.tag == "Door")
            {
                canSeePickup = true;
            }
            else
            {
                canSeePickup = false;
            }
        }
    }    
    
    
    void DoorEnt()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDist))
        {
            //Sees the door
            if (hit.transform.tag == "Door_Ent")
            {
                canSeePickup = true;
                if (Input.GetMouseButtonUp(0))
                {
                    DialogManager.instance.ShowDialog(Door_EntMessage, false);
                }
            }
            else
            {
                canSeePickup = false;
            }
        }
    }

}
