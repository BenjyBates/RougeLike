using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    [SerializeField] GameObject uiBox;

    [SerializeField] Image uiPortrait;
    [SerializeField] Image chPortrait;

    [SerializeField] Text uiSpeech;
    [TextArea(15, 20)]
    public string dialogSay;

    private bool _speechClick = false;

    void Update()
    {
        if (_speechClick == true)
        {
            uiBox.gameObject.SetActive(true);
            uiPortrait = chPortrait;
            uiSpeech.text = dialogSay;
            Time.timeScale = 0;
        }
        else if (_speechClick == false)
        {
            uiBox.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void OnMouseDown()
    {
        if (_speechClick == false)
        {
            _speechClick = true;
        }
        else if (_speechClick == true)
        {
            _speechClick = false;
        }
    }
}