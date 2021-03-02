using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    void Update()
    {
        //Con esto si tocamos la pantalla en algun lado se deberia mover el cuadro a esa posicion en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Aqui dependiendo el sitio donde toquemos la camara se hace esa conversion
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
            
            //agregando comentario para ver si aparese en github
        }
    }
}
