using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeObject
{
    public Element wherePush, finishIteam;
}


[CreateAssetMenu(fileName ="Element")]
public class Element : ScriptableObject {
    

    public int ID;
    public GameObject IconPrefab;
    public bool surowiec;
    public UpgradeObject[] recipts;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
