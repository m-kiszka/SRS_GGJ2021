using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guzik_D : MonoBehaviour
{
    public Animation buttonPress;
    float nextSoundTime = 0;
    public AudioSource singleSFX;


    void OnMouseDown()
    {
        if (Camera.main.GetComponent<cameraScript>().czyMoznaSterowac)
        {
            if (Time.time >= nextSoundTime)
            {
                buttonPress.Play();
                guzikMain.sekwencja += "D";
                singleSFX.Play();
                nextSoundTime = Time.time + 1f;

            }
        }

    }
}
