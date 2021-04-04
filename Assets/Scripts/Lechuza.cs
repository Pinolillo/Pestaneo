using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lechuza : MonoBehaviour
{

    public bool lechuzaVive;
    public bool isnotkilled;

    public ProgresoController progresoController;
    public GameObject progresoControllerObject;

    public MerlinController merlincontroller;
    public GameObject merlinGameobject;

    // Start is called before the first frame update
    void Start()
    {
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();
        merlincontroller = merlinGameobject.GetComponent<MerlinController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(progresoController.progreso == 0)
        {
            merlincontroller.readyToPlay = false;
        }
        else
        {
            merlincontroller.readyToPlay = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Lechuza")
            {
                Debug.Log("Toque a la lechuza malvada y debe irse");
                StartCoroutine(merlincontroller.Uchu());
                lechuzaVive = false;
                isnotkilled = false;
            }
        }
    }
}
