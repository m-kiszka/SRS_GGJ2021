using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoConsole : MonoBehaviour
{   
    void OnMouseDown()
    {
        if(Camera.main.GetComponent<cameraScript>().cameraScene==0)
        {
            Camera.main.GetComponent<cameraScript>().cameraScene = 2;
        }
    }
}
