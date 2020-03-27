using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public GameObject tomatoPic;
    public GameObject saltPic;
    public GameObject pepperPic;
    public GameObject mushroomPic;
    public GameObject garlicPic;
    public GameObject beefPic;
    public GameObject noodlePic;

    public static Dictionary<string, int> food;


    void Start()
    {
        tomatoPic.SetActive(false);
        saltPic.SetActive(false);
        pepperPic.SetActive(false);
        mushroomPic.SetActive(false);
        garlicPic.SetActive(false);
        beefPic.SetActive(false);
        noodlePic.SetActive(false);
        food = new Dictionary<string, int>
        {
            { "Tomato", 0 },
            { "Salt", 0 },
            { "Pepper", 0 },
            { "Mushroom", 0 },
            { "Garlic", 0 },
            { "Beef", 0 },
            { "Noodles", 0 }
        };
    }

    void Update()
    {
       
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Tomato")
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

        if (otherObj.gameObject.tag == "Mushroom")
        {
            food["Mushroom"] += 1;
            Destroy(otherObj.gameObject);
            mushroomPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Garlic")
        {
            food["Garlic"] += 1;
            Destroy(otherObj.gameObject);
            garlicPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Beef")
        {
            food["Beef"] += 1;
            Destroy(otherObj.gameObject);
            beefPic.SetActive(true);
        }

        if (otherObj.gameObject.tag == "Noodles")
        {
            food["Noodles"] += 1;
            Destroy(otherObj.gameObject);
            noodlePic.SetActive(true);
        }
    }
}
