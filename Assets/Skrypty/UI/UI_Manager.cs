using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    public Text ObjectName;
    public GameObject UI_Inventory, UI_Discover, UI_Notification, UI_MenuItem;
    public GameObject craftButton;
    public GameObject pNotification;


    public static UI_Manager instance = null;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UI_MenuItem.SetActive(!UI_MenuItem.activeSelf);
            UI_Inventory.SetActive(!UI_Inventory.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            UI_MenuItem.SetActive(!UI_MenuItem.activeSelf);
            UI_Discover.SetActive(!UI_Discover.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UI_MenuItem.SetActive(!UI_MenuItem.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            AllOff();



    }

    public void Notification(string komunikat)
    {
        GameObject a = Instantiate(pNotification, UI_Notification.transform);
        a.transform.GetChild(0).GetComponent<Text>().text = komunikat;
        Destroy(a, 3);
    }

    public void AllOff()
    {
            UI_Inventory.SetActive(false);
            UI_MenuItem.SetActive(false);
            UI_Discover.SetActive(false);
    }

    public void InvOpen()
    {
        UI_MenuItem.SetActive(true);
        UI_Inventory.SetActive(true);
    }

    public void InvButton()
    {
        UI_Inventory.SetActive(true);
        UI_Discover.SetActive(false);
    }

    public void DisButton()
    {
        UI_Inventory.SetActive(false);
        UI_Discover.SetActive(true);
    }
}
