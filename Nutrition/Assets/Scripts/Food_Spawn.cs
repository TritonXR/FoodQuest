using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Food_Spawn : MonoBehaviour {

    public GameObject food;

    void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.name;

        if (other.gameObject.tag == "Big Bread")
        {
            Instantiate(food, transform.position, Quaternion.Euler(-90, 0, 0));
        }

        if (other.gameObject.tag == "Seed Roll")
        {
            Instantiate(food, transform.position, Quaternion.Euler(0, 0, 65));
        }

        if (other.gameObject.tag == "Croissant")
        {
            Instantiate(food, transform.position, Quaternion.Euler(0, 0, -90));
        }

        if (other.gameObject.tag == "Danish")
        {
            Instantiate(food, transform.position, Quaternion.Euler(0, 0, 90));
        }
    }
}
