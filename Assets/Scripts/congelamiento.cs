using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class congelamiento : MonoBehaviour
{
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

    private void Start()
    {
        congelamientoPower = 20f;
        activated = false;
    }

    void Update()
    {

        if (activated == false)
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
                        Debug.Log("Tocamos el hechizo");
                    }
                    else
                    {
                        selected = false;
                        Debug.Log("El echizo esta activo pero ahora ya no lo estará");
                    }
                }
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "slot1")
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
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "slot2")
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
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "slot3")
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
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "slot4")
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
                else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "slot5")
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
    }

    //Segunda Parte Tutorial
    IEnumerator CongelamientoActive()
    {
        activated = true;
        yield return new WaitForSeconds(congelamientoPower);
        bola.transform.position = suSlot.transform.position;
        activated = false;
        congelarCuarto1 = false;
        congelarCuarto2 = false;
        congelarCuarto3 = false;
        congelarCuarto4 = false;
        congelarCuarto5 = false;
    }
}
