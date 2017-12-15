using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discover : MonoBehaviour {
    public GameObject listRecipt, listIngredient, pRecipt, slots;
    public List<Recipe> allRecipts;
    public List<Element> discoveElement;
    public List<Recipe> discoveRecipts;

    [SerializeField]
    Recipe currentRecipe;


    public static Discover instance = null;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;   	


      
	}

    public void DiscoverElement(Element e)
    {
        if (!discoveElement.Contains(e))
        {
            listIngredient.transform.GetChild(e.ID - 1).GetComponent<Button>().interactable = true;
          //  listIngredient.transform.GetChild(e.ID - 1).GetComponent<DragAndDropCell>().canDrag = true;
            listIngredient.transform.GetChild(e.ID - 1).GetChild(1).gameObject.SetActive(true);
            discoveElement.Add(e);
            UI_Manager.instance.Notification("Odkryto surowiec");

            DiscoverRecipt();
        }

      
  
    }

    public void DiscoverRecipt()
    {
        foreach(Recipe r in allRecipts)
        {
            if (!discoveRecipts.Contains(r))
            {
                int have = 0;

                foreach (Ingredient ing in r.requireElements)
                {
                    if (CheckElement(ing.element))
                        have++;
                }

                if (have == r.requireElements.Count)
                {
                    discoveRecipts.Add(r);
                    //GameObject a = Instantiate(pRecipt, listRecipt.transform);
                    //a.transform.GetChild(0).GetComponent<Text>().text = r.rName;
                    //a.name = r.rName;
                    //a.GetComponent<Button>().onClick.AddListener(() => CurrentRecipt(r));
                    GameObject a = Instantiate(UI_Manager.instance.craftButton, UI_Manager.instance.UI_Inventory.transform.GetChild(0));
                    a.transform.GetChild(0).GetComponent<Text>().text = r.rName;
                    a.GetComponent<Button>().onClick.AddListener(() => UI_Manager.instance.GetComponent<Craft>().CraftObj(r));

                    UI_Manager.instance.Notification("Odkryto recepture");
                }
            }

        }
    }



    bool CheckElement(Element e)
    { 
            foreach (Element i in discoveElement)
            {
                if (i.ID == e.ID)
                    return true;
            }

            return false;    
    }

   // void CurrentRecipt(Recipe r)
   // {
   //     currentRecipe = r;
   // }

   //public void DiscoverButton()
   // {
   //     if(IngredientisTrue())
   //     {
   //         GameObject a = Instantiate(UI_Manager.instance.craftButton, UI_Manager.instance.UI_Inventory.transform.GetChild(0));       
   //         a.transform.GetChild(0).GetComponent<Text>().text = currentRecipe.rName;
   //         foreach(Recipe r in allRecipts)
   //         {
   //             if(r.rName ==currentRecipe.rName)
   //                 a.GetComponent<Button>().onClick.AddListener(() => UI_Manager.instance.GetComponent<Craft>().CraftObj(r));
   //         }

   //         UI_Manager.instance.Notification("Wymyślono nowy przedmiot");
   //         Destroy(GameObject.Find(currentRecipe.rName));
   //         for (int i = 0; i < 9; i++)
   //         {
   //             if(slots.transform.GetChild(i).childCount>0)
   //                  Destroy(slots.transform.GetChild(i).GetChild(0).gameObject);
   //         }
   //     }
   //     else
   //     {
   //         UI_Manager.instance.Notification("Zły przepis");
   //         for (int i = 0; i < 9; i++)
   //         {
   //             if (slots.transform.GetChild(i).childCount > 0)
   //                 Destroy(slots.transform.GetChild(i).GetChild(0).gameObject);
   //         }
   //     }
   // }

   // bool IngredientisTrue()
   // {
   //     int correct = 0;
   //     for(int i =0; i<3;i++)
   //     {
   //         for (int j = 0; j < 3; j++)
   //         {
   //             //Debug.Log(currentRecipe.drawElements.rows[i].row[j].ID.ToString());
   //             // Debug.Log("C " + slots.transform.GetChild((3 * i) + j).childCount.ToString());

   //             if (currentRecipe.drawElements.rows[i].row[j] != null && currentRecipe.drawElements.rows[i].row[j].ID == int.Parse(slots.transform.GetChild((3 * i) + j).GetChild(0).name))
   //                 correct++;
   //             if (currentRecipe.drawElements.rows[i].row[j] == null && slots.transform.GetChild((3 * i) + j).childCount == 0) 
   //                 correct++;
   //         }
   //     }
   //     if (correct==9)
   //          return true;
   //     else
   //         return false;

   
   // }
}
