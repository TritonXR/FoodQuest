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
    public float freezeCooldown = 5.0f;
    public float freezeStamp = 0.0f;
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

        if (!AttackSystem.hitStatus && !AttackSystem.freezeStatus)
        {
            if (Vector3.Distance(transform.position, player.position) > 1 && Vector3.Distance(transform.position, player.position) < 7.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), angularSpeed * Time.deltaTime);

                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                //transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        else if (AttackSystem.freezeStatus)
        {
            enemy.constraints = RigidbodyConstraints.FreezeAll;

            freezeStamp += Time.deltaTime;

            if (freezeStamp >= freezeCooldown)
            {
                enemy.constraints = RigidbodyConstraints.None;
                AttackSystem.freezeStatus = false;
                freezeStamp = 0;
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

        //Debug.Log(freezeStamp);
    }
}
