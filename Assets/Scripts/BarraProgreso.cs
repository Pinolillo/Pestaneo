using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public Color32 normalcolor;
    public Color32 boostColor;
    public Color32 distractedColor;

    private void Start()
    {

    }

    public void setInitialProgres(float progres)
    {
        slider.value = progres;
    }

    public void setProgres(float progres)
    {
        slider.value = progres;
    }

    public void NormalProgres()
    {
        fill.color = normalcolor;
    }
    public void BoostedProges()
    {
        fill.color = boostColor;
    }
    public void DistractedProges()
    {
        fill.color = distractedColor;
    }
}
