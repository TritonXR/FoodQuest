using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int food;

    void Start()
    {
        food = 0;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hand")
        {
            Destroy(gameObject);
            food = food + 1;
            print("Item Collected");
        }
    }
}
