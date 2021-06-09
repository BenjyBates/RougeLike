using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public bool isPerson = true;

    public string[] lines;

    private bool _canActivate;

    void Update()
    {
        _canActivate = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (!DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.ShowDialog(lines, isPerson);
            }
        }
    }

}