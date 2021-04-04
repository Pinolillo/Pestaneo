using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial2 : MonoBehaviour
{
    public int fase;

    public GameObject puntero1;
    public GameObject putnero2;
    public GameObject puntero3;

    public congelamiento congelmaientoController;
    public GameObject hechizo;

    public TiempoTareas tiempoController;
    public GameObject tiempoObject;

    public OpenClosePergamino pergaminoController;
    public ProgresoController progresoController;

    public GameObject merlin;
    public MerlinController merlinCont;

    public bool istutorial;
    public bool iscongelando;
    public bool primeraparte;

    public bool seestacongelando;
    public bool etaveloz;
    public bool llegandoal3;
    public bool yasevolviochido;

    public GameObject[] Popups;

    public Button OkButton;
    public GameObject okObject;

    public GameObject fondoRectangle;

    public Button sigButton;
    public GameObject sigObject;

    public bool llegandoal2;

    // Start is called before the first frame update
    void Start()
    {
        fase = 0;
        puntero1.SetActive(false);
        putnero2.SetActive(false);
        puntero3.SetActive(false);

        merlin.SetActive(false);

        istutorial = true;
        iscongelando = true;
        primeraparte = true;
        seestacongelando = false;
        fondoRectangle.SetActive(false);

        sigObject.SetActive(false);
        sigButton.interactable = false;
        llegandoal2 = false;

        etaveloz = false;
        llegandoal3 = false;
        yasevolviochido = false;
        llegandoal2 = true;

        okObject.SetActive(false);

        congelmaientoController = hechizo.GetComponent<congelamiento>();
        tiempoController = tiempoObject.GetComponent<TiempoTareas>();
        pergaminoController = tiempoObject.GetComponent<OpenClosePergamino>();
        progresoController = tiempoObject.GetComponent<ProgresoController>();
        merlinCont = merlin.GetComponent<MerlinController>();


        Popups[0].SetActive(false);
        Popups[1].SetActive(false);
        Popups[2].SetActive(false);
        Popups[3].SetActive(false);
        Popups[4].SetActive(false);
        Popups[5].SetActive(false);
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
                if (primeraparte == true)
                {
                    fase = 1;
                }
            }
        }

        if (istutorial == true)
        {
            if(congelmaientoController.hechizo.color == congelmaientoController.selectedColor)
            {
                fase = 3;
                istutorial = false;
            }
        }

        if(iscongelando == true)
        {
            if (congelmaientoController.congelarCuarto3 == true)
            {
                fase = 4;
                iscongelando = false;
                seestacongelando = true;
            }
        }

        if(merlinCont.inRoom3 == true)
        {
            if(llegandoal3 == false)
            {
                llegandoal3 = true;
            }
            if(llegandoal3 == true)
            {
                fase = 14;
            }
        }

        if(yasevolviochido == false)
        {
            if (progresoController.progreso == 2)
            {
                fase = 15;
                yasevolviochido = true;
            }
        }

        if (seestacongelando == true && congelmaientoController.activated == false)
        {
            StartCoroutine(Fase6());
        }

        if(merlinCont.inRoom2 == true)
        {
            if(llegandoal2 == true)
            {
                StartCoroutine(fase16());
            }
        }

        if (progresoController.progreso == 1)
        {
            if(yasevolviochido == true)
            {
                fase = 17;
            }
        }

        /*Fases*/

        if (fase == 1)
        {
            StartCoroutine(IniciarSegundoTuto());
        }
        if (fase == 2)
        {
            puntero1.SetActive(true);
        }
        if(fase == 3)
        {
            puntero1.SetActive(false);
            putnero2.SetActive(true);
        }
        if(fase == 4)
        {
            puntero1.SetActive(false);
            putnero2.SetActive(false);
            StartCoroutine(Fase5());
        }
        if(fase == 5)
        {
            puntero1.SetActive(false);
            Popups[0].SetActive(true);
        }
        if(fase == 6)
        {
            puntero1.SetActive(false);
            Popups[0].SetActive(false);
            Popups[1].SetActive(true);
            tiempoController.startPlay = false;
            OkButton.interactable = false;
            okObject.SetActive(true);
            StartCoroutine(Fase7());
        }
        if(fase == 8)
        {
            Popups[1].SetActive(false);
            pergaminoController.pergaminoOpen = true;
            OkButton.interactable = false;
            StartCoroutine(Fase9());
        }

        if(fase == 9)
        {
            Popups[2].SetActive(true);
            fondoRectangle.SetActive(true);
        }
        if(fase == 10)
        {
            Popups[2].SetActive(false);
            Popups[3].SetActive(true);
            OkButton.interactable = false;
            StartCoroutine(Fase11());
        }
        if(fase == 11)
        {
            OkButton.interactable = true;
        }
        if(fase == 12)
        {
            Popups[3].SetActive(false);
            okObject.SetActive(false);
            pergaminoController.pergaminoOpen = false;
            StartCoroutine(Puntero2());
        }
        if(fase == 13)
        {
            putnero2.SetActive(true);
            merlin.SetActive(true);
            merlinCont.readyToPlay = true;
        }
        if(fase == 14)
        {
            putnero2.SetActive(false);
        }
        if(fase == 15)
        {
            Popups[4].SetActive(true);
            puntero3.SetActive(true);
        }
        if(fase == 16)
        {
            puntero3.SetActive(false);
        }
        if(fase == 17)
        {
            Popups[4].SetActive(false);
            Popups[5].SetActive(true);
            sigObject.SetActive(true);
            StartCoroutine(Finalizando());
        }
    }

    /*Boton accciones*/
    public void ButtonActions()
    {
        if(fase == 7)
        {
            fase = 8;
        }
        if(fase == 9)
        {
            fase = 10;
        }
        if(fase == 11)
        {
            fase = 12;
        }
        if(fase == 18)
        {
            SceneManager.LoadScene(6);
        }
    }

    IEnumerator IniciarSegundoTuto()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 2;
        primeraparte = false;
    }
    IEnumerator Fase5()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 5;
    }
    IEnumerator Fase6()
    {
        yield return new WaitForSeconds(1f);//10 Segundos dura la distraccion
        seestacongelando = false;
        fase = 6;
    }
    IEnumerator Fase7()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        OkButton.interactable = true;
        fase = 7;
    }
    IEnumerator Fase9()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        OkButton.interactable = true;
        fase = 9;
    }
    IEnumerator Fase11()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 11;
    }
    IEnumerator Puntero2()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        fase = 13;
    }
    IEnumerator fase16()
    {
        yield return new WaitForSeconds(1f);//10 Segundos dura la distraccion
        fase = 16;
        llegandoal2 = false;
    }

    IEnumerator Finalizando()
    {
        yield return new WaitForSeconds(2f);//10 Segundos dura la distraccion
        sigButton.interactable = true;
        fase = 18;
    }
}
