using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followCursorScript : MonoBehaviour
{
    public Text kosztyText;
    public GameObject destinationSet;
    private float tempKoszty;
    public Transform parentCircla;
    void Update()
    {
        if (Camera.main.GetComponent<cameraScript>().czyMoznaSterowac)
        {
            tempKoszty = Mathf.RoundToInt(gameObject.transform.localScale.x * 2000);
            Camera.main.GetComponent<cameraScript>().kosztyTemp = tempKoszty;
            kosztyText.text = "-" + tempKoszty.ToString();

            transform.position = Input.mousePosition;

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && gameObject.transform.localScale.x < 0.5f)
            {
                gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && gameObject.transform.localScale.x > 0.1f)
            {
                gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main.GetComponent<cameraScript>().destination != null)
                {
                    Destroy(Camera.main.GetComponent<cameraScript>().destination);
                }
                Camera.main.GetComponent<cameraScript>().koszty = Camera.main.GetComponent<cameraScript>().kosztyTemp;
                Camera.main.GetComponent<cameraScript>().destination = Instantiate(destinationSet, Input.mousePosition, transform.rotation);
                Camera.main.GetComponent<cameraScript>().destination.transform.localScale = transform.localScale;
                Camera.main.GetComponent<cameraScript>().destination.transform.parent = parentCircla;
            }
        }
    }
}
