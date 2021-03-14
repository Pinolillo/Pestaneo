using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial_fase2 : MonoBehaviour
{
    public GameObject dedoIndicador;

    public GameObject[] popups;
    public Button okButton;
    public GameObject jareta;

    public int statusTutorial;
    private bool comenzartutorial;

    public GameObject PanelHabiliddes;

    public GameObject slot2;
    public GameObject bola;
    public GameObject suSlot;

    public TiempoTareas tiempoTareas;
    public GameObject TareasController;

    //Obtener la barra de congelamiento
    public BarraProgreso barradeboost;

    // Start is called before the first frame update
    void Start()
    {
        statusTutorial = 1;
        popups[0].SetActive(false);
        popups[1].SetActive(false);
        popups[2].SetActive(false);
        popups[3].SetActive(false);
        popups[4].SetActive(false);
        popups[5].SetActive(false);

        okButton.interactable = false;//El boton no se puede interactuar con el
        comenzartutorial = false;

        PanelHabiliddes.SetActive(true);
        dedoIndicador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Iniciar tutorial al darle click a la jareta
        if (comenzartutorial == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Jareta")
                {
                    StartCoroutine(botonAbilitar());
                    popups[0].SetActive(true);
                    comenzartutorial = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "congelamiento")
            {
                dedoIndicador.transform.position = slot2.transform.position;
            }
        }

        if(bola.transform.position == slot2.transform.position)
        {
            dedoIndicador.SetActive(false);
        }


        if (statusTutorial == 1)
        {
            StartCoroutine(showPopup3());
        }

    }

    public void TutorialFase2()
    {
        if (statusTutorial == 1)
        {
            popups[0].SetActive(false);
            okButton.interactable = false;
            PanelHabiliddes.SetActive(true);
            StartCoroutine(showPopup2());
            dedoIndicador.SetActive(true);
        }
        else if (statusTutorial == 2)
        {
            popups[2].SetActive(false);
            popups[3].SetActive(true);
            StartCoroutine(botonAbilitar());
            statusTutorial = 3;
        }
        else if(statusTutorial == 3)
        {
            popups[3].SetActive(false);
            popups[4].SetActive(true);
            StartCoroutine(botonAbilitar());
            statusTutorial = 4;
        }
        else if(statusTutorial == 4)
        {
            popups[4].SetActive(false);
            popups[5].SetActive(true);
            StartCoroutine(botonAbilitar());
            statusTutorial = 5;
            barradeboost.setDuration(10f);
        }
        else if(statusTutorial == 5)
        {
            popups[5].SetActive(false);
            this.gameObject.SetActive(false);//Eliminamos el boton
            barradeboost.setDuration(0f);
            SceneManager.LoadScene(7);
        }
    }

    //Segunda Parte Tutorial
    IEnumerator botonAbilitar()
    {
        okButton.interactable = false;
        yield return new WaitForSeconds(3f);
        okButton.interactable = true;//El boton ahora es interactuable
    }
    IEnumerator showPopup2()
    {
        yield return new WaitForSeconds(1f);
        popups[1].SetActive(true);
    }
    IEnumerator showPopup3()
    {
        if (bola.transform.position == slot2.transform.position)
        {
            //Comienza el demo de congelamiento
            tiempoTareas.GetComponent<TiempoTareas>().startPlay = true;
            tiempoTareas.startPlay = true;
            popups[1].SetActive(false);
            popups[2].SetActive(true);
            statusTutorial = 2;
            yield return new WaitForSeconds(20f);
            okButton.interactable = true;//El boton ahora es interactuable
            tiempoTareas.startPlay = false;
        }
    }
}
