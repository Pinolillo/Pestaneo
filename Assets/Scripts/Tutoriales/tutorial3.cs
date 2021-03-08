using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial3 : MonoBehaviour
{
    public GameObject popup4; //Pop up 4
    public GameObject popup5; //quinto pop up

    public Button okbuton2;

    private bool _YaSePresionoBoton = false;

    // Start is called before the first frame update
    void Start()
    {
        popup5.SetActive(false);
    }

    public void Tutorial3()
    {
        // Detectar que click se ha dado
        if (_YaSePresionoBoton)
        {
            // Segundo Click
            _YaSePresionoBoton = false;
            popup5.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            // primer click
            popup4.SetActive(false);
            popup5.SetActive(true);
            _YaSePresionoBoton = true;
            StartCoroutine(LlamarPorSegundaVezAlBoton2());
        }
    }

    //Segunda Parte Tutorial
    IEnumerator LlamarPorSegundaVezAlBoton2()
    {
        okbuton2.interactable = false;//El boton ahora es interactuable
        yield return new WaitForSeconds(3f);
        okbuton2.interactable = true;//El boton ahora es interactuable
    }
}
