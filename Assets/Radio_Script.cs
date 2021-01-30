using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio_Script : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    
    bool m_Play;
    bool m_ToggleChange;


    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play =true;
        m_MyAudioSource.Play();

    }

   
    void OnMouseDown()
    {
        if (m_Play == true)
        {
            m_Play = false;
            m_MyAudioSource.volume = 0;
            Debug.Log("Wy³¹cz");
        }
        else
        {
            m_Play = true;
            m_MyAudioSource.volume = 1;
            Debug.Log("W³¹cz");
        }

    }


}
