using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int Player_Health;
    public int Shield_Health;

	// Use this for initialization
	void Start ()
    {
        Shield_Health = 150;
        Player_Health = 200;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (gameObject.tag == "Shield")
            {
                Shield_Health = Shield_Health - 50;
                Debug.Log("The Shield is weakened");
            }
            else if (gameObject.tag == "Player")
            {
                Player_Health = Player_Health - 50;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Shield_Health <= 0)
        {
            if (gameObject.tag == "Shield")
            {
                Destroy(gameObject);
                Debug.Log("The Shield is down");
            }
        }
	}
}
