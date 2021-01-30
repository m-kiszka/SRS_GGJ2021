using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoConsole : MonoBehaviour
{
    public GameObject mapa;

    void OnMouseDown()
    {
        if(Camera.main.GetComponent<cameraScript>().cameraScene==0 && mapa.GetComponent<moveMap>().atlasWysuniety==false)
        {
            Camera.main.GetComponent<cameraScript>().cameraScene = 2;
        }
    }
}
