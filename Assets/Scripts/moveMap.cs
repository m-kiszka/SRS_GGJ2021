using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMap : MonoBehaviour
{
    public RectTransform atlasRect;
    public GameObject parent;
    public float speed = 5f;
    private Vector3 atlasTransform;
    public bool atlasWysuniety=false;
    void Start()
    {
        atlasTransform = atlasRect.anchoredPosition;
    }

    void Update()
    {
        if(!atlasWysuniety)
        {
            atlasRect.anchoredPosition = Vector3.Lerp(atlasRect.anchoredPosition, new Vector3(atlasRect.anchoredPosition.x, atlasTransform.y+30), speed * Time.deltaTime);
        }
        else
        {
            atlasRect.anchoredPosition = Vector3.Lerp(atlasRect.anchoredPosition, new Vector3(atlasRect.anchoredPosition.x, atlasTransform.y), speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if(atlasWysuniety)
        {
            atlasWysuniety = false;
        }
        else
        {
            atlasWysuniety = true;
        }
    }
}
