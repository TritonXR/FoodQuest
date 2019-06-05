using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy : MonoBehaviour {

    public int Enemy_Health;
    public int Fireball_Health;
    public int cooldown;
    public GameObject food;
    Rigidbody enemy;
    private float timeStamp;
    private bool destroyedAlready;

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        destroyedAlready = false;
        enemy = GetComponent<Rigidbody>();
        cooldown = 3;

        if (Enemy_Health == 0)
        {
            Enemy_Health = 100;
        }
        
    }
    // The amount of damage that certain weapons will deal
    void OnCollisionEnter(Collision otherObj)
    {

        if (otherObj.gameObject.tag == "Weapon")
        {
            Enemy_Health = Enemy_Health - 50;
            Debug.Log("Enemy has been damaged");

        }

        if (otherObj.gameObject.tag == "Rage Sword")
        {
            Enemy_Health = Enemy_Health - 100;
            Debug.Log("Enemy has been damaged");
      
        }

        if (otherObj.gameObject.tag == "Rage Shield")
        {
            Enemy_Health = Enemy_Health - 25;
            Debug.Log("Enemy has been damaged");
        }

        if (otherObj.gameObject.tag == "Fireball")
        {
            Enemy_Health = Enemy_Health - 50;
            Destroy(otherObj.gameObject);
        }

        if (otherObj.gameObject.tag == "Iceball")
        {
            Enemy_Health = Enemy_Health - 25;
            Destroy(otherObj.gameObject);
            enemy.constraints = RigidbodyConstraints.FreezeAll;
            timeStamp = Time.time + cooldown;
        }

        if (Enemy_Health <= 0)
        {

            // Instantiate(food, transform.position, food.transform.rotation);

            Debug.Log("Enemy has been slayed");
            Destroy(gameObject);

            food.SetActive(true);
            Debug.Log("food is " + food.activeSelf);
        }

    }
    //Will freeze the opponent for 3 seconds if hit by iceball
    void Update()
    {
        if (timeStamp <= Time.time)
        {
            //enemy.constraints = RigidbodyConstraints.None;
        }
    }
}
