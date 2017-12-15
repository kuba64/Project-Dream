using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

    public static Material CursorOn, Normal;
    public  Material _CursorOn, _Normal;

    // Use this for initialization
    void Start () {
		
	}

    
    void Awake()
    {
        CursorOn = _CursorOn;
        Normal = _Normal;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public static void SetOrderLayer(GameObject a)
    {
        a.GetComponent<SpriteRenderer>().sortingOrder = 50 -  (int) a.transform.position.y;
    }
}
