using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase4_Gameplay_controller : MonoBehaviour
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
    public bool listo4;
    public bool listo5;

    public congelamiento congelamientController;
    public GameObject congelarObject;

    public TiempoTareas tiempoTareasController;
    public GameObject tiempoTareasGameobject;

    //Bool que sirve para boost de desarrollo
    public bool desarrollo;

    //Obtener las barras
    public BarraProgreso barradesarrollo;

    //Mecanica de distraccion
    public bool puedeDistraerse;
    public bool puedeDistraerse2;
    public GameObject distraction;

    public bool isboostavailable;
    public bool isboostavailable2;

    public GameObject boostProductividad;

    public tiempo_radial_bar RadialControllerBoost;
    public GameObject radialBoostObject;

    public bool[] completadas;

    public GameObject[] barrasProgreso;

    //public barras de desarrollo
    public BarraProgreso[] progresoBarrasController;

    public bool inproductivo;
    public Lechuza lechuzaController;

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
        isboostavailable2 = true;


        //Merlin se puede distraer al inicio
        puedeDistraerse = true;
        distraction.SetActive(false);
        puedeDistraerse2 = true;

        inproductivo = false;
    }
    void Update()
    {
        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();
        Trabajo3();
        Trabajo4();
        Trabajo5();

        //Checar si ganamos
        if (completadas[0] == true && completadas[1] == true && completadas[2] == true && completadas[3] == true && completadas[4] == true)
        {
            //Si gano el jugador if a Escena de victoria
            Debug.Log("Gane");
            SceneManager.LoadScene(15);
        }


        //Checar cuando haya perdido el juego
        if (tiempoTareasController.perder == true)
        {
            SceneManager.LoadScene(14);
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

        
        if(inproductivo == true)
        {
            if(lechuzaController.lechuzaVive == true)
            {
                progresoController.progreso = 0f;
                distraction.SetActive(true);
                merlinController.readyToPlay = false;
                distraction.transform.position = merlin.transform.position;
            }
            if(lechuzaController.lechuzaVive == false)
            {
                distraction.SetActive(false);
                progresoController.progreso = 1f;
            }
        }
        
        if(inproductivo == false)
        {
            distraction.SetActive(false);
        }

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

            if (progresoController.ProgresosActuales[0] >= 15)
            {
                //Iniiciar corrutina de distracción
                StartCoroutine(Distraccion());
            }

        }

        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[0] >= 20)
        {
            Ganar1();
        }

        if(merlinController.inRoom1 && desarrollo == true)
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

            if (progresoController.ProgresosActuales[2] >= 5)
            {
                    //Iniiciar corrutina de distracción
                    StartCoroutine(Distraccion());
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

    private void Trabajo4()
    {
        if (congelamientController.congelarCuarto4 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            tiempoTareasController.congelandoObjetivo4 = true;
            radialcontroller[3].CongelandoObjetivo();
        }
        else
        {
            tiempoTareasController.congelandoObjetivo4 = false;
            radialcontroller[3].NormalEstate();
        }

        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom4 == true && progresoController.ProgresosActuales[3] <= 20)
        {
            progresoController.Progesar4();
        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[3] >= 20)
        {
            Ganar4();

            if (isboostavailable == true)
            {
                StartCoroutine(desarrolloPersonal()); //Se vuelve super rápido
            }
        }

        if (merlinController.inRoom4 && desarrollo == true)
        {
            progresoBarrasController[3].BoostedProges();
        }
        else
        {
            progresoBarrasController[3].NormalProgres();
        }

        if (merlinController.inRoom4 && inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                progresoBarrasController[3].DistractedProges();
            }
            else
            {
                progresoBarrasController[3].NormalProgres();
            }
        }
    }

    private void Trabajo5()
    {
        if (congelamientController.congelarCuarto5 == true)
        {
            //parar el trabajo aquí y cambiar el color aquí
            tiempoTareasController.congelandoObjetivo5 = true;
            radialcontroller[4].CongelandoObjetivo();
        }
        else
        {
            tiempoTareasController.congelandoObjetivo5 = false;
            radialcontroller[4].NormalEstate();
        }

        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom5 == true && progresoController.ProgresosActuales[4] <= 20)
        {
            progresoController.Progresar5();
        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[4] >= 20)
        {
            Ganar5();
        }

        if (merlinController.inRoom5 && desarrollo == true)
        {
            progresoBarrasController[4].BoostedProges();
        }
        else
        {
            progresoBarrasController[4].NormalProgres();
        }

        if (merlinController.inRoom5 && inproductivo == true)
        {
            if (lechuzaController.lechuzaVive == true)
            {
                progresoBarrasController[4].DistractedProges();
            }
            else
            {
                progresoBarrasController[4].NormalProgres();
            }
        }
    }


    //Desarrollo peronsal 1
    IEnumerator desarrolloPersonal()
    {
        isboostavailable = false;
        desarrollo = true;

        yield return new WaitForSeconds(10f);//10 Segundos dura la producividad
        desarrollo = false;
    }


    //Distraccion
    IEnumerator Distraccion()
    {
        inproductivo = true;
        yield return new WaitForSeconds(10f);//10 Segundos dura la distraccion
        //puedeDistraerse = false;
        inproductivo = false;
        merlinController.readyToPlay = true;
        lechuzaController.lechuzaVive = false;
    }

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
    public void Ganar4()
    {
        tiempoTareasController.listo4 = true;
        completadas[3] = true;
        radialcontroller[3].terminadoObjetivo();
        barrasProgreso[3].SetActive(false);
    }
    public void Ganar5()
    {
        tiempoTareasController.listo5 = true;
        completadas[4] = true;
        radialcontroller[4].terminadoObjetivo();
        barrasProgreso[4].SetActive(false);
    }

}

