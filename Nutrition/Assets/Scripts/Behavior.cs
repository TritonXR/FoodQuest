using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

    public Transform player;
    public Transform enemy;
    public float speed;
    public int damp = 5;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector3.Distance(transform.position, player.position) > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
            Quaternion rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(enemy.rotation, rotationAngle, Time.deltaTime * damp);

        }       
	}
}
