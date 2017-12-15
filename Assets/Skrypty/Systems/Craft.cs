using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour {

    Recipe re=null;
    bool make;
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //*************************************
        //Tworzenie
        //*************************************
        if (make)
        {
            time += Time.deltaTime;

            if (time >= re.CraftTime)
            {
                make = false;
                time = 0;
                Inventory.instance.AddItem(re.makeObject.element, re.makeObject.amount);
                UI_Manager.instance.InvOpen();
                //Odejmjue składniki
                foreach (Ingredient ing in re.requireElements)
                {
                    Inventory.instance.SetAmount(ing.element, Inventory.instance.GetAmount(ing.element) - ing.amount);
                }
            }
        }

            //Animacja
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Craft", make);
        //*************************************
    }

    public void CraftObj(Recipe recipe)
    {
        int have = 0;

        //sprawdza składniki i ilosc
        foreach (Ingredient ing in recipe.requireElements) {
            if (Inventory.instance.CheckItems(ing.element) && Inventory.instance.GetAmount(ing.element) >= ing.amount)
                have++;         
        }

        //ilość poprawnych
        if (have == recipe.requireElements.Count)//wszystko pobrawne
        {
            re = recipe;
            make = true;
            UI_Manager.instance.AllOff();
            


        }
        else
            UI_Manager.instance.Notification("Brak surowców");

        have = 0;
    }
}
