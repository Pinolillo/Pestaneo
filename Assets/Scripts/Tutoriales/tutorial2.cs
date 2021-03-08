using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial2 : MonoBehaviour
{
    public GameObject popup3;
    public GameObject popup4;
    public GameObject jareta;
    public GameObject okbutton2;
    public Button okButton2;
    private bool istutorial;
    public float showButton2;


    // Start is called before the first frame update
    void Start()
    {
        popup4.SetActive(false);
        okbutton2.SetActive(false);
        istutorial = true;
        showButton2 = 3f; //Se esperaran x segundos para llamar al segundo boton a activarse
        okButton2.interactable = false;//El boton empeiza siendo no interactuable
    }

    //Corrutina del boton 2
    IEnumerator LlamarAlBoton2()
    {
        yield return new WaitForSeconds(showButton2);
        okButton2.interactable = true;//El boton ahora es interactuable
    }

    void Update()
    {
        if(istutorial == true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "Jareta")
                {
                    Debug.Log("Tocamos Jareta");
                    popup3.SetActive(false);
                    popup4.SetActive(true);
                    okbutton2.SetActive(true);
                    istutorial = false;
                    StartCoroutine(LlamarAlBoton2());//Al inicio llamarlo 
                }
            }
        }
    }
}
