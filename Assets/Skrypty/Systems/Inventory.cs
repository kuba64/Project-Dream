using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public List<int> haveItems;
    public List<int> amountItems;
    public List<GameObject> slot;

    [SerializeField]
    private GameObject InvItems;

    public static Inventory instance=null;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;

        
	}
	
	// Update is called once per frame
	void Update () {

        //przypisuje wartosci do icon
        foreach (GameObject i in slot)
        {
            i.transform.GetChild(1).GetComponent<Text>().text = amountItems[slot.IndexOf(i)].ToString();
        }


        //sprawdza czy nie ma zero
        foreach (int i in amountItems)
        {
            if (i <= 0)
            {
                //item w kazdej liscie ma ten sam index
                haveItems.RemoveAt(amountItems.IndexOf(i)); 
                Destroy(slot[amountItems.IndexOf(i)]);
                slot.RemoveAt(amountItems.IndexOf(i));
                amountItems.Remove(i);
                break;
            }
        }
    }

    public void AddItem(Element AddItem)
    {
        UI_Manager.instance.Notification("Podniesiono " + AddItem.name + " 1");
        if (CheckItems(AddItem))
        {
          amountItems[haveItems.IndexOf(AddItem.ID)]++; 

        }//jesli nie ma tworzy nowy
        else
        {
            GameObject i = Instantiate(AddItem.IconPrefab, InvItems.transform);
            haveItems.Add(AddItem.ID);
            amountItems.Add(1);
            slot.Add(i);
        }

        if(AddItem.surowiec)
            Discover.instance.DiscoverElement(AddItem);

    }


    public void AddItem(Element AddItem, int am)
    {
        UI_Manager.instance.Notification("Podniesiono " + AddItem.name + " " + am.ToString());
        if (CheckItems(AddItem))
        {
            amountItems[haveItems.IndexOf(AddItem.ID)]+=am;

        }
        else
        {
            haveItems.Add(AddItem.ID);
            GameObject i = Instantiate(AddItem.IconPrefab, InvItems.transform);
            amountItems.Add(am);
            slot.Add(i);
        }

        if (AddItem.surowiec)
            Discover.instance.DiscoverElement(AddItem);

    }

    public bool CheckItems(Element it)
    {
        foreach(int i in haveItems)
        {
            if (i == it.ID)
                return true;
        }
 
        return false;
    }

    public int GetAmount(Element it)
    {
        return amountItems[haveItems.IndexOf(it.ID)];
    }

    public void SetAmount(Element it, int amount)
    {
        amountItems[haveItems.IndexOf(it.ID)] = amount;
    }
}
