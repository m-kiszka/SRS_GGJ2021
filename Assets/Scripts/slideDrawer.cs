using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideDrawer : MonoBehaviour
{
    public AudioSource drawerOpenSfx;
    public AudioSource drawerCloseSfx;
    bool drawerOpened;
    bool coroutineAllowed;
    Vector3 initialPosition;




    // Start is called before the first frame update
    void Start()
    {
        drawerOpenSfx = GetComponent<AudioSource>();
        drawerOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;

    }

    private void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
        if (drawerOpened)
        {
            drawerCloseSfx.Play();
            
        }
        else
        {
            drawerOpenSfx.Play();
        }


    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenDrawer");

    }

    private IEnumerator OpenDrawer()
    {
        coroutineAllowed = false;
        if (!drawerOpened)
        {
            for (float i=0f; i<=1f; i += 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z + 0.2f);
                yield return new WaitForSeconds(0.05f);
            }
            drawerOpened = true;
            
        }
        else
        {
            for (float i=1f; i>=0f; i -= 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z - 0.2f);
                yield return new WaitForSeconds(0.05f);
            }
            transform.position = initialPosition;
            drawerOpened = false;
        }
        coroutineAllowed = true;

    }

    
}
