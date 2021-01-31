using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guzikMain : MonoBehaviour
{

    public static string sekwencja;
    private bool isLaunched;
    public AudioSource silnikSFX;
    public AudioSource brokenSFX;
    public Animation buttonPress;
    float nextSoundTime = 0;
    public AudioSource tromboneSFX;


    void OnMouseDown()
    {


        if (Time.time >= nextSoundTime)
        {
            Debug.Log(sekwencja);
            buttonPress.Play();

            if (sekwencja == "BDCEFA" & isLaunched == false)
            {
                silnikSFX.Play();
                sekwencja = "";
                Debug.Log("Uda³o siê!");
                isLaunched = true;

            }
            else if(isLaunched==false)
            {
                brokenSFX.Play();
                sekwencja = "";
                Debug.Log("Nie uda³o siê !");
                isLaunched = false;
            }
            else
            {
                tromboneSFX.Play();
            }
            
            
            nextSoundTime = Time.time + 2f;

        }


    }




}
