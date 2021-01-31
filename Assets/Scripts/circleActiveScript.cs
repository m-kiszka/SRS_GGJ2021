using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleActiveScript : MonoBehaviour
{
    public GameObject circle;
    public GameObject kosztyText;
    public GameObject kosztyBG;
    private void OnMouseOver()
    {
        circle.SetActive(true);
        kosztyText.SetActive(true);
        kosztyBG.SetActive(true);
    }
    private void OnMouseExit()
    {
        circle.SetActive(false);
        if (Camera.main.GetComponent<cameraScript>().destination == null)
        {
            kosztyText.SetActive(false);
            kosztyBG.SetActive(false);
        }
    }    
}
