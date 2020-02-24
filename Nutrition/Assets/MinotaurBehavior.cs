using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBehavior : MonoBehaviour {

    private Rigidbody enemy;
    public Transform player;
    public float speed;
    public float angularSpeed;
    public float singleStep;
    private float chargeStamp;
    public float chargeCooldown = 5.0f;
    private Vector3 targetDirection;

    public Animator anime;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        targetDirection = player.position - transform.position;
        singleStep = angularSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetDirection, speed);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        anime.SetFloat("Speed", singleStep);
    }
}
