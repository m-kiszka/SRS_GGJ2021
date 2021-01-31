using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guzik_B : MonoBehaviour
{
    public Animation buttonPress;
    float nextSoundTime = 0;
    public AudioSource singleSFX;


    void OnMouseDown()
    {
        if (Time.time >= nextSoundTime)
        {
            buttonPress.Play();
            guzikMain.sekwencja += "B";
            singleSFX.Play();
            nextSoundTime = Time.time + 2f;

        }


    }
}
