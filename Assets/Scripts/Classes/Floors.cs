using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    public GameObject master;
    public bool completed;
    public bool next;
    private Renderer cubeRend;

    private void Awake()
    {
        cubeRend = master.GetComponent<Renderer>();
    }

    private void Update()
    {

        if(next)
        {
            cubeRend.material.SetColor("_Color", Color.yellow);
        }
        else if(completed)
        {
            cubeRend.material.SetColor("_Color", Color.green);
        }
        else
        {
            cubeRend.material.SetColor("_Color", Color.red);
        }
    }
}
