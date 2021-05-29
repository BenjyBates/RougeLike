using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomInteractable : MonoBehaviour
{
    public GameObject Highlight;
    public Activity Exit;
    private bool _On;
    public string Name;

    private void OnMouseEnter()
    {
        _On = true;
        UserInterface.InteractString = Name;
        UserInterface.ShowInteractString = true;
    }

    private void OnMouseExit()
    {
        _On = false;
        UserInterface.ShowInteractString = false;
    }

    private void Update()
    {          

        if (_On)
        {
            Highlight.gameObject.SetActive(true);
        }
        else
        {
            Highlight.gameObject.SetActive(false);
        }

    }

    private void OnMouseUp()
    {
        GameManager.CurrentActivity = Exit;
    }
}
