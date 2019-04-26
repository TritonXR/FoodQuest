using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Food_Spawn : MonoBehaviour {

    public GameObject food;
    public int bread;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Big Bread")
        {
            bread = bread + 1;
        }

        if (other.gameObject.tag == "Seed Roll")
        {
            bread = bread + 1;
        }

        if (other.gameObject.tag == "Croissant")
        {
            bread = bread + 1;
        }

        if (other.gameObject.tag == "Danish")
        {
            bread = bread + 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //string name = other.gameObject.name;
        if (other.gameObject.tag == "Big Bread")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                Instantiate(food, transform.position, Quaternion.Euler(-90, 0, 0));
            }
        }
        if (other.gameObject.tag == "Seed Roll")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                Instantiate(food, transform.position, Quaternion.Euler(0, 0, 65));
            }
        }

        if (other.gameObject.tag == "Croissant")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                Instantiate(food, transform.position, Quaternion.Euler(0, 0, -90));
            }
        }

        if (other.gameObject.tag == "Danish")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                Instantiate(food, transform.position, Quaternion.Euler(0, 0, 90));
            }
        }
    }
}
