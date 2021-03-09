using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerlinController : MonoBehaviour
{

    public bool selected;
    public GameObject merlin;
    public GameObject cuarto1;
    public GameObject cuarto2;
    public GameObject cuarto3;
    public GameObject cuarto4;
    public GameObject cuarto5;

    public bool inRoom1;
    public bool inRoom2;
    public bool inRoom3;
    public bool inRoom4;
    public bool inRoom5;

    public float progreso;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;

        cuarto1.GetComponent<BoxCollider>().enabled = false;

        progreso = 1f;

        inRoom1 = false;
        inRoom2 = false;
        inRoom3 = false;
        inRoom4 = false;
        inRoom5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Player")
            {
                if(selected == false)
                {
                    selected = true;
                    Debug.Log("Tocamos a Merlin por pirmera vez y lo volvere con selected true");
                }
                else
                {
                    selected = false;
                    Debug.Log("Merlin estaba en selected true, pero al volverlo a tocar se volver false");
                }
            }
            else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto1")
            {
                Debug.Log("Estoy tocando cuarto1");
                if(selected == true)
                {
                    merlin.transform.position = cuarto1.transform.position;
                    selected = false;
                }
            }
            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto2")
            {
                Debug.Log("Estoy tocando cuarto2");
                if (selected == true)
                {
                    merlin.transform.position = cuarto2.transform.position;
                    selected = false;
                }
            }
            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto3")
            {
                Debug.Log("Estoy tocando cuarto3");
                if (selected == true)
                {
                    merlin.transform.position = cuarto3.transform.position;
                    selected = false;
                }
            }
            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto4")
            {
                Debug.Log("Estoy tocando cuarto4");
                if (selected == true)
                {
                    merlin.transform.position = cuarto4.transform.position;
                    selected = false;
                }
            }
            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto5")
            {
                Debug.Log("Estoy tocando cuarto5");
                if (selected == true)
                {
                    merlin.transform.position = cuarto5.transform.position;
                    selected = false;
                }
            }
        }

        if (transform.position == cuarto1.transform.position)
        {
            inRoom1 = true;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == cuarto2.transform.position)
        {
            inRoom1 = false;
            inRoom2 = true;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == cuarto3.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = true;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == cuarto4.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = true;
            inRoom5 = false;
        }
        else if (transform.position == cuarto5.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = true;
        }


        if (selected == true)
        {
            withColliders();
        }
        else
        {
            noColliders();
        }

    }

    private void noColliders()
    {
        cuarto1.GetComponent<BoxCollider>().enabled = false;
        cuarto2.GetComponent<BoxCollider>().enabled = false;
        cuarto3.GetComponent<BoxCollider>().enabled = false;
        cuarto4.GetComponent<BoxCollider>().enabled = false;
        cuarto5.GetComponent<BoxCollider>().enabled = false;
    }
    private void withColliders()
    {
        cuarto1.GetComponent<BoxCollider>().enabled = true;
        cuarto2.GetComponent<BoxCollider>().enabled = true;
        cuarto3.GetComponent<BoxCollider>().enabled = true;
        cuarto4.GetComponent<BoxCollider>().enabled = true;
        cuarto5.GetComponent<BoxCollider>().enabled = true;
    }
}
