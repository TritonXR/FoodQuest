using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public int Enemy_Health;
    public int Fireball_Health;
    public int cooldown;
    public GameObject food;
    Rigidbody enemy;
    private float timeStamp;

    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        cooldown = 3;

        if (Enemy_Health == 0)
        {
            Enemy_Health = 100;
        }
        
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

        if (otherObj.gameObject.tag == "Iceball")
        {
            Enemy_Health = Enemy_Health - 25;
            Destroy(otherObj.gameObject);
            enemy.constraints = RigidbodyConstraints.FreezeAll;
            timeStamp = Time.time + cooldown;
        }

        if (Enemy_Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(food, transform.position, food.transform.rotation);
            Debug.Log("Enemy has been slayed");
        }
    }

    void Update()
    {
        if (timeStamp <= Time.time)
        {
            enemy.constraints = RigidbodyConstraints.None;
        }
    }
}
