using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerlinController : MonoBehaviour
{

    public GameObject merlin;

    public GameObject cuarto1;
    public GameObject cuarto2;
    public GameObject cuarto3;
    public GameObject cuarto4;
    public GameObject cuarto5;

    public GameObject innerc1;
    public GameObject innerc2;
    public GameObject innerc3;
    public GameObject innerc4;
    public GameObject innerc5;

    public bool inRoom1;
    public bool inRoom2;
    public bool inRoom3;
    public bool inRoom4;
    public bool inRoom5;

    public SpriteRenderer spriteRenderer;
    public Sprite glowSprite;
    public Sprite normalSprite;

    public bool readyToPlay;

    // Start is called before the first frame update
    void Start()
    {
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

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto1")
            {
                Debug.Log("Estoy tocando cuarto1 y movere a merlin para alla");
                merlin.transform.position = innerc1.transform.position;
            }

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto2")
            {
                Debug.Log("Estoy tocando cuarto2 y movere a merlin para alla");
                merlin.transform.position = innerc2.transform.position;

            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto3")
            {
                Debug.Log("Estoy tocando cuarto3 y movere a merlin para alla");
                merlin.transform.position = innerc3.transform.position;
            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto4")
            {
                Debug.Log("Estoy tocando cuarto4 y movere a merlin para alla");
                merlin.transform.position = innerc4.transform.position;
            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto5")
            {
                Debug.Log("Estoy tocando cuarto5 y movere a merlin para alla");
                merlin.transform.position = innerc5.transform.position;
            }
        }

        if (transform.position == innerc1.transform.position)
        {
            inRoom1 = true;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == innerc2.transform.position)
        {
            inRoom1 = false;
            inRoom2 = true;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == innerc3.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = true;
            inRoom4 = false;
            inRoom5 = false;
        }
        else if (transform.position == innerc4.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = true;
            inRoom5 = false;
        }
        else if (transform.position == innerc5.transform.position)
        {
            inRoom1 = false;
            inRoom2 = false;
            inRoom3 = false;
            inRoom4 = false;
            inRoom5 = true;
        }

        if (readyToPlay == true)
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
