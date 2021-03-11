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
    public BarraProgreso[] objetivobarra;

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

    // Start is called before the first frame update
    void Start()
    {
        TimeposActualesObjetivos[0] = TiemposInicialesObjetivos[0];
        TimeposActualesObjetivos[1] = TiemposInicialesObjetivos[1];
        TimeposActualesObjetivos[2] = TiemposInicialesObjetivos[2];
        TimeposActualesObjetivos[3] = TiemposInicialesObjetivos[3];
        TimeposActualesObjetivos[4] = TiemposInicialesObjetivos[4];

        objetivobarra[0].setInitialDuration(TiemposInicialesObjetivos[0]);
        objetivobarra[1].setInitialDuration(TiemposInicialesObjetivos[1]);
        objetivobarra[2].setInitialDuration(TiemposInicialesObjetivos[2]);
        objetivobarra[3].setInitialDuration(TiemposInicialesObjetivos[3]);
        objetivobarra[4].setInitialDuration(TiemposInicialesObjetivos[4]);

        congelandoObjetivo1 = false;
        congelandoObjetivo2 = false;
        congelandoObjetivo3 = false;
        congelandoObjetivo4 = false;
        congelandoObjetivo5 = false;

        perder = false;
        listo1 = false;
        listo2 = false;
        listo3 = false;
        listo4 = false;
        listo5 = false;
    }

    public void Tiempo1()
    {
        if(listo1 == false)
        {
            if (congelandoObjetivo1 == false)
            {
                textoObjetivos[0].text = TimeposActualesObjetivos[0].ToString("0");
                TimeposActualesObjetivos[0] -= 1 * Time.deltaTime;
                objetivobarra[0].setDuration(TimeposActualesObjetivos[0]);
                if (TimeposActualesObjetivos[0] <= 0)
                {
                    perder = true;
                }
            }
        }
    }

    public void Tiempo2()
    {
        if(listo2 == false)
        {
            if (congelandoObjetivo2 == false)
            {
                textoObjetivos[1].text = TimeposActualesObjetivos[1].ToString("0");
                TimeposActualesObjetivos[1] -= 1 * Time.deltaTime;
                objetivobarra[1].setDuration(TimeposActualesObjetivos[1]);
                if (TimeposActualesObjetivos[1] <= 0)
                {
                    perder = true;
                }
            }
        }
    }
    public void Tiempo3()
    {
        if(listo3 == false)
        {
            if (congelandoObjetivo3 == false)
            {
                textoObjetivos[2].text = TimeposActualesObjetivos[2].ToString("0");
                TimeposActualesObjetivos[2] -= 1 * Time.deltaTime;
                objetivobarra[2].setDuration(TimeposActualesObjetivos[2]);
                if (TimeposActualesObjetivos[2] <= 0)
                {
                    perder = true;
                }
            }
        }
    }
    public void Tiempo4()
    {
        if(listo4 == false)
        {
            if (congelandoObjetivo4 == false)
            {
                textoObjetivos[3].text = TimeposActualesObjetivos[3].ToString("0");
                TimeposActualesObjetivos[3] -= 1 * Time.deltaTime;
                objetivobarra[3].setDuration(TimeposActualesObjetivos[3]);
                if (TimeposActualesObjetivos[3] <= 0)
                {
                    perder = true;
                }
            }
        }
    }
    public void Tiempo5()
    {
        if(listo5 == false)
        {
            if (congelandoObjetivo5 == false)
            {
                textoObjetivos[4].text = TimeposActualesObjetivos[4].ToString("0");
                TimeposActualesObjetivos[4] -= 1 * Time.deltaTime;
                objetivobarra[4].setDuration(TimeposActualesObjetivos[4]);
                if (TimeposActualesObjetivos[4] <= 0)
                {
                    perder = true;
                }
            }
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