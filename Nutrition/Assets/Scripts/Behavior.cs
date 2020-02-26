using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

    private Rigidbody enemy;
    public Transform player;
    public float speed;
    public float angularSpeed;
    public float singleStep;
    private float movementStamp;
    public float cooldown = 1.0f;
    private bool stomp = true;
    private Vector3 targetDirection;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        singleStep = angularSpeed * Time.deltaTime;
        targetDirection = player.position - transform.position;

        if (!AttackSystem.hitStatus)
        {
            if (Vector3.Distance(transform.position, player.position) > 1.5 && Vector3.Distance(transform.position, player.position) < 5)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed);

                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                //transform.rotation = Quaternion.LookRotation(newDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), angularSpeed * Time.deltaTime);
            }
        }

        else
        {
            if (stomp)
            {
                movementStamp = Time.time + cooldown;
                stomp = false;
            }

            enemy.velocity = new Vector3(0, 0, 1);

            if (movementStamp <= Time.time)
            {
                AttackSystem.hitStatus = false;
                stomp = true;
            }
        }
    }
}
