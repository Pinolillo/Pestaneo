using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonChangeScene : MonoBehaviour
{
    public int sceneToGo;

    public void SceneSwitcher()
    {
        //Al dar click a este botón se dirijira a al video introductorio el cual tiene la escena número 2
        SceneManager.LoadScene(sceneToGo);
    }
}