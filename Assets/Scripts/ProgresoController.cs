using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresoController : MonoBehaviour
{

    public float[] ProgresosIniciales; //Es necesario definir los tiempos que tendran los objetivos
    public float[] ProgresosActuales;
    public Text[] textoProgesos;
    public BarraProgreso[] ProgresBar;

    public float progreso;

    public bool sinprogreso;

    // Start is called before the first frame update
    void Start()
    {
        ProgresBar[0].setInitialProgres(ProgresosIniciales[0]);
        ProgresBar[1].setInitialProgres(ProgresosIniciales[1]);
        ProgresBar[2].setInitialProgres(ProgresosIniciales[2]);
        ProgresBar[3].setInitialProgres(ProgresosIniciales[3]);
        ProgresBar[4].setInitialProgres(ProgresosIniciales[4]);

        ProgresosActuales[0] = 0;
        ProgresosActuales[0] = 0;
        ProgresosActuales[0] = 0;
        ProgresosActuales[0] = 0;
        ProgresosActuales[0] = 0;

        progreso = 1f;
    }
    private void Update()
    {
        if(progreso == 0)
        {
            sinprogreso = true;
        }
        else
        {
            sinprogreso = false;
        }
    }

    public void Progresar1()
    {
        //Entra en acción 1
        textoProgesos[0].text = ProgresosActuales[0].ToString("0");
        ProgresosActuales[0] += progreso * Time.deltaTime;
        ProgresBar[0].setProgres(ProgresosActuales[0]);
    }

    public void Progesar2()
    {
        //Entra en acción 2
        textoProgesos[1].text = ProgresosActuales[1].ToString("0");
        ProgresosActuales[1] += progreso * Time.deltaTime;
        ProgresBar[1].setProgres(ProgresosActuales[1]);
    }

    public void Progesar3()
    {
        //Entra en acción 3
        textoProgesos[2].text = ProgresosActuales[2].ToString("0");
        ProgresosActuales[2] += progreso * Time.deltaTime;
        ProgresBar[2].setProgres(ProgresosActuales[2]);
    }

    public void Progesar4()
    {
        //Entra en acción 4
        textoProgesos[3].text = ProgresosActuales[3].ToString("0");
        ProgresosActuales[3] += progreso * Time.deltaTime;
        ProgresBar[3].setProgres(ProgresosActuales[3]);
    }

    public void Progresar5()
    {
        //Entra en acción 5
        textoProgesos[4].text = ProgresosActuales[4].ToString("0");
        ProgresosActuales[4] += progreso * Time.deltaTime;
        ProgresBar[4].setProgres(ProgresosActuales[4]);
    }
}
