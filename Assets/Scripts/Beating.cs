using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beating : MonoBehaviour
{
    public float meterFill;
    public float max;
    private float min = 0;

    public float increase;
    public float decreaseSpeed;
    private bool pressButton;

    public Image meter;
    public Button button;

    private void Update()
    {
        if(meterFill > min)
        {
            meterFill -= decreaseSpeed * Time.deltaTime;
        }

        if (pressButton)
        {
            meterFill += increase;
            pressButton = false;
        }

        if(meterFill > max)
        {
            meterFill = max;
        }
        else if(meterFill < min)
        {
            meterFill = min;
        }

        meter.fillAmount = Mathf.Clamp(meterFill / max, 0, 1f);
    }

    public void ButtonIncrease()
    {
        pressButton = true;
    }


}
