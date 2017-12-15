using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlaceTyp {place, upgrade}

public class PlaceObject : MonoBehaviour {

    public Element element;
    public PlaceTyp typ;
    bool placed;

    [HideInInspector]
    public Element mouseOn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!placed)
            transform.position =new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        if (Input.GetMouseButton(0)&&typ==PlaceTyp.place)
        {
            placed = true;
            Inventory.instance.SetAmount(element, Inventory.instance.GetAmount(element) - 1);
            Destroy(GetComponent<PlaceObject>());
            gameObject.AddComponent<Info>();
            gameObject.GetComponent<Info>().element = element;
            UI_Manager.instance.InvOpen();
        }

        if (Input.GetMouseButton(1))
        {
            UI_Manager.instance.InvOpen();
            Destroy(gameObject);
        }

        if (Input.GetMouseButton(0) && typ == PlaceTyp.upgrade)
        {
            foreach (UpgradeObject up in element.recipts)
            {
                if (mouseOn == up.wherePush)
                {
                    Inventory.instance.AddItem(up.finishIteam);
                    Inventory.instance.SetAmount(element, Inventory.instance.GetAmount(element) - 1);
                    Destroy(gameObject);
                }
            }
        }

    }
    
    public void Inst()
    {
        Instantiate(this.gameObject);
        UI_Manager.instance.AllOff();
    }

    


}
