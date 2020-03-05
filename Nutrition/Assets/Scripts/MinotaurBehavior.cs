using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBehavior : MonoBehaviour {

    private Rigidbody enemy;
    public Transform player;
    public float speed;
    public float angularSpeed;
    private float singleStep;
    private float locationStamp = 0.0f;
    private float chargeStamp = 0.0f;
    public float chargeCooldown = 3.0f;
    public float locationCooldown = 3.0f;
    public float freezeCooldown = 5.0f;
    public float freezeStamp = 0.0f;
    private bool stomp = true;
    private float movementStamp;
    private Vector3 targetDirection;
    public float cooldown = 1.0f;

    private bool locationBoolean;
    private bool chargeBoolean;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GetComponent<Rigidbody>();
        locationBoolean = true;
        chargeBoolean = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!AttackSystem.hitStatus && !AttackSystem.freezeStatus)
        {
            if (locationBoolean)
            {
                chargeStamp = 0;

                if (locationStamp <= locationCooldown)
                {
                    //targetDirection = player.position - transform.position;
                    //singleStep = angularSpeed * Time.deltaTime;
                    //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    //transform.rotation = Quaternion.LookRotation(newDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), angularSpeed * Time.deltaTime);
                }

                if (locationStamp >= 3)
                {
                    locationBoolean = false;
                    chargeBoolean = true;
                }

                locationStamp += Time.deltaTime;
            }


            if (chargeBoolean)
            {
                locationStamp = 0;

                if (chargeStamp <= chargeCooldown)
                {
                    enemy.AddRelativeForce(Vector3.forward * speed);
                }

                if (chargeStamp >= 3)
                {
                    locationBoolean = true;
                    chargeBoolean = false;
                }

                chargeStamp += Time.deltaTime;
            }
        }

        else if (AttackSystem.freezeStatus)
        {
            enemy.constraints = RigidbodyConstraints.FreezeAll;

            freezeStamp += Time.deltaTime;
            locationBoolean = false;
            chargeBoolean = false;

            if (freezeStamp >= freezeCooldown)
            {
                enemy.constraints = RigidbodyConstraints.None;
                AttackSystem.freezeStatus = false;
                freezeStamp = 0;
                locationBoolean = true;
                chargeBoolean = false;
            }
        }

        else
        {
            locationBoolean = false;
            chargeBoolean = false;

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
                locationBoolean = false;
                chargeBoolean = true;
            }
        }
    }
}
