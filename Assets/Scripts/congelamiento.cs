using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class congelamiento : MonoBehaviour
{
    public AudioSource select;
    public AudioSource audioCongelado;
    public AudioSource soundReturn;

    public bool taped;

    public bool selected;
    public GameObject bola;

    public GameObject[] slots;

    public float congelamientoPower;
    public GameObject suSlot;

    public bool activated;

    public bool congelarCuarto1;
    public bool congelarCuarto2;
    public bool congelarCuarto3;
    public bool congelarCuarto4;
    public bool congelarCuarto5;

    public Color32 normalColor;
    public Color32 selectedColor;
    public Image hechizo;

    public GameObject textos;

    public Text powertext;

    public GameObject habitaciones;
    public GameObject flags;


    private void Start()
    {
        congelamientoPower = 20f;

        activated = false;
        taped = false;

        textos.SetActive(false);
        flags.SetActive(false);
    }

    void Update()
    {
        //Al dar click sobre el hechizo se cambia su color para dar retroalimentación al usuario
        if(selected == true)
        {
            hechizo.color = selectedColor;
            flags.SetActive(true);
            habitaciones.SetActive(false);
        }
        else
        {
            hechizo.color = normalColor;
            flags.SetActive(false);
            habitaciones.SetActive(true);
        }

        if(activated == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "congelamiento")
                {
                    if (selected == false)
                    {
                        selected = true;
                        select.Play();
                        Debug.Log("Tocamos el hechizo");
                    }
                    else
                    {
                        selected = false;
                        Debug.Log("El echizo esta activo pero ahora ya no lo estará");
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "flag1")
                {
                    Debug.Log("Estoy tocando cuarto1");
                    if (selected == true)
                    {
                        bola.transform.position = slots[0].transform.position;
                        selected = false;
                        StartCoroutine(CongelamientoActive());
                        congelarCuarto1 = true;
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "flag2")
                {
                    Debug.Log("Estoy tocando cuarto2");
                    if (selected == true)
                    {
                        bola.transform.position = slots[1].transform.position;
                        selected = false;
                        StartCoroutine(CongelamientoActive());
                        congelarCuarto2 = true;
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "flag3")
                {
                    Debug.Log("Estoy tocando cuarto3");
                    if (selected == true)
                    {
                        bola.transform.position = slots[2].transform.position;
                        selected = false;
                        StartCoroutine(CongelamientoActive());
                        congelarCuarto3 = true;
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "flag4")
                {
                    Debug.Log("Estoy tocando cuarto4");
                    if (selected == true)
                    {
                        bola.transform.position = slots[3].transform.position;
                        selected = false;
                        StartCoroutine(CongelamientoActive());
                        congelarCuarto4 = true;
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "flag5")
                {
                    Debug.Log("Estoy tocando cuarto5");
                    if (selected == true)
                    {
                        bola.transform.position = slots[4].transform.position;
                        selected = false;
                        StartCoroutine(CongelamientoActive());
                        congelarCuarto5 = true;
                    }
                }
            }
        }


        //Esta activo el poder
        if (activated == true)
        {
            Countdown();
        }
    }

    //Congelamiento activo
    IEnumerator CongelamientoActive()
    {
        activated = true;
        textos.SetActive(true);
        audioCongelado.Play();

        yield return new WaitForSeconds(congelamientoPower);

        soundReturn.Play();

        bola.transform.position = suSlot.transform.position;
        activated = false;
        textos.SetActive(false);

        congelarCuarto1 = false;
        congelarCuarto2 = false;
        congelarCuarto3 = false;
        congelarCuarto4 = false;
        congelarCuarto5 = false;

        congelamientoPower = 20f;
    }

    public void Countdown()
    {
        powertext.text = congelamientoPower.ToString("0");
        congelamientoPower -= 1 * Time.deltaTime;
    }
}
