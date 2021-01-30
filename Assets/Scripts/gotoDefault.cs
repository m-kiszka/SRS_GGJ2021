using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoDefault : MonoBehaviour
{
    
    public void goToDefault()
    {
        if(Camera.main.GetComponent<cameraScript>().cameraScene!=0)
        {
            Camera.main.GetComponent<cameraScript>().cameraScene = 0;
        }
    }
}
