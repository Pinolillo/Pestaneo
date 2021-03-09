using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresoController : MonoBehaviour
{

    public Text[] numProgreso;
    public float[] currentProgreso;
    public GameObject[] barrasProgreso;

    //Controlar script de barras
    public ProgresBar[] barController;
    public GameObject[] barControlleObject;

    // Start is called before the first frame update
    void Start()
    {
        barController[0] = barControlleObject[0].GetComponent<ProgresBar>();
        barController[1] = barControlleObject[1].GetComponent<ProgresBar>();
        barController[2] = barControlleObject[2].GetComponent<ProgresBar>();
        barController[3] = barControlleObject[3].GetComponent<ProgresBar>();
        barController[4] = barControlleObject[4].GetComponent<ProgresBar>();

        numProgreso[0].text = currentProgreso[0].ToString("0");
        numProgreso[1].text = currentProgreso[1].ToString("0");
        numProgreso[2].text = currentProgreso[2].ToString("0");
        numProgreso[3].text = currentProgreso[3].ToString("0");
        numProgreso[4].text = currentProgreso[4].ToString("0");
    }
    private void Update()
    {

    }
}
