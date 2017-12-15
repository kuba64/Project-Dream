using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Ingredient
{
    public Element element;
    public int amount;

    public Ingredient(Element e, int amo)
    {
        element = e;
        amount = amo;
    }
    public Ingredient(Element e)
    {
        element = e;
    }
}



[CreateAssetMenu(fileName = "Receptura")]

public class Recipe : ScriptableObject {

    public string rName;
    public Ingredient makeObject;
    public List<Ingredient> requireElements;

    public float CraftTime;

    // Use this for initialization
   
  
	
	// Update is called once per frame

}






