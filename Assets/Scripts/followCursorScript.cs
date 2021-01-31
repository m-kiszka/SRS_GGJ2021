using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCursorScript : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && gameObject.transform.localScale.x<1)
        {
            gameObject.transform.localScale+=new Vector3(0.05f,0.05f,0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && gameObject.transform.localScale.x > 0.1f)
        {
            gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }
    }
}
