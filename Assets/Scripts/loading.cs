using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loading : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public bool cargando;
    public float progresoactual;

    private void Start()
    {
        cargando = false;
        progresoactual = 0;
    }

    public void Update()
    {
        StartCoroutine(startLoading());

        if (cargando == true)
        {
            progresoactual += 1f * Time.deltaTime;
            setProgres(progresoactual);

            if(progresoactual >= 6f)
            {
                progresoactual += 2f * Time.deltaTime;
                setProgres(progresoactual);
            }

            if(progresoactual >= 10f)
            {
                SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.
            }

        }
        else
        {
            progresoactual = 0f;
        }
    }

    public void setInitialProgres(float progres)
    {
        slider.value = progres;
    }

    public void setProgres(float progres)
    {
        slider.value = progres;
    }

    IEnumerator startLoading()
    {
        yield return new WaitForSeconds(5f);//10 Segundos dura la distraccion
        cargando = true;
    }
}
