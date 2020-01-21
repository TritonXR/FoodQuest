using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public static int tomato = 0;
    public GameObject tomatoPic;


    void Start()
    {
        tomatoPic.SetActive(false);
        Dictionary<int, string> food = new Dictionary<int, string>();
        food.Add(1, "Tomato");
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Big Bread")
        {
            tomato += 1;
            Destroy(otherObj.gameObject);
            Debug.Log(tomato);
            tomatoPic.SetActive(true);
        }
    }
}
