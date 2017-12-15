using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DayNight : MonoBehaviour {
    [Range(0, 24)]
    public float time;
    public float timeScale;
    public Gradient skyColor, backgroundColor;
    public Transform sunMoon;
    public SpriteRenderer skyForward;
    public Camera cam;
  
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime * timeScale;
        if (Application.isEditor || Application.isPlaying)
        {
            sunMoon.eulerAngles = new Vector3(0, 0, -time * (360 / 24));
            skyForward.color = skyColor.Evaluate(time/24);
            cam.backgroundColor = backgroundColor.Evaluate(time / 24);

            if (time >= 24)
                time = 0;
        }
	}

    public static void Shadow(Transform trans, DayNight dn)
    {
        trans.Find("Shadow").eulerAngles = new Vector3(trans.Find("Shadow").eulerAngles.x, trans.Find("Shadow").eulerAngles.y, -dn.time * (360 / 12)+180);
    }
}
