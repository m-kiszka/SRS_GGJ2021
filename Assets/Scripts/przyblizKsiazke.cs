using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class przyblizKsiazke : MonoBehaviour
{
    public AudioSource openBook;
    public AudioSource closeBook;
    private Vector3 origin;
    private Quaternion originR;
    private GameObject okladka;
    public float speed = 5f;

    private void Start()
    {
        origin = transform.position;
        originR = transform.rotation;
        okladka = gameObject.transform.GetChild(1).gameObject;
    }

    private void OnMouseDown()
    {
        if (Camera.main.GetComponent<cameraScript>().czyMoznaSterowac)
        {
            if (Camera.main.GetComponent<cameraScript>().activeBook != gameObject)
            {
                Camera.main.GetComponent<cameraScript>().activeBook = gameObject;
                openBook.Play();
            }
            else
            {
                Camera.main.GetComponent<cameraScript>().activeBook = null;
                closeBook.Play();
            }
        }
    }

    private void Update()
    {
        if (Camera.main.GetComponent<cameraScript>().czyMoznaSterowac)
        {
            if (Camera.main.GetComponent<cameraScript>().activeBook == gameObject && Camera.main.GetComponent<cameraScript>().cameraScene == 1)
            {
                if (Mathf.Round(transform.position.x * 10f) != Mathf.Round(Camera.main.transform.position.x * 10f))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 2, Camera.main.transform.position.z - 2), Time.deltaTime * speed);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(45, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z), speed * Time.deltaTime);
                    okladka.SetActive(false);
                }

                if (Input.GetMouseButton(1))
                {
                    if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        gameObject.transform.position += new Vector3(0, -0.1f, 0.1f);
                    }
                    if (Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        gameObject.transform.position -= new Vector3(0, -0.1f, 0.1f);
                    }
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, origin, Time.deltaTime * speed);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(originR.x, originR.y, originR.z), speed * Time.deltaTime);
                if (okladka.activeSelf == false)
                {
                    Camera.main.fieldOfView = Camera.main.GetComponent<cameraScript>().defaultFov;
                    okladka.SetActive(true);
                }
            }
        }
    }
}
