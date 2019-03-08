using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Food_Spawn : MonoBehaviour {

    public GameObject food;

    void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.name;

        if (other.gameObject.tag == "Bread")
        {
            Instantiate(food, transform.position, transform.rotation);
        }
            
    }
}
