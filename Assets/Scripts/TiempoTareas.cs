using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiempoTareas : MonoBehaviour
{

    public float[] TiemposInicialesObjetivos; //Es necesario definir los tiempos que tendran los objetivos
    public float[] TimeposActualesObjetivos; 
    public Text[] textoObjetivos;

    //Controlar script de barras radiales
    public tiempo_radial_bar[] RadialController;
    public GameObject[] radialBarObject;

    public bool startPlay;

    public bool congelandoObjetivo1;
    public bool congelandoObjetivo2;
    public bool congelandoObjetivo3;
    public bool congelandoObjetivo4;
    public bool congelandoObjetivo5;

    public bool perder;
    public bool listo1;
    public bool listo2;
    public bool listo3;
    public bool listo4;
    public bool listo5;

    public bool estamosCongelando;

    public GameObject[] checkmarks;

    // Start is called before the first frame update
    void Start()
    {
        TimeposActualesObjetivos[0] = TiemposInicialesObjetivos[0];
        TimeposActualesObjetivos[1] = TiemposInicialesObjetivos[1];
        TimeposActualesObjetivos[2] = TiemposInicialesObjetivos[2];
        TimeposActualesObjetivos[3] = TiemposInicialesObjetivos[3];
        TimeposActualesObjetivos[4] = TiemposInicialesObjetivos[4];

        RadialController[0] = radialBarObject[0].GetComponent<tiempo_radial_bar>();
        RadialController[1] = radialBarObject[1].GetComponent<tiempo_radial_bar>();
        RadialController[2] = radialBarObject[2].GetComponent<tiempo_radial_bar>();
        RadialController[3] = radialBarObject[3].GetComponent<tiempo_radial_bar>();
        RadialController[4] = radialBarObject[4].GetComponent<tiempo_radial_bar>();

        congelandoObjetivo1 = false;
        congelandoObjetivo2 = false;
        congelandoObjetivo3 = false;
        congelandoObjetivo4 = false;
        congelandoObjetivo5 = false;

        estamosCongelando = false;

        perder = false;
        listo1 = false;
        listo2 = false;
        listo3 = false;
        listo4 = false;
        listo5 = false;

        checkmarks[0].SetActive(false);
        checkmarks[1].SetActive(false);
        checkmarks[2].SetActive(false);
        checkmarks[3].SetActive(false);
        checkmarks[4].SetActive(false);
    }

    public void Tiempo1()
    {
        if (listo1 == false)
        {
            checkmarks[0].SetActive(false);
            if (congelandoObjetivo1 == false)
            {
                textoObjetivos[0].text = TimeposActualesObjetivos[0].ToString("0");
                TimeposActualesObjetivos[0] -= 1 * Time.deltaTime;
                RadialController[0].current = RadialController[0].current - 1 * Time.deltaTime;
                if (TimeposActualesObjetivos[0] <= 0)
                {
                    perder = true;
                }
            }
        }
        else
        {
            checkmarks[0].SetActive(true);
        }
    }

    public void Tiempo2()
    {
        if (listo2 == false)
        {
            checkmarks[1].SetActive(false);
            if (congelandoObjetivo2 == false)
            {
                textoObjetivos[1].text = TimeposActualesObjetivos[1].ToString("0");
                TimeposActualesObjetivos[1] -= 1 * Time.deltaTime;
                RadialController[1].current = RadialController[1].current - 1 * Time.deltaTime;
                if (TimeposActualesObjetivos[1] <= 0)
                {
                    perder = true;
                }
            }
        }
        else
        {
            checkmarks[1].SetActive(true);
        }
    }
    public void Tiempo3()
    {
        if (listo3 == false)
        {
            checkmarks[2].SetActive(false);

            if (congelandoObjetivo3 == false)
            {
                textoObjetivos[2].text = TimeposActualesObjetivos[2].ToString("0");
                TimeposActualesObjetivos[2] -= 1 * Time.deltaTime;
                RadialController[2].current = RadialController[2].current - 1 * Time.deltaTime;
                if (TimeposActualesObjetivos[2] <= 0)
                {
                    perder = true;
                }
            }
        }
        else
        {
            checkmarks[2].SetActive(true);
        }
    }

    public void Tiempo4()
    {
        if (listo4 == false)
        {
            checkmarks[3].SetActive(false);

            if (congelandoObjetivo4 == false)
            {
                textoObjetivos[3].text = TimeposActualesObjetivos[3].ToString("0");
                TimeposActualesObjetivos[3] -= 1 * Time.deltaTime;
                RadialController[3].current = RadialController[3].current - 1 * Time.deltaTime;
                if (TimeposActualesObjetivos[3] <= 0)
                {
                    perder = true;
                }
            }
        }
        else
        {
            checkmarks[3].SetActive(true);
        }
    }
    public void Tiempo5()
    {
        if (listo5 == false)
        {
            checkmarks[4].SetActive(false);
            if (congelandoObjetivo5 == false)
            {
                textoObjetivos[4].text = TimeposActualesObjetivos[4].ToString("0");
                TimeposActualesObjetivos[4] -= 1 * Time.deltaTime;
                RadialController[4].current = RadialController[4].current - 1 * Time.deltaTime;
                if (TimeposActualesObjetivos[4] <= 0)
                {
                    perder = true;
                }
            }
        }
        else
        {
            checkmarks[4].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startPlay == true)
        {
            StartPlay();
        }
        else{

        }
    }
    public void StartPlay()
    {
        Tiempo1();
        Tiempo2();
        Tiempo3();
        Tiempo4();
        Tiempo5();
    }
}