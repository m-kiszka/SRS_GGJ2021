using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleActiveScript : MonoBehaviour
{
    public GameObject circle;
    private void OnMouseOver()
    {
        circle.SetActive(true);
    }
    private void OnMouseExit()
    {
        circle.SetActive(false);
    }
}
