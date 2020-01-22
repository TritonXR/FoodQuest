using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public static int tomato = 0;
    public static int salt = 0;
    public static int pepper = 0;

    public GameObject tomatoPic;
    public GameObject saltPic;
    public GameObject pepperPic;



    void Start()
    {
        tomatoPic.SetActive(false);
        saltPic.SetActive(false);
        pepperPic.SetActive(false);
        Dictionary<int, string> food = new Dictionary<int, string>();
        food.Add(1, "Tomato");
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Big Bread")
        {
            tomato += 1;
            Destroy(otherObj.gameObject);
            tomatoPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Salt")
        {
            salt += 1;
            Destroy(otherObj.gameObject);
            saltPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Pepper")
        {
            pepper += 1;
            Destroy(otherObj.gameObject);
            pepperPic.SetActive(true);
        }
    }
}
