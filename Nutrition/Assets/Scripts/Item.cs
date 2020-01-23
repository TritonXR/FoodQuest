using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public GameObject tomatoPic;
    public GameObject saltPic;
    public GameObject pepperPic;

    public static Dictionary<string, int> food;


    void Start()
    {
        tomatoPic.SetActive(false);
        saltPic.SetActive(false);
        pepperPic.SetActive(false);
        food = new Dictionary<string, int>();
        food.Add("Tomato", 0);
        food.Add("Salt", 0);
        food.Add("Pepper", 0);
    }

    void Update()
    {
        Debug.Log(food["Tomato"]);
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Big Bread")
        {
            food["Tomato"] += 1;
            Destroy(otherObj.gameObject);
            tomatoPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Salt")
        {
            food["Salt"] += 1;
            Destroy(otherObj.gameObject);
            saltPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Pepper")
        {
            food["Pepper"] += 1;
            Destroy(otherObj.gameObject);
            pepperPic.SetActive(true);
        }
    }
}
