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
    public Image[] progresoBarraTiempos;

    public Color32 Green;
    public Color32 Blue;
    public Color32 Black;
    public Color32 White;

    public bool perdiste;

    public bool desarrollo;

    //Obtener la barra de congelamiento
    public BarraProgreso barradesarrollo;

    public float boostTime;
    public bool isboostavailable;

    public Sprite fondoNormal;
    public Sprite fondoCongelado;

    private RectTransform rt1;
    private RectTransform rt2;
    private RectTransform rt3;

    private Image base1;
    private Image base2;
    private Image base3;

    public Text[] objetivosTitulos;

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

        //El color del titulo 3 es green por ser objetivo de desarrollo
        objetivosTitulos[2].color = Green;

        listo1 = false;
        listo2 = false;
        listo3 = false;

        checkmarks[0].SetActive(false);
        checkmarks[1].SetActive(false);
        checkmarks[2].SetActive(false);

        boostTime = 0f;
        desarrollo = false;

        perdiste = false;

        barradesarrollo.setInitialDuration(0f);
        barradesarrollo.slider.maxValue = 10f;

        isboostavailable = true;

        base1 = barrasTiempos[0].GetComponent<Image>();
        base2 = barrasTiempos[1].GetComponent<Image>();
        base3 = barrasTiempos[2].GetComponent<Image>();

        //Rect Transform de las bases para poder cambiar su tamaño cuando se congelan
        rt1 = (RectTransform)barrasTiempos[0].transform;
        rt2 = (RectTransform)barrasTiempos[1].transform;
        rt3 = (RectTransform)barrasTiempos[2].transform;
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
            Debug.Log("Gane");
            SceneManager.LoadScene(8);
        }

        //Checar el boost de desarollo
        if (desarrollo == true)
        {
            boostTime = boostTime - 1f * Time.deltaTime;
            barradesarrollo.setDuration(boostTime);
        }
        //Checar cuando haya perdido el juego
        if (tiempoTareasController.perder == true)
        {
            SceneManager.LoadScene(10);
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
            StartCoroutine(FreezeBase1());
        }
        else
        {
            tiempoTareasController.congelandoObjetivo1 = false;
        }
       
        //Condicion si se encuentra en el slot 1 y puede trabajar
        progresoController.numProgreso[0].text = progresoController.currentProgreso[0].ToString("0");

        if (merlinController.inRoom1 == true && progresoController.currentProgreso[0] <= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + merlinController.progreso * Time.deltaTime;
        }
        //Condicion si llega a segir en el slot 1 y el tiempo ya se cumplio 
        if (progresoController.currentProgreso[0] >= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;

            listo1 = true;
            tiempoTareasController.listo1 = true;
            checkmarks[0].SetActive(true);
            tiempos[0].SetActive(false);
            barrasTiempos[0].color = Green;
            objetivosTitulos[0].color = White;
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
            StartCoroutine(FreezeBase2());
        }
        else
        {
            tiempoTareasController.congelandoObjetivo2 = false;
        }

        progresoController.numProgreso[1].text = progresoController.currentProgreso[1].ToString("0");

        if (merlinController.inRoom2 == true && progresoController.currentProgreso[1] <= 20)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + merlinController.progreso * Time.deltaTime;
        }
        if (progresoController.currentProgreso[1] >= 20)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + 0 * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + 0 * Time.deltaTime;

            listo2 = true;
            tiempoTareasController.listo2 = true;
            checkmarks[1].SetActive(true);
            tiempos[1].SetActive(false);
            barrasTiempos[1].color = Green;
            objetivosTitulos[1].color = White;
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
        if (congelamientController.congelarCuarto3 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            Debug.Log("congelar objetivo 3");
            tiempoTareasController.congelandoObjetivo3 = true;
            StartCoroutine(FreezeBase3());
        }
        else
        {
            tiempoTareasController.congelandoObjetivo3 = false;
        }

        progresoController.numProgreso[2].text = progresoController.currentProgreso[2].ToString("0");

        if (merlinController.inRoom3 == true && progresoController.currentProgreso[2] <= 20)
        {
            progresoController.currentProgreso[2] = progresoController.currentProgreso[2] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[2].current = progresoController.barController[2].current + merlinController.progreso * Time.deltaTime;

        }
        if (progresoController.currentProgreso[2] >= 20)
        {
            progresoController.currentProgreso[2] = progresoController.currentProgreso[2] + 0 * Time.deltaTime;
            progresoController.barController[2].current = progresoController.barController[2].current + 0 * Time.deltaTime;

            listo3 = true;
            tiempoTareasController.listo3 = true;
            checkmarks[2].SetActive(true);
            tiempos[2].SetActive(false);
            barrasTiempos[2].color = Green;
            objetivosTitulos[2].color = White;

            if (isboostavailable == true)
            {
                StartCoroutine(desarrolloPersonal());
            }
        }
        if (merlinController.inRoom3 == false)
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

    //Al conjelar un objetivo debemos determinar el color de la barra de tareas
    IEnumerator FreezeBase1()
    {
        base1.sprite = fondoCongelado;
        rt1.sizeDelta = new Vector2(170f, 135f);
        progresoBarraTiempos[0].color = Blue;
        objetivosTitulos[0].color = Blue;
        yield return new WaitForSeconds(20f);//20 Segundos dura congelado
        base1.sprite = fondoNormal;
        rt1.sizeDelta = new Vector2(170f, 85f);
        progresoBarraTiempos[0].color = Green;
        objetivosTitulos[0].color = Black;
    }
    IEnumerator FreezeBase2()
    {
        base2.sprite = fondoCongelado;
        rt2.sizeDelta = new Vector2(170f, 135f);
        progresoBarraTiempos[1].color = Blue;
        objetivosTitulos[1].color = Blue;
        yield return new WaitForSeconds(20f);//20 Segundos dura congelado
        base2.sprite = fondoNormal;
        rt2.sizeDelta = new Vector2(170f, 85f);
        progresoBarraTiempos[1].color = Green;
        objetivosTitulos[1].color = Black;
    }
    IEnumerator FreezeBase3()
    {
        base3.sprite = fondoCongelado;
        rt3.sizeDelta = new Vector2(170f, 135f);
        progresoBarraTiempos[2].color = Blue;
        objetivosTitulos[2].color = Blue;
        yield return new WaitForSeconds(20f);//20 Segundos dura congelado
        base3.sprite = fondoNormal;
        rt3.sizeDelta = new Vector2(170f, 85f);
        progresoBarraTiempos[2].color = Green;
        objetivosTitulos[2].color = Green;
    }

}

