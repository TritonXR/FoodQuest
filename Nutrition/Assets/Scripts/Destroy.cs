using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public int Enemy_Health;


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
    }

    void Update()
    {
       if (Enemy_Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has been slayed");
        }
    }
}
