using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio_Script : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public AudioSource buttonSound;
    
    bool m_Play;
    bool m_ToggleChange;


    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play =true;
        m_MyAudioSource.Play();

    }

    private void mute()
    {
        m_MyAudioSource.volume = 0;

    }

    private void unMute()
    {
        m_MyAudioSource.volume = 1;
    }

   
    void OnMouseDown()
    {
        if (m_Play == true)
        {
            m_Play = false;
            buttonSound.Play();
            Invoke("mute", 0.1f);
            Debug.Log("Wy³¹cz");
            
        }
        else
        {
            m_Play = true;
            buttonSound.Play();
            Invoke("unMute", 0.3f);
            Debug.Log("W³¹cz");
            
        }

    }


}
