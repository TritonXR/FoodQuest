using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

    public Transform player;
    public Transform enemy;
    public float speed;
    public float angularSpeed;
    public int damp = 5;
    public float singleStep;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        singleStep = angularSpeed * Time.deltaTime;
        Vector3 targetDirection = player.position - transform.position;

        if (Vector3.Distance(transform.position, player.position) > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            //Quaternion rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(enemy.rotation, rotationAngle, Time.deltaTime * damp);
        }
    }
}
