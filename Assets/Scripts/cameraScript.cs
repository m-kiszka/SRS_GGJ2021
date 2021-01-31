using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    public int hajs=1200;
    public float koszty;

    public int cameraScene = 0; //0 - domyslny widok; 1 - widok na biurko; 2 - widok na konsolete

    public GameObject deskTrigger;
    public GameObject consoleTrigger;
    public GameObject backButton;

    public float speed = 5f;

    public GameObject mapa;

    private Vector3 camOriginV3;
    private Quaternion camOriginR;
    private Quaternion deskRotation;
    private Quaternion consoleRotation;

    void Start()
    {
        camOriginV3 = transform.position;
        camOriginR = transform.rotation;
        deskRotation = Quaternion.Euler(45, 180, 0);
        consoleRotation = Quaternion.Euler(12, 180, 0);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (cameraScene==0)
        {
            mapa.transform.localScale = new Vector3(1, 1, 1);
            transform.position = Vector3.Lerp(transform.position, camOriginV3, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camOriginR, speed * Time.deltaTime);
            deskTrigger.SetActive(true);
            consoleTrigger.SetActive(true);
            backButton.SetActive(false);
        }
        else
        {
            mapa.transform.GetChild(3).gameObject.GetComponent<moveMap>().atlasWysuniety = false;
            mapa.transform.localScale = new Vector3(0, 0, 0);
            deskTrigger.SetActive(false);
            consoleTrigger.SetActive(false);
            backButton.SetActive(true);
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
