using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioOnClick : MonoBehaviour
{

    public AudioSource singleSFX;

    void OnMouseDown()
    {
        singleSFX.Play();
    }
    

    
}
