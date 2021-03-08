using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgresBar : MonoBehaviour
{
    public int maximum;
    public int minimum;
    public int current;

    public Image mask;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
