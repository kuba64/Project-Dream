using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

    public Element element;

    private void OnMouseEnter()
    {
        FindObjectOfType<PlaceObject>().mouseOn = element;
    }

    private void OnMouseOver()
    {
        FindObjectOfType<PlaceObject>().mouseOn = element;
    }

    private void OnMouseExit()
    {
        FindObjectOfType<PlaceObject>().mouseOn = null;
    }
}
