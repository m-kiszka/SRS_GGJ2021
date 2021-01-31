using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayNameScript : MonoBehaviour
{
    public Text bookHoverText;
    private void Start()
    {
        bookHoverText = GameObject.Find("bookHoverText").GetComponent<Text>();
    }
    private void OnMouseEnter()
    {
        bookHoverText.text = gameObject.name;
    }
    private void OnMouseExit()
    {
        bookHoverText.text = "";
    }
}
