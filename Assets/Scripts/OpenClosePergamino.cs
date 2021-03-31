using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenClosePergamino : MonoBehaviour
{
    public GameObject objetivos; //Es necesario definir los objetivos de la fase
    public bool pergaminoOpen;

    public MerlinController merlinController;
    public Iniciar_Game iniciarController;

    public GameObject pergaminoFondo;
    public GameObject pergaminocerrado;

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
            merlinController.GetComponent<MerlinController>().readyToPlay = false;
        }
        else
        {
            PergaminoClose();
            if (iniciarController.GetComponent<Iniciar_Game>().istutorial == false)
            {
                merlinController.GetComponent<MerlinController>().readyToPlay = true;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Jareta")
            {
                Pergamino();
            }
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
        pergaminoFondo.SetActive(false);
        pergaminocerrado.SetActive(true);
    }

    private void PergaminoOpen()
    {
        pergaminoFondo.SetActive(true);
        pergaminocerrado.SetActive(false);
    }
}
