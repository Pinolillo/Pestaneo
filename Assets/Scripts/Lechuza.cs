using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lechuza : MonoBehaviour
{

    public bool lechuzaVive;
    public bool merlinpuededistraerse;

    // Start is called before the first frame update
    void Start()
    {
        lechuzaVive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Lechuza")
            {
                Debug.Log("Toque a la lechuza malvada y debe irse");
                lechuzaVive = false;
            }
        }
    }
}
