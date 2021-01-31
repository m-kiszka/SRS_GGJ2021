using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "statek")
        {
            Camera.main.GetComponent<cameraScript>().czyTrafiony = true;
            Camera.main.GetComponent<cameraScript>().nazwaStatku = col.gameObject.name;
            Camera.main.GetComponent<cameraScript>().trafionyStatek = col.gameObject;
            Debug.Log(col.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Camera.main.GetComponent<cameraScript>().czyTrafiony = false;
        Camera.main.GetComponent<cameraScript>().nazwaStatku = "";
        Camera.main.GetComponent<cameraScript>().trafionyStatek = null;
    }
}
