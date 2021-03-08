using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public Slider slider;

    public void setInitialDuration(float duration)
    {
        slider.maxValue = duration;
        slider.value = duration;
    }

    public void setDuration(float duration)
    {
        slider.value = duration;
    }

}
