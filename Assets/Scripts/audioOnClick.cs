using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioOnClick : MonoBehaviour
{
    float nextSoundTime = 0;
    public AudioSource singleSFX;
    

    void OnMouseDown()
    {
        if (Time.time >= nextSoundTime)
        {
            singleSFX.Play();
            nextSoundTime = Time.time + 3f;
        }


    }
}
