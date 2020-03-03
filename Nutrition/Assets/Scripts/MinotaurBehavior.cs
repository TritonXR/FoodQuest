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
    private Vector3 targetDirection;

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
        if (locationBoolean)
        {
            chargeStamp = 0;

           if(locationStamp <= locationCooldown)
           {
                //targetDirection = player.position - transform.position;
                //singleStep = angularSpeed * Time.deltaTime;
                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                //transform.rotation = Quaternion.LookRotation(newDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), angularSpeed * Time.deltaTime);
            }

            if(locationStamp >= 3)
            {
                locationBoolean = false;
                chargeBoolean = true;
            }

            locationStamp += Time.deltaTime;
        }


        if (chargeBoolean)
        {
            locationStamp = 0;

            if(chargeStamp <= chargeCooldown)
            {
                enemy.AddRelativeForce(Vector3.forward * speed);
            }

            if(chargeStamp >= 3)
            {
                locationBoolean = true;
                chargeBoolean = false;
            }

            chargeStamp += Time.deltaTime;
        }

    }
}
