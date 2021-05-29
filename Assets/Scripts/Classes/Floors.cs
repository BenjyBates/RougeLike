using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    public GameObject master;
    public bool interactable;
    private Renderer cubeRend;

    private void Awake()
    {
        cubeRend = master.GetComponent<Renderer>();
    }

    private void Update()
    {

        if(interactable)
        {
            cubeRend.material.SetColor("_Color", Color.green);
        }
        else if(!interactable)
        {
            cubeRend.material.SetColor("_Color", Color.red);
        }
    }
}
