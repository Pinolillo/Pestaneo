using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenClosePergamino : MonoBehaviour
{
    public GameObject objetivos; //Es necesario definir los objetivos de la fase
    public bool pergaminoOpen;

    public GameObject pergaminoFondo;
    public GameObject objetivosTiempos;

    public bool _YaSePresionoBoton = false;

    // Start is called before the first frame update
    void Start()
    {
        pergaminoOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(pergaminoOpen == true)
        {
            PergaminoOpen();
        }
        else
        {
            PergaminoClose();
        }

    }


    public void Pergamino()
    {
        // Detectar que click se ha dado
        if (_YaSePresionoBoton == true)
        {
            // Segundo click
            pergaminoOpen = true; //Abrir pergamino
            _YaSePresionoBoton = false;
        }
        else
        {
            // primer click     
            pergaminoOpen = false; //Cerrar pergamino
            _YaSePresionoBoton = true;
        }
    }

    private void PergaminoClose()
    {
        pergaminoFondo.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.3f, 1, 1));
        transform.position = new Vector3(-4.8f, 0, 0);
        objetivosTiempos.transform.position = new Vector3(0, 1, 0);
        objetivos.SetActive(false);
    }

    private void PergaminoOpen()
    {
        pergaminoFondo.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
        transform.position = new Vector3(4.8f, 0, 0);
        objetivosTiempos.transform.position = new Vector3(0, 0.5f, 0);
        objetivos.SetActive(true);
    }
}
