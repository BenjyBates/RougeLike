using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public Floors Start_Exit;
    public Floors NextFloor;
    public Floors[] Rooms;

    public bool Started;
    private bool Finished;

    private void Awake()
    {        
        Start_Exit.completed = true;

        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].next = false;
            Rooms[i].completed = false;
        }

        if(!Started)
        {
            Rooms[0].next = true;
        }        
    }

    private void Update()
    {


    }
}
