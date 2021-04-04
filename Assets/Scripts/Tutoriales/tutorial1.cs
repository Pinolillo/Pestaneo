using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial1 : MonoBehaviour
{
    public OpenClosePergamino opencloseController;
    public GameObject opencloseObject;

    public GameObject pergaminoContenido;
    public GameObject puntero1;
    public GameObject puntero2;
    public GameObject puntero3;
    public GameObject puntero4;

    public GameObject[] popups;

    public MerlinController merlincontroller;
    public GameObject merlin;

    public int fase;

    public bool primeraparte;
    public bool entramos;

    public Button okboton;
    public GameObject okbutonObject;

    public Button siguienteBoton;
    public GameObject siguienteObjectButton;

    public TiempoTareas fase1controller;
    public GameObject fase1;

    public GameObject checkfake;

    // Start is called before the first frame update
    void Start()
    {
        opencloseController = opencloseObject.GetComponent<OpenClosePergamino>();
        merlincontroller = merlin.GetComponent<MerlinController>();
        fase1controller = fase1.GetComponent<TiempoTareas>();

        pergaminoContenido.SetActive(false);
        puntero1.SetActive(false);
        puntero2.SetActive(false);
        puntero3.SetActive(false);
        puntero4.SetActive(false);

        fase = 0;

        popups[0].SetActive(false);
        popups[1].SetActive(false);
        popups[2].SetActive(false);
        popups[3].SetActive(false);
        popups[4].SetActive(false);

        primeraparte = true;

        okbutonObject.SetActive(false);
        okboton.interactable = false;

        siguienteObjectButton.SetActive(false);
        siguienteBoton.interactable = false;

        merlin.SetActive(false);

        entramos = false;

        checkfake.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Jareta")
            {
                if(primeraparte == true)
                {
                    Debug.Log("Le di pa le di");
                    fase = 2;
                }
                else
                {
                    fase = 3;
                }
            }
        }

        if (merlincontroller.inRoom1 == true)
        {
            if(entramos == false)
            {
                StartCoroutine(Fase10());
            }
        }
        if(fase1controller.listo1 == true)
        {
            fase = 16;
        }

        /*Fases del tutorial*/

        if (fase == 0)
        {
            StartCoroutine(IniciarTutorial());
        }


        if (fase == 1)
        {
            puntero1.SetActive(true);
        }

        if (fase == 2)
        {
            puntero2.SetActive(true);//prender el segundo puntero
            puntero1.SetActive(false);//apagar el segundo puntero
            primeraparte = false;
        }
        if(fase == 3)
        {
            pergaminoContenido.SetActive(true);
            StartCoroutine(PrimerPopup());
            puntero2.SetActive(false);
            puntero1.SetActive(false);
            okbutonObject.SetActive(true);
            StartCoroutine(SetActiveButton());
        }
        if(fase == 4)
        {
            popups[0].SetActive(true);
        }
        if(fase == 5)
        {
            popups[0].SetActive(false);
            popups[1].SetActive(true);
            okboton.interactable = false;
            StartCoroutine(SetActiveButton2());
            checkfake.SetActive(true);
        }
        if(fase == 6)
        {
            checkfake.SetActive(true);
        }
       if(fase == 7)
        {
            okbutonObject.SetActive(false);
            popups[1].SetActive(false);
            opencloseController.pergaminoOpen = false;
            merlin.SetActive(true);
            StartCoroutine(merlinAparece());
            siguienteObjectButton.SetActive(true);
            checkfake.SetActive(false);
        }
        if (fase == 8)
        {
            popups[2].SetActive(true);
            siguienteBoton.interactable = true;
        }
       if(fase == 9)
        {
            popups[2].SetActive(false);
            siguienteObjectButton.SetActive(false);
            puntero3.SetActive(true);
            merlincontroller.readyToPlay = true;
        }
       if(fase == 10)
        {
            puntero3.SetActive(false);
            popups[2].SetActive(false);
            StartCoroutine(PropgressPop());
        }
       if(fase == 11)
        {
            popups[3].SetActive(true);
            okbutonObject.SetActive(true);
            okboton.interactable = false;
            StartCoroutine(fase12Viene());
        }
       if(fase == 12)
        {
            okboton.interactable = true;
        }
       if(fase == 13)
        {
            popups[3].SetActive(false);
            popups[4].SetActive(true);
            okboton.interactable = false;
            StartCoroutine(fase14Viene());
        }
       if(fase == 14)
        {
            okboton.interactable = true;
        }
       if(fase == 15)
        {
            okbutonObject.SetActive(false);
            popups[4].SetActive(false);
        }
       if(fase == 16)
        {
            puntero4.SetActive(true);
        }
       if(merlincontroller.inRoom2 == true)
        {
            puntero4.SetActive(false);
        }

    }

    public void TutorialFasesBoton()
    {
        if(fase == 4)
        {
            fase = 5;
        }
        if(fase == 6)
        {
            fase = 7;
        }
        if(fase == 12)
        {
            fase = 13;
        }
        if(fase == 14)
        {
            fase = 15;
        }
    }

    public void TutorialFase2Boton()
    {
        if(fase == 8)
        {
            fase = 9;
        }
    }

    IEnumerator IniciarTutorial()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 1;
    }
    IEnumerator PrimerPopup()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 4;
    }
    IEnumerator SetActiveButton()
    {
        yield return new WaitForSeconds(4f);//10 Segundos dura la distraccion
        okboton.interactable = true;
    }
    IEnumerator SetActiveButton2()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        okboton.interactable = true;
        fase = 6;
    }
    IEnumerator merlinAparece()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 8;
    }
    IEnumerator Fase10()
    {
        fase = 10;
        entramos = true;
        yield return new WaitForSeconds(0f);//10 Segundos dura la distraccion
    }
    IEnumerator PropgressPop()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 11;
    }

    IEnumerator fase12Viene()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 12;
    }

    IEnumerator fase14Viene()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 14;
    }
}
