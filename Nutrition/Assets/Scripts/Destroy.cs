using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public int Enemy_Health;
    public int Fireball_Health;
    public GameObject food;

    void Start()
    {
        Enemy_Health = 100;
    }
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Weapon")
        {
            Enemy_Health = Enemy_Health - 50;
            Debug.Log("Enemy has been damaged");
        }

        if (otherObj.gameObject.tag == "Fireball")
        {
            Enemy_Health = Enemy_Health - 50;
            Destroy(otherObj.gameObject);
        }


    }

    void Update()
    {
       if (Enemy_Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(food, transform.position, food.transform.rotation);
            //send to inventory
            Debug.Log("Enemy has been slayed");
        }

       

    }
}
