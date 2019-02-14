using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public int Health;


    void Start()
    {
        Health = 100; 
    }
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Weapon")
        {
            Health = Health - 50;
            Debug.Log("I have been damaged");
        }
    }

    void Update()
    {
       if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
