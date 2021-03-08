using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial3 : MonoBehaviour
{
    public GameObject popup4; //Pop up 4
    public GameObject popup5; //quinto pop up
    public GameObject popup6;
    public GameObject popup7;
    public GameObject popup8;

    public GameObject cuarto1;

    public Button okbuton2;
    public GameObject merlin;

    public TiempoTareas tiempoTareas;
    public GameObject TareasController;

    private int botonStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
        popup5.SetActive(false);
        popup6.SetActive(false);
        popup7.SetActive(false);
        popup8.SetActive(false);

        tiempoTareas = TareasController.GetComponent<TiempoTareas>();
    }

    public void Tutorial3()
    {
        // Detectar que click se ha dado
        if (botonStatus == 0)
        {
            // primer click
            popup4.SetActive(false);
            popup5.SetActive(true);
            StartCoroutine(LlamarPorSegundaVezAlBoton2());

            botonStatus = 1;
        }
        else if(botonStatus == 1)
        {
            // Segundo Click
            popup5.SetActive(false);
            merlin.transform.position = cuarto1.transform.position;

            tiempoTareas.GetComponent<TiempoTareas>().startPlay = true;
            tiempoTareas.startPlay = true;

            botonStatus = 2;
            StartCoroutine(LlamarPorSegundaVezAlBoton2());
            popup6.SetActive(true);
        }
        else if (botonStatus == 2)
        {
            // Segundo Click
            popup6.SetActive(false);
            popup7.SetActive(true);
            botonStatus = 3;
        }
        else if(botonStatus == 3)
        {
            popup7.SetActive(false);
            popup8.SetActive(true);
            this.gameObject.SetActive(false);
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
