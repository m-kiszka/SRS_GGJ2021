using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private float czas;
    void Update()
    {
        czas += 1 * Time.deltaTime;

        if(czas>5)
        {
            Destroy(gameObject);
        }
    }
}
