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

    public GameObject[] checkmarks;
    public GameObject[] tiempos;
    public GameObject[] fondosCheckmarks;
    public Image[] fondos;

    public bool listo1;
    private bool listo2;

    public Color32 listocolor;

    void Start()
    {
        //Controlamos script de merlin
        merlinController = MerlinControllerObject.GetComponent<MerlinController>();
        //Controlamos script de progreso
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();

        listo1 = false;
        listo2 = false;

        checkmarks[0].SetActive(false);
        checkmarks[1].SetActive(false);
    }
    void Update()
    {
        //Si merlin se encuentra en el cuarto 1 vamos a sumar los puntos
        Trabajo1();
        Trabajo2();
        if (listo1 == true && listo2 == true)
        {
            //Si gano el jugador if a Escena de victoria
            SceneManager.LoadScene(4);
            Debug.Log("Gane");
        }
    }
    private void Trabajo1()
    {
        progresoController.numProgreso[0].text = progresoController.currentProgreso[0].ToString("0");

        if (merlinController.inRoom1 == true && progresoController.currentProgreso[0] <= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + merlinController.progreso * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + merlinController.progreso * Time.deltaTime;
        }
        else if (progresoController.currentProgreso[0] >= 20)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;

            listo1 = true;
            checkmarks[0].SetActive(true);
            tiempos[0].SetActive(false);
            fondosCheckmarks[0].SetActive(false);
            fondos[0].color = listocolor;
        }
        if (merlinController.inRoom1 == false)
        {
            progresoController.currentProgreso[0] = progresoController.currentProgreso[0] + 0 * Time.deltaTime;
            progresoController.barController[0].current = progresoController.barController[0].current + 0 * Time.deltaTime;
        }
    }
    private void Trabajo2()
    {
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
            fondosCheckmarks[1].SetActive(false);
            fondos[1].color = listocolor;
        }
        if (merlinController.inRoom2 == false)
        {
            progresoController.currentProgreso[1] = progresoController.currentProgreso[1] + 0 * Time.deltaTime;
            progresoController.barController[1].current = progresoController.barController[1].current + 0 * Time.deltaTime;

        }
    }

}
