using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypObiketu {kamien, drzewo, kamyk, galez};

public class Item : MonoBehaviour
{
    public string ObjectName;
    public float dis, czasWydb, ilosc;
    public TypObiketu typ;
    public Element getItem;

    // Use this for initialization
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            anim.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ilosc <= 0)
        {
            Zniszcz();
        }
      
        DayNight.Shadow(transform, FindObjectOfType<DayNight>());
    }
    void OnMouseOver()
    {
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < dis)
        {
            UI_Manager.instance.ObjectName.text = ObjectName;
            GetComponent<SpriteRenderer>().material = Option.CursorOn;
        }
        else
        {
            UI_Manager.instance.ObjectName.text = "";
        GetComponent<SpriteRenderer>().material = Option.Normal;
        }
    }

    void OnMouseExit()
    {
        UI_Manager.instance.ObjectName.text = "";
        GetComponent<SpriteRenderer>().material = Option.Normal;
    }

    void OnMouseDown()
    {

        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < dis)
        {
            if (typ == TypObiketu.kamyk || typ == TypObiketu.galez)
            {
                GameObject.FindGameObjectWithTag("Player").SendMessage("Podnies", this);
                Zniszcz();
            }          
            else
            {
                GameObject.FindGameObjectWithTag("Player").SendMessage("Wydobyj", this);
                print(ObjectName.ToString());
            }
        }
    }


    void Zniszcz()
    {
        UI_Manager.instance.ObjectName.text = "";
        Destroy(gameObject);      
    }
}
