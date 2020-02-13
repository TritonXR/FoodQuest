using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUp : MonoBehaviour {

    public int food_Health;
    public GameObject food;
    Rigidbody enemy;

    // Use this for initialization
    void Start()
    {

        if (food_Health == 0)
        {
            food_Health = 3;
        }
    }

    // The amount of damage that certain weapons will deal
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Weapon")
        {
            food_Health = food_Health - 1;
            Debug.Log("Food has been damaged");
        }

        if (food_Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(food, transform.position, food.transform.rotation);
            Instantiate(food, transform.position, food.transform.rotation);
            Instantiate(food, transform.position, food.transform.rotation);
            Debug.Log("Food has dropped");
        }

    }
}
