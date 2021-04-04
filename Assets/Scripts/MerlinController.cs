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

    public bool readyToPlay;

    public ProgresoController progresoController;
    public GameObject progresoControllerObject;

    public Lechuza lechuzacontroller;
    public GameObject lechuzaObject;

    public bool traveling;
    public bool espantando;

    //Animaciones
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        progresoController = progresoControllerObject.GetComponent<ProgresoController>();
        lechuzacontroller = lechuzaObject.GetComponent<Lechuza>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inRoom1 = false;
        inRoom2 = false;
        inRoom3 = false;
        inRoom4 = false;
        inRoom5 = false;
        traveling = false;
        espantando = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (traveling == false)
        {
            if(espantando == false)
            {
                if (progresoController.progreso == 0)
                {
                    Distraidon();
                }
                else
                {
                    Trabajo();
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto1")
            {
                Debug.Log("Estoy tocando cuarto1 y movere a merlin para alla");
                merlin.transform.position = innerc1.transform.position;
                StartCoroutine(Travel()); //Iniciar viaje
            }

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto2")
            {
                Debug.Log("Estoy tocando cuarto2 y movere a merlin para alla");
                merlin.transform.position = innerc2.transform.position;
                StartCoroutine(Travel()); //Iniciar viaje
            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto3")
            {
                Debug.Log("Estoy tocando cuarto3 y movere a merlin para alla");
                merlin.transform.position = innerc3.transform.position;
                StartCoroutine(Travel()); //Iniciar viaje
            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto4")
            {
                Debug.Log("Estoy tocando cuarto4 y movere a merlin para alla");
                merlin.transform.position = innerc4.transform.position;
                StartCoroutine(Travel()); //Iniciar viaje
            }
             if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "cuarto5")
            {
                Debug.Log("Estoy tocando cuarto5 y movere a merlin para alla");
                merlin.transform.position = innerc5.transform.position;
                StartCoroutine(Travel()); //Iniciar viaje
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

        /* Ready to play */

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
        /*
        cuarto1.GetComponent<BoxCollider>().enabled = false;
        cuarto2.GetComponent<BoxCollider>().enabled = false;
        cuarto3.GetComponent<BoxCollider>().enabled = false;
        cuarto4.GetComponent<BoxCollider>().enabled = false;
        cuarto5.GetComponent<BoxCollider>().enabled = false;
        */

        cuarto1.SetActive(false);
        cuarto2.SetActive(false);
        cuarto3.SetActive(false);
        cuarto4.SetActive(false);
        cuarto5.SetActive(false);
    }
    private void withColliders()
    {

        cuarto1.SetActive(true);
        cuarto2.SetActive(true);
        cuarto3.SetActive(true);
        cuarto4.SetActive(true);
        cuarto5.SetActive(true);

        /*
        cuarto1.GetComponent<BoxCollider>().enabled = true;
        cuarto2.GetComponent<BoxCollider>().enabled = true;
        cuarto3.GetComponent<BoxCollider>().enabled = true;
        cuarto4.GetComponent<BoxCollider>().enabled = true;
        cuarto5.GetComponent<BoxCollider>().enabled = true;
        */
    }

    private void Trabajo()
    {
        _animator.SetBool("distracted", false);
        //Controlar animaciones
        if (inRoom1 == true)
        {
            _animator.SetBool("trabajo1", true);
            _animator.SetBool("trabajo2", false);
        }
        if (inRoom2 == true)
        {
            _animator.SetBool("trabajo2", true);
            _animator.SetBool("trabajo1", false);
        }
        if (inRoom3 == true)
        {
            _animator.SetBool("trabajo2", true);
            _animator.SetBool("trabajo1", false);
        }
        if (inRoom4 == true)
        {
            _animator.SetBool("trabajo1", true);
            _animator.SetBool("trabajo2", false);
        }
        if (inRoom5 == true)
        {
            _animator.SetBool("trabajo2", true);
            _animator.SetBool("trabajo1", false);
        }
    }

    private void Moving()
    {
        _animator.SetTrigger("changeRoom");
        _animator.SetBool("trabajo1", false);
        _animator.SetBool("trabajo2", false);
    }

    private void Distraidon()
    {
        _animator.SetBool("trabajo1", false);
        _animator.SetBool("trabajo2", false);
        _animator.SetBool("distracted", true);
    }

    private void UchuBonzo()
    {
        _animator.SetTrigger("mandarVolar");
        _animator.SetBool("trabajo1", false);
        _animator.SetBool("trabajo2", false);
        _animator.SetBool("distracted", false);
    }

    public IEnumerator Travel()
    {
        Moving();
        traveling = true;
        yield return new WaitForSeconds(0.65f);//x Segundos dura la distraccion
        Trabajo();
        traveling = false;
    }

    public IEnumerator Uchu()
    {
        UchuBonzo();
        StartCoroutine(reiniciarBonzo());
        yield return new WaitForSeconds(1f);//x Segundos dura la distraccion
        Trabajo();
    }

    IEnumerator reiniciarBonzo()
    {
        espantando = true;
        yield return new WaitForSeconds(1f);//x Segundos dura la distraccion
        espantando = false;
    }
}
