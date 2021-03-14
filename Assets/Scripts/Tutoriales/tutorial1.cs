using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class tutorial1 : MonoBehaviour
{
    public GameObject popup1; //Primer popup
    public GameObject popup2; //Segundo popup
    public GameObject popup3; //Tercer pop up

    public Button okButton; //Obtener el boton el cual se presiona para avanzar

    public float showPopUP = 5f;//Se esperan x Segundos para que el pop up 1 se prenda
    public float showButton = 7f;//Se esperan x segundos y el boton ya no es transparente y es interactuable
    public float showButton2 = 3f;//Se esperan x desde que se presiono por primera vez el boton para reinciar el cilco

    private bool _YaSePresionoBoton = false;

    public GameObject check1;

    // Start is called before the first frame update
    void Start()
    {
        okButton.interactable = false;//El boton al inicio no es interactuable

        popup1.SetActive(false);
        popup2.SetActive(false);
        popup3.SetActive(false);

        StartCoroutine(LlamarPrimerPopup());
        StartCoroutine(LlamarAlBoton());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Tutorial1()
    {
        // Detectar que click se ha dado
        if (_YaSePresionoBoton)
        {
            // Segundo Click
            popup2.SetActive(false);
            okButton.gameObject.SetActive(false);//Deshablitar el boton por completo, bye
            _YaSePresionoBoton = false;
            popup3.SetActive(true);
            check1.SetActive(false);
        }
        else
        {
            // primer click
            popup1.SetActive(false);//pop up 1 desaparece 
            popup2.SetActive(true); //y aparce el pop up 2
            StartCoroutine(LlamarPorSegundaVezAlBoton());
            _YaSePresionoBoton = true;
            check1.SetActive(true);
        }
    }

    //Esperar al popup
    IEnumerator LlamarPrimerPopup()
    {
        yield return new WaitForSeconds(showPopUP);
        popup1.SetActive(true);//Primer pop up true
    }
    //Esperar al boton
    IEnumerator LlamarAlBoton()
    {
        yield return new WaitForSeconds(showButton);
        okButton.interactable = true;//El boton ahora es interactuable
    }
    //Segunda Parte Tutorial
    IEnumerator LlamarPorSegundaVezAlBoton()
    {
        okButton.interactable = false;//El boton ahora es interactuable
        yield return new WaitForSeconds(showButton2);
        okButton.interactable = true;//El boton ahora es interactuable
    }
}
