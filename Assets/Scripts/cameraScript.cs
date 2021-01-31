using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour
{
    public int hajs=1200;
    public float kosztyTemp;
    public float koszty;

    public GameObject prompt;
    public GameObject promptPrefab;

    public bool czyMoznaSterowac = true;

    public Text monitorText;

    public bool czyTrafiony = false;
    public string nazwaStatku="";
    public GameObject trafionyStatek;

    public float defaultFov;

    public int cameraScene = 0; //0 - domyslny widok; 1 - widok na biurko; 2 - widok na konsolete

    public GameObject deskTrigger;
    public GameObject consoleTrigger;
    public GameObject backButton;
    public GameObject mainButton;

    public GameObject destination;

    public GameObject activeBook;

    public float speed = 5f;

    public GameObject mapa;

    private Vector3 camOriginV3;
    private Quaternion camOriginR;
    private Quaternion deskRotation;
    private Quaternion consoleRotation;

    float minFov = 15f;
    float maxFov = 90f;
    float sensitivity = -10f;

    void Start()
    {
        camOriginV3 = transform.position;
        camOriginR = transform.rotation;
        defaultFov = Camera.main.fieldOfView;
        deskRotation = Quaternion.Euler(45, 180, 0);
        consoleRotation = Quaternion.Euler(12, 180, 0);
        monitorText.text = "SeaOS 1.5.6" + System.Environment.NewLine + System.Environment.NewLine + "Initializing..." + System.Environment.NewLine + "Success." + System.Environment.NewLine + System.Environment.NewLine + "Engines: OFF" + System.Environment.NewLine + "Destination: NONE";
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            mainButton.GetComponent<guzikMain>().isLaunched = true;
        }

        if(destination==null && mainButton.GetComponent<guzikMain>().isLaunched==false)
        {
            monitorText.text = "SeaOS 1.5.6" + System.Environment.NewLine + System.Environment.NewLine + "Initializing..." + System.Environment.NewLine + "Success." + System.Environment.NewLine + System.Environment.NewLine + "Engines: OFF" + System.Environment.NewLine + "Destination: NONE";
        }
        if (destination != null && mainButton.GetComponent<guzikMain>().isLaunched == false)
        {
            monitorText.text = "SeaOS 1.5.6" + System.Environment.NewLine + System.Environment.NewLine + "Initializing..." + System.Environment.NewLine + "Success." + System.Environment.NewLine + System.Environment.NewLine + "Engines: OFF" + System.Environment.NewLine + "Destination: OK";
        }
        if (destination == null && mainButton.GetComponent<guzikMain>().isLaunched == true)
        {
            monitorText.text = "SeaOS 1.5.6" + System.Environment.NewLine + System.Environment.NewLine + "Initializing..." + System.Environment.NewLine + "Success." + System.Environment.NewLine + System.Environment.NewLine + "Engines: ON" + System.Environment.NewLine + "Destination: NONE";
        }
        if (destination != null && mainButton.GetComponent<guzikMain>().isLaunched == true)
        {
            monitorText.text = "SeaOS 1.5.6" + System.Environment.NewLine + System.Environment.NewLine + "Initializing..." + System.Environment.NewLine + "Success." + System.Environment.NewLine + System.Environment.NewLine + "Engines: ON" + System.Environment.NewLine + "Destination: OK" + System.Environment.NewLine + System.Environment.NewLine + "Wciœnij ENTER, aby wys³aæ ekspedycjê";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                cameraScene = 0;
                Destroy(destination);
                mainButton.GetComponent<guzikMain>().isLaunched = false;
                hajs -= Mathf.RoundToInt(koszty);
                prompt = Instantiate(promptPrefab, transform.position,transform.rotation);
                if(czyTrafiony)
                {
                    prompt.transform.GetComponentInChildren<Text>().text = "Ekspedycja siê powiod³a!" + System.Environment.NewLine + System.Environment.NewLine + "Znaleziony statek: " + nazwaStatku + System.Environment.NewLine + System.Environment.NewLine + "Wyp³ata: $500";
                    hajs += 500;
                    Destroy(trafionyStatek);
                }
                else
                {
                    prompt.transform.GetComponentInChildren<Text>().text = "Ekspedycja siê nie powiod³a!" + System.Environment.NewLine + System.Environment.NewLine + "W danej lokalizacji nie znaleziono wraku.";
                }
                czyTrafiony = false;
                nazwaStatku = "";
                trafionyStatek = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("scOffice", LoadSceneMode.Single);
        }

        if (cameraScene==0)
        {
            Camera.main.fieldOfView = defaultFov;
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
        
        if (activeBook!=null && !Input.GetMouseButton(1) && (cameraScene==1 || cameraScene==2) && czyMoznaSterowac)
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
    }
}
