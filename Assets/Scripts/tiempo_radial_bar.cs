using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class tiempo_radial_bar : MonoBehaviour
{
    public float maximum;
    public float minimum;
    public float current;

    public Sprite normalfill;
    public Sprite completadofill;
    public Sprite congeladofill;
    public Image myImage;
    public Sprite normalRadial;

    public Image fill;

    public GameObject check;
    public GameObject number;
    public GameObject radial;

    public Color32 orange;
    public Color32 blue;

    //Controlar script de barras radiales
    public congelamiento congelamientoController;
    public GameObject congelamietnoObject;

    // Start is called before the first frame update
    void Start()
    {
        check.SetActive(false);
        myImage = this.GetComponent<Image>();
        congelamientoController = congelamietnoObject.GetComponent<congelamiento>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOfset = current - minimum;
        float maximumoffset = maximum - minimum;
        float fillamout = currentOfset / maximumoffset;
        fill.fillAmount = fillamout;
    }

    public void terminadoObjetivo()
    {
        check.SetActive(true);
        radial.SetActive(false);
        number.SetActive(false);
        myImage.sprite = completadofill;
    }

    public void CongelandoObjetivo()
    {
         fill.sprite = congeladofill;
         number.GetComponent<Outline>().effectColor = blue;
    }
    public void NormalEstate()
    {
        fill.sprite = normalRadial;
        number.GetComponent<Outline>().effectColor = orange;
    }

}
