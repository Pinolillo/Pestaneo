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

        distraction.SetActive(false);

    }
    void Update()
    {
        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();
        Trabajo3();

        //Checar si ganamos
        if (completadas[0] == true && completadas[1] == true && completadas[2])
        {
            //Si gano el jugador if a Escena de victoria
            Debug.Log("Gane");
            SceneManager.LoadScene(13);
        }


        //Checar cuando haya perdido el juego
        if (tiempoTareasController.perder == true)
        {
            SceneManager.LoadScene(16);/*--Ir a esta escena cuando perdamos---*/
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

    }

    private void Trabajo1()
    {

        if (congelamientController.congelarCuarto2 == true)
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
        if (merlinController.inRoom2 == true && progresoController.ProgresosActuales[0] <= 20)
        {
            progresoController.Progresar1();
        }

        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[0] >= 20)
        {
            Ganar1();
        }

        if (merlinController.inRoom2 && desarrollo == true)
        {
            progresoBarrasController[0].BoostedProges();
        }
        else
        {
            progresoBarrasController[0].NormalProgres();
        }

    }

    private void Trabajo2()
    {
        if (congelamientController.congelarCuarto4 == true)
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
        if (merlinController.inRoom4 == true && progresoController.ProgresosActuales[1] <= 20)
        {
            progresoController.Progesar2();

        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[1] >= 20)
        {
            Ganar2();
        }


        if (merlinController.inRoom4 && desarrollo == true)
        {
            progresoBarrasController[1].BoostedProges();
        }
        else
        {
            progresoBarrasController[1].NormalProgres();
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
        }
        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[2] >= 20)
        {
            Ganar3();

            if (isboostavailable == true)
            {
                StartCoroutine(desarrolloPersonal()); //Se vuelve super rápido
            }
        }

        if (merlinController.inRoom3 && desarrollo == true)
        {
            progresoBarrasController[2].BoostedProges();
        }
        else
        {
            progresoBarrasController[2].NormalProgres();
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

