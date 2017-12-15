using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    public float speed;

    [SerializeField]
    private float scale;

    Animator anim;
    bool move, wydobycie;
    float time;
    Item objToWyd;
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {


        //*************************************
        //WYDOBYCIE
        //*************************************

        if (wydobycie)
        {
            //timer wydobycia
            time += Time.deltaTime;

            if(objToWyd.transform.position.x<transform.position.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;


            //sprawdza
            if (time > objToWyd.czasWydb)
            {
                objToWyd.ilosc--;
                print(objToWyd.ObjectName.ToString() + " wydobyto 1");
                Inventory.instance.AddItem(objToWyd.getItem);
                time = 0;
            }
            if (objToWyd.ilosc <= 0 || move == true)
            {
                wydobycie = false;
                print("Koniec Wydobycia");
                objToWyd = null;
            }
        }
        else
            time = 0;

        anim.SetBool("Wydobycie", wydobycie);

        //******************************************


     
    


    }

    void FixedUpdate()
    {
        //poruszanie
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, y, 0);

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 5;
        else
            speed = 3;

        //lefo prawo
        if (x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if(x>0)
            GetComponent<SpriteRenderer>().flipX = false;

        //animacje  ruch
        if (x != 0 || y != 0)
        {
            anim.SetBool("Move", true);
            move = true;
        }
        else
        {
            anim.SetBool("Move", false);
            move = false;
        }


        anim.SetFloat("SpeedX", Input.GetAxis("Horizontal"));
        anim.SetFloat("SpeedY", Input.GetAxis("Vertical"));

        //if (Input.GetKey(KeyCode.Mouse0))
        //    anim.SetTrigger("Take");



    }

    public void Wydobyj(Item Object)
    {
        wydobycie = true;
        objToWyd = Object;   
    }

    public void Podnies(Item Object)
    {
        Inventory.instance.AddItem(Object.getItem);
        print("Podniesiono");
    }
    
   
}
