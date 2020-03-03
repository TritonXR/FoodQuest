using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUp : MonoBehaviour {

    public int food_Health;
    private Vector3 originalSize;
    private Vector3 originalPosition;
    public GameObject food;
    Rigidbody enemy;

    [SerializeField]
    private string tag;

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
        if (otherObj.gameObject.tag == "Sword")
        {
            food_Health = food_Health - 1;
            Debug.Log("Food has been damaged");
        }

        if (food_Health <= 0)
        {
            GameObject drop;
            Destroy(gameObject);
            Vector3 newPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 0.5f);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            newPosition = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 0.5f);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            Debug.Log("Food has dropped");
        }

    }
}
