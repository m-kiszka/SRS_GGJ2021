using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public int cameraScene = 0; //0 - domyslny widok; 1 - widok na biurko; 2 - widok na konsolete
    public float speed = 5f;
    private Vector3 camOriginV3;
    private Quaternion camOriginR;
    private Quaternion deskRotation;
    private Quaternion consoleRotation;
    private GameObject camGO;
    void Start()
    {
        camGO = gameObject;
        camOriginV3 = transform.position;
        camOriginR = transform.rotation;
        deskRotation = Quaternion.Euler(45, 180, 0);
        consoleRotation = Quaternion.Euler(12, 180, 0);
    }

    void Update()
    {
        if(cameraScene==0)
        {
            transform.position = Vector3.Lerp(transform.position, camOriginV3, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camOriginR, speed * Time.deltaTime);
        }
        if (cameraScene == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(13,22,-23), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, deskRotation, speed * Time.deltaTime);
        }
        if (cameraScene == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-12, 17, -16), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, consoleRotation, speed * Time.deltaTime);
        }
    }
}
