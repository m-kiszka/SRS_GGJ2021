using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookHoverScript : MonoBehaviour
{
    public Text bookHoverText;
    private void Start()
    {
        bookHoverText = GameObject.Find("bookHoverText").GetComponent<Text>();
    }
    private void OnMouseEnter()
    {
        Debug.Log("test");
        bookHoverText.text = gameObject.name;
    }
    private void OnMouseExit()
    {
        bookHoverText.text = "";
    }
}
