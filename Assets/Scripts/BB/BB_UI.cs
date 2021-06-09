using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BB_UI : MonoBehaviour
{
    [Header ("User Interface Elements")]
    public Text TextRoomNumber;
    public Text TextFloorName;

    [Header ("Floor Variables")]
    public int roomNumber;
    public string[] floorNames;
    private int floorMovement;



    private void Update()
    {


        TextRoomNumber.text = "Room " + roomNumber.ToString();
        TextFloorName.text = "Floor " + floorNames[floorMovement];
    }


}
