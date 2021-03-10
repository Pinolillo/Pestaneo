using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase2_Gameplay_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject merlin;
    public MerlinController merlinController;
    public GameObject MerlinControllerObject;

    public ProgresoController progresoController;
    public GameObject progresoControllerObject;

    public GameObject[] checkmarks;
    public GameObject[] tiempos;

    private bool listo1;
    private bool listo2;
    private bool listo3;

    public congelamiento congelamientController;
    public GameObject congelarObject;

    public TiempoTareas tiempoTareasController;
    public GameObject tiempoTareasGameobject;

    public Image[] barrasTiempos;

    public Color32 barraNormal;
    public Color32 barraCongelada;

    public bool perdiste;
    public bool desarrollo;

    //Obtener la barra de congelamiento
    public BarraProgreso barradesarrollo;

    public float boostTime;
    public bool isboostavailable;

    void Start()
    {
        //Controlamos script de merlin
        merlinController = MerlinControllerObject.GetComponent<MerlinController>();
        //Controlamos script de progreso
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();
        //Controlamos el script de congelamiento
        congelamientController = congelarObject.GetComponent<congelamiento>();
        //Controlamos el script de tiempos
        tiempoTareasController = tiempoTareasGameobject.GetComponent<TiempoTareas>();

        listo1 = false;
        listo2 = false;
        listo3 = false;

        checkmarks[0].SetActive(false);
        checkmarks[1].SetActive(false);
        checkmarks[2].SetActive(false);

        boostTime = 0f;
        desarrollo = false;

        barradesarrollo.setInitialDuration(0f);
        barradesarrollo.slider.maxValue = 10f;

        isboostavailable = true;

    }
    void Update()
    {
        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();
        Trabajo3();

        //Checar si ganamos
        if (listo1 == true && listo2 == true && listo3 == true)
        {
            //Si gano el jugador if a Escena de victoria
            SceneManager.LoadScene(7);
            Debug.Log("Gane");
        }

        //Checar el boost de desarollo
        if (desarrollo == true)
        {
            boostTime = boostTime - 1f * Time.deltaTime;
            barradesarrollo.setDuration(boostTime);
        }
    }

    //Si Merlin se encuentra en el cuarto 1 va a trabajar en el objetivo 1
    //Si merliin congela el cuarto 1 debe parar el tiempo y cambiar el color de la barra del objtivo 1
    private void Trabajo1()
    {
        if (congelamientController.congelarCuarto1 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            Debug.Log("congelar objetivo 1");
            tiempoTareasController.congelandoObjetivo1 = true;
            barrasTiempos[0].color = barraCongelada;
        }
        else
        {
            tiempoTareasController.congelandoObjetivo1 = false;
            barrasTiempos[0].color = barraNormal;
        }
       
        //Condicion si se encuentra en el slot 1 y puede trabajar
        progresoController.numProgreso[0].text = progresoController.currentProgreso[0].ToString("0");

        if (merlinController.inRoom1 == true && progresoController.currentProgreso[0] <= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + merlinController.progreso * Time.deltaTime;
        }
        //Condicion si llega a segir en el slot 1 y el tiempo ya se cumplio 
        else if (progresoController.currentProgreso[0] >= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;

            listo1 = true;
            checkmarks[0].SetActive(true);
            tiempos[0].SetActive(false);
        }
        else if(progresoController.currentProgreso[0] <= 0)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;
            perdiste = true;

        }
        //Condicion cunado no se encuentre en este cuarto progresando 
        if (merlinController.inRoom1 == false)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;
        }
    }

    //Si Merlin se encuentra en el cuarto 2 va a trabajar en el objetivo 2
    //Si merliin congela el cuarto 2 debe parar el tiempo y cambiar el color de la barra del objtivo 2
    private void Trabajo2()
    {
        if (congelamientController.congelarCuarto2 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            Debug.Log("congelar objetivo 2");
            tiempoTareasController.congelandoObjetivo2 = true;
            barrasTiempos[1].color = barraCongelada;
        }
        else
        {
            tiempoTareasController.congelandoObjetivo2 = false;
            barrasTiempos[1].color = barraNormal;
        }

        progresoController.numProgreso[1].text = progresoController.currentProgreso[1].ToString("0");

        if (merlinController.inRoom2 == true && progresoController.currentProgreso[1] <= 20)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + merlinController.progreso * Time.deltaTime;
        }
        else if (progresoController.currentProgreso[1] >= 20)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + 0 * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + 0 * Time.deltaTime;

            listo2 = true;
            checkmarks[1].SetActive(true);
            tiempos[1].SetActive(false);
        }
        else if (progresoController.currentProgreso[1] <= 0)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;
            perdiste = true;
        }
        if (merlinController.inRoom2 == false)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + 0 * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + 0 * Time.deltaTime;

        }
    }

    //Si Merlin se encuentra en el cuarto 4 va a trabajar en el objetivo 3
    //Si merliin congela el cuarto 4 debe parar el tiempo y cambiar el color de la barra del objtivo 3
    private void Trabajo3()
    {
        if (congelamientController.congelarCuarto4 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            Debug.Log("congelar objetivo 3");
            tiempoTareasController.congelandoObjetivo3 = true;
            barrasTiempos[2].color = barraCongelada;
        }
        else
        {
            tiempoTareasController.congelandoObjetivo3 = false;
            barrasTiempos[2].color = barraNormal;
        }

        progresoController.numProgreso[2].text = progresoController.currentProgreso[2].ToString("0");

        if (merlinController.inRoom4 == true && progresoController.currentProgreso[2] <= 20)
        {
            progresoController.currentProgreso[2] = progresoController.currentProgreso[2] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[2].current = progresoController.barController[2].current + merlinController.progreso * Time.deltaTime;

        }
        else if (progresoController.currentProgreso[2] >= 20)
        {
            progresoController.currentProgreso[2] = progresoController.currentProgreso[2] + 0 * Time.deltaTime;
            progresoController.barController[2].current = progresoController.barController[2].current + 0 * Time.deltaTime;

            listo3 = true;
            checkmarks[2].SetActive(true);
            tiempos[2].SetActive(false);

            if(isboostavailable == true)
            {
                StartCoroutine(desarrolloPersonal());
            }
        }
        else if (progresoController.currentProgreso[2] <= 0)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;
            perdiste = true;
        }
        if (merlinController.inRoom4 == false)
        {
            progresoController.currentProgreso[2] = progresoController.currentProgreso[2] + 0 * Time.deltaTime;
            progresoController.barController[2].current = progresoController.barController[2].current + 0 * Time.deltaTime;

        }
    }

    //Segunda Parte Tutorial
    IEnumerator desarrolloPersonal()
    {
        isboostavailable = false;
        desarrollo = true;
        boostTime = 10f;

        merlinController.progreso = 2f;

        yield return new WaitForSeconds(10f);//10 Segundos dura la producividad

        desarrollo = false;
        merlinController.progreso = 1f;
    }

}

