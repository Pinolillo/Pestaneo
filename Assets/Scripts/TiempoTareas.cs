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
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        TimeposActualesObjetivos[0] = TiemposInicialesObjetivos[0];
        TimeposActualesObjetivos[1] = TiemposInicialesObjetivos[1];
        TimeposActualesObjetivos[2] = TiemposInicialesObjetivos[2];
        TimeposActualesObjetivos[3] = TiemposInicialesObjetivos[3];
        TimeposActualesObjetivos[4] = TiemposInicialesObjetivos[4];

        objetivobarra[0].setInitialDuration(TiemposInicialesObjetivos[1]);
        objetivobarra[1].setInitialDuration(TiemposInicialesObjetivos[2]);
        objetivobarra[2].setInitialDuration(TiemposInicialesObjetivos[2]);
        objetivobarra[3].setInitialDuration(TiemposInicialesObjetivos[3]);
        objetivobarra[4].setInitialDuration(TiemposInicialesObjetivos[4]);

        start = false;
    }

    private void Tiempo1()
    {
        textoObjetivos[0].text = TimeposActualesObjetivos[0].ToString("0");
        TimeposActualesObjetivos[0] -= 1 * Time.deltaTime;
        objetivobarra[0].setDuration(TimeposActualesObjetivos[0]);
    }

    private void Tiempo2()
    {
        textoObjetivos[1].text = TimeposActualesObjetivos[1].ToString("0");
        TimeposActualesObjetivos[1] -= 1 * Time.deltaTime;
        objetivobarra[1].setDuration(TimeposActualesObjetivos[1]);
    }
    private void Tiempo3()
    {
        textoObjetivos[2].text = TimeposActualesObjetivos[2].ToString("0");
        TimeposActualesObjetivos[2] -= 1 * Time.deltaTime;
        objetivobarra[2].setDuration(TimeposActualesObjetivos[2]);
    }
    private void Tiempo4()
    {
        textoObjetivos[3].text = TimeposActualesObjetivos[3].ToString("0");
        TimeposActualesObjetivos[3] -= 1 * Time.deltaTime;
        objetivobarra[3].setDuration(TimeposActualesObjetivos[3]);
    }
    private void Tiempo5()
    {
        textoObjetivos[4].text = TimeposActualesObjetivos[4].ToString("0");
        TimeposActualesObjetivos[4] -= 1 * Time.deltaTime;
        objetivobarra[4].setDuration(TimeposActualesObjetivos[4]);
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true)
        {
            StartPlay();
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