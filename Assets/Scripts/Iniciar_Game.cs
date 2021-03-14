using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iniciar_Game : MonoBehaviour
{

    public TiempoTareas tiempoTareas;
    public GameObject TareasController;

    public GameObject Jareta;//La del inicio

    public bool comenzogame;

    public float contadorInical;
    public Text textodecontadorInnicial;

    public GameObject panelInicial;

    public bool firstTouch;

    // Start is called before the first frame update
    void Start()
    {
        contadorInical = 5;
        textodecontadorInnicial.text = contadorInical.ToString("0");
        panelInicial.SetActive(false);
        firstTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstTouch == false)
        {
            //Iniciar tutorial al darle click a la jareta
            if (comenzogame == false)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Jareta")
                    {
                        StartCoroutine(IniciarJuego());
                        comenzogame = true;
                    }
                }
            }
        }
        if (comenzogame == true)
        {
            panelInicial.SetActive(true);
            textodecontadorInnicial.text = contadorInical.ToString("0");
            contadorInical -= 1 * Time.deltaTime;
        }
    }

    IEnumerator IniciarJuego()
    {
        //Comienza el demo de congelamiento
        yield return new WaitForSeconds(5f);
        firstTouch = true;
        tiempoTareas.GetComponent<TiempoTareas>().startPlay = true;
        panelInicial.SetActive(false);
        comenzogame = false;
    }
}
