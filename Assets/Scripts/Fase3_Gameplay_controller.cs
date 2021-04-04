using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase3_Gameplay_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject merlin;
    public MerlinController merlinController;
    public GameObject MerlinControllerObject;

    public ProgresoController progresoController;
    public GameObject progresoControllerObject;

    public tiempo_radial_bar[] radialcontroller;

    public GameObject[] tiempos;

    public bool listo1;
    public bool listo2;
    public bool listo3;

    public congelamiento congelamientController;
    public GameObject congelarObject;

    public TiempoTareas tiempoTareasController;
    public GameObject tiempoTareasGameobject;

    //Bool que sirve para boost de desarrollo
    public bool desarrollo;

    //Obtener las barras
    public BarraProgreso barradesarrollo;

    //Mecanica de distraccion
    public bool[] puedeDistraerse;
    public GameObject distraction;

    public bool isboostavailable;

    public GameObject boostProductividad;

    public tiempo_radial_bar RadialControllerBoost;
    public GameObject radialBoostObject;

    public bool[] completadas;

    public GameObject[] barrasProgreso;

    //public barras de desarrollo
    public BarraProgreso[] progresoBarrasController;

    public bool inproductivo;
    public Lechuza lechuzaController;

    public Vector3 merlinpos;
    public Vector3 lechuzapos;

    void Start()
    {
        //Boost
        boostProductividad.SetActive(false);

        //Controlamos script de merlin
        merlinController = MerlinControllerObject.GetComponent<MerlinController>();

        //Controlamos script de progreso
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();

        //Controlamos el script de congelamiento
        congelamientController = congelarObject.GetComponent<congelamiento>();

        //Controlamos el script de tiempos
        tiempoTareasController = tiempoTareasGameobject.GetComponent<TiempoTareas>();

        desarrollo = false;

        barradesarrollo.setInitialProgres(0f);
        barradesarrollo.slider.maxValue = 20f;

        isboostavailable = true;

        //Merlin se puede distraer al inicio
        puedeDistraerse[0] = true;
        puedeDistraerse[1] = true;

        distraction.SetActive(false);

        inproductivo = false;
    }
    void Update()
    {

        merlinpos = merlin.transform.position;


        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();
        Trabajo3();

        //Checar si ganamos
        if (completadas[0] == true && completadas[1] == true && completadas[2])
        {
            //Si gano el jugador if a Escena de victoria
            Debug.Log("Gane");
            SceneManager.LoadScene(14);
        }


        //Checar cuando haya perdido el juego
        if (tiempoTareasController.perder == true)
        {
            SceneManager.LoadScene(17);/*--Ir a esta escena cuando perdamos---*/
        }

        //Productividad mover los distintos estados del progreso

        if (desarrollo == true)
        {
            boostProductividad.SetActive(true);
            progresoController.progreso = 2f;
            RadialControllerBoost.current = RadialControllerBoost.current - 1 * Time.deltaTime;
        }
        else
        {
            boostProductividad.SetActive(false);
            RadialControllerBoost.current = 10f;
            progresoController.progreso = 1f;
        }

        /*--------Distracciones----------*/
        /*---------------------------------*/
        /*---------------------------------*/

        //Condiciones al estar distraido el merlin 
        if (inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                merlinController.readyToPlay = false;
                progresoController.progreso = 0f;
                distraction.transform.position = lechuzapos;// posicion a la lechuza, aquí poner unos frames a la dercha y arriba
            }
            else
            {
                inproductivo = false;
            }
        }

        else
        {
            distraction.SetActive(false);
            lechuzaController.lechuzaVive = false;
            lechuzaController.isnotkilled = false;
        }

        /*---------------------------------*/
        /*---------------------------------*/
        /*--------Distracciones----------*/

    }

    private void Trabajo1()
    {

        if (congelamientController.congelarCuarto1 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            tiempoTareasController.congelandoObjetivo1 = true;
            radialcontroller[0].CongelandoObjetivo();
        }
        else
        {
            tiempoTareasController.congelandoObjetivo1 = false;
            radialcontroller[0].NormalEstate();
        }

        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom1 == true && progresoController.ProgresosActuales[0] <= 20)
        {
            progresoController.Progresar1();
        }

        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[0] >= 20)
        {
            Ganar1();

            if (isboostavailable == true)
            {
                StartCoroutine(desarrolloPersonal()); //Se vuelve super rápido
            }
        }

        if (merlinController.inRoom1 && desarrollo == true)
        {
            progresoBarrasController[0].BoostedProges();
        }
        else
        {
            progresoBarrasController[0].NormalProgres();
        }

        if (merlinController.inRoom1 && inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                progresoBarrasController[0].DistractedProges();
            }
            else
            {
                progresoBarrasController[0].NormalProgres();
            }
        }

    }

    private void Trabajo2()
    {
        if (congelamientController.congelarCuarto2 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            tiempoTareasController.congelandoObjetivo2 = true;
            radialcontroller[1].CongelandoObjetivo();
        }
        else
        {
            tiempoTareasController.congelandoObjetivo2 = false;
            radialcontroller[1].NormalEstate();
        }

        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom2 == true && progresoController.ProgresosActuales[1] <= 20)
        {
            progresoController.Progesar2();

            if (progresoController.ProgresosActuales[1] >= 5)
            {
                if (puedeDistraerse[0] == true)
                {
                    //Iniiciar corrutina de distracción
                    StartCoroutine(Distraccion());
                }
            }

        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[1] >= 20)
        {
            Ganar2();
        }


        if (merlinController.inRoom2 && desarrollo == true)
        {
            progresoBarrasController[1].BoostedProges();
        }
        else
        {
            progresoBarrasController[1].NormalProgres();
        }

        if (merlinController.inRoom2 && inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                progresoBarrasController[1].DistractedProges();
            }
            else
            {
                progresoBarrasController[1].NormalProgres();
            }
        }
    }

    private void Trabajo3()
    {
        if (congelamientController.congelarCuarto3 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            tiempoTareasController.congelandoObjetivo3 = true;
            radialcontroller[2].CongelandoObjetivo();
        }
        else
        {
            tiempoTareasController.congelandoObjetivo3 = false;
            radialcontroller[2].NormalEstate();
        }

        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom3 == true && progresoController.ProgresosActuales[2] <= 20)
        {
            progresoController.Progesar3();

            if (progresoController.ProgresosActuales[2] >= 15)
            {
                if (puedeDistraerse[1] == true)
                {
                    //Iniiciar corrutina de distracción
                    StartCoroutine(Distraccion());
                }
            }

        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[2] >= 20)
        {
            Ganar3();
        }

        if (merlinController.inRoom3 && desarrollo == true)
        {
            progresoBarrasController[2].BoostedProges();
        }
        else
        {
            progresoBarrasController[2].NormalProgres();
        }

        if (merlinController.inRoom3 && inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                progresoBarrasController[2].DistractedProges();
            }
            else
            {
                progresoBarrasController[2].NormalProgres();
            }
        }
    }

    /*----------Desarrollos personales---------------*/

    //Desarrollo peronsal 1
    IEnumerator desarrolloPersonal()
    {
        isboostavailable = false;
        desarrollo = true;

        yield return new WaitForSeconds(10f);//10 Segundos dura la producividad
        desarrollo = false;
    }

    /*----------Distracciones---------------*/

    //Distraccion
    IEnumerator Distraccion()
    {
        inproductivo = true;
        distraction.SetActive(true);
        lechuzaController.lechuzaVive = true;
        lechuzaController.isnotkilled = true;

        lechuzapos = merlinpos + Vector3.left * 1 + Vector3.up * 0.6f; //Obviously don't x1 if you really want 1 :)Ω

        if (merlinController.inRoom2 == true)
        {
            puedeDistraerse[0] = false;
        }
        if (merlinController.inRoom3 == true)
        {
            puedeDistraerse[1] = false;
        }

        yield return new WaitForSeconds(10f);//10 Segundos dura la distraccion

        if (lechuzaController.isnotkilled == true)
        {
            inproductivo = false;
            lechuzaController.isnotkilled = false;
            progresoController.progreso = 1f;
            merlinController.readyToPlay = true;
        }

    }

    /*----------Distracciones---------------*/

    //Ganar
    public void Ganar1()
    {
        tiempoTareasController.listo1 = true;
        completadas[0] = true;
        radialcontroller[0].terminadoObjetivo();
        barrasProgreso[0].SetActive(false);
    }
    public void Ganar2()
    {
        tiempoTareasController.listo2 = true;
        completadas[1] = true;
        radialcontroller[1].terminadoObjetivo();
        barrasProgreso[1].SetActive(false);
    }
    public void Ganar3()
    {
        tiempoTareasController.listo3 = true;
        completadas[2] = true;
        radialcontroller[2].terminadoObjetivo();
        barrasProgreso[2].SetActive(false);
    }

}

