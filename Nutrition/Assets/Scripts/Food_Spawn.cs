using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Food_Spawn : MonoBehaviour {

    public GameObject food;
    public GameObject plate;
    public disableController gameController;
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

        if (other.gameObject.tag == "Orange")
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
                GameObject newFood = Instantiate(food, transform.position, Quaternion.Euler(-90, 0, 0));
                gameController.addCalObj(newFood.GetComponent<disableCalorie>());
            }
        }
        if (other.gameObject.tag == "Seed Roll")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                GameObject newFood = Instantiate(food, transform.position, Quaternion.Euler(0, 0, 65));
                gameController.addCalObj(newFood.GetComponent<disableCalorie>());
            }
        }

        if (other.gameObject.tag == "Croissant")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                GameObject newFood = Instantiate(food, transform.position, Quaternion.Euler(0, 0, -90));
                gameController.addCalObj(newFood.GetComponent<disableCalorie>());
            }
        }

        if (other.gameObject.tag == "Danish")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                GameObject newFood = Instantiate(food, transform.position, Quaternion.Euler(0, 0, 90));
                gameController.addCalObj(newFood.GetComponent<disableCalorie>());
            }
        }

        if(other.gameObject.tag == "Orange")
        {
            bread = bread - 1;
            if (bread < 1)
            {
                GameObject newOrange = Instantiate(food, transform.position, Quaternion.Euler(0, 0, 0));
                /*
                GameObject newOrange = Instantiate(food, new Vector3(1000,1000,1000), Quaternion.Euler(0, 0, 0));
                newOrange.transform.SetParent(food.transform.parent);
                newOrange.transform.localScale = new Vector3(.2f, .2f, .2f);
                newOrange.transform.position = plate.transform.position + new Vector3(0, 0.2f, 0);
                */
            }
        }
    }
}
