using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followCursorScript : MonoBehaviour
{
    public Text kosztyText;
    private float tempKoszty;
    void Update()
    {
        tempKoszty = Mathf.RoundToInt(gameObject.transform.localScale.x * 2000);
        Camera.main.GetComponent<cameraScript>().koszty = tempKoszty;
        kosztyText.text = "-"+tempKoszty.ToString();

        transform.position = Input.mousePosition;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && gameObject.transform.localScale.x<0.5f)
        {
            gameObject.transform.localScale+=new Vector3(0.05f,0.05f,0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && gameObject.transform.localScale.x > 0.1f)
        {
            gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }
    }
}
