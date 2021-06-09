using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public GameObject mainCam;

    public Text dialogText;
    public Text NameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;
    private bool _justStarted;

    public static DialogManager instance;

    void Start()
    {
        instance = this;

        nameBox.SetActive(false);
        dialogBox.SetActive(false);
    }

    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (!_justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                        Cursor.lockState = CursorLockMode.None;
                    }
                    else
                    {
                        CheckIfName();

                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    _justStarted = false;
                }

            }

        }
        else
        { }

    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];

        dialogBox.SetActive(true);

        _justStarted = true;

        nameBox.SetActive(isPerson);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("//"))
        {
            NameText.text = dialogLines[currentLine].Replace("//", "");
            currentLine++;
        }
    }

}