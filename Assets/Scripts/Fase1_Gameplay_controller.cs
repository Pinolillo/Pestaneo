using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase1_Gameplay_controller : MonoBehaviour
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

    public TiempoTareas tiempoTareasController;
    public GameObject tiempoTareasGameobject;

    public bool[] completadas;

    public GameObject[] barrasProgreso;

    //public barras de desarrollo
    public BarraProgreso[] progresoBarrasController;


    void Start()
    {

        //Controlamos script de merlin
        merlinController = MerlinControllerObject.GetComponent<MerlinController>();

        //Controlamos script de progreso
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();

        //Controlamos el script de tiempos
        tiempoTareasController = tiempoTareasGameobject.GetComponent<TiempoTareas>();

        progresoController.progreso = 1f;

    }
    void Update()
    {
        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();

        //Checar si ganamos
        if (completadas[0] == true && completadas[1])
        {
            //Si gano el jugador if a Escena de victoria
            Debug.Log("Gane");
            SceneManager.LoadScene(12);//Escena victoria 1
        }


        //Checar cuando haya perdido el juego
        if (tiempoTareasController.perder == true)
        {
            SceneManager.LoadScene(1);/*--Ir a esta escena cuando perdamos---*/
        }


    }

    private void Trabajo1()
    {


        //Condicion si se encuentra en el slot 1 y puede trabajar
        if (merlinController.inRoom1 == true && progresoController.ProgresosActuales[0] <= 20)
        {
            progresoController.Progresar1();
        }

        //Si llega a llevar la tarea 1 a 20
        if (progresoController.ProgresosActuales[0] >= 20)
        {
            Ganar1();
        }

    }

    private void Trabajo2()
    {

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

    }

    /*----------Desarrollos personales---------------*/


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

}

