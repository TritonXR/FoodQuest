using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public static int tomato = 0;


    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Big Bread")
        {
            tomato += 1;
            Destroy(otherObj.gameObject);
            Debug.Log(tomato);
        }
    }
}
