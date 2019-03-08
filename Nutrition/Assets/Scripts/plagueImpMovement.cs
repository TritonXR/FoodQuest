using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plagueImpMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float waitTime;
    private float currTime;
    private float distance;
    private Rigidbody rb;
    private GameObject player;

    // Use this for initialization
    void Start () {
        moveSpeed = 1.0f;
        waitTime = 2.0f;
        jumpHeight = 5.0f;
        currTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("can't find player");
        }
        else
        {
            Vector3 relativePos = player.transform.position - transform.position;
            distance = Vector3.Distance(player.transform.position, transform.position);
            Quaternion rot = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rot;

            if (distance > 2f) {
                rb.velocity = transform.forward * moveSpeed;
            } else
            {
                rb.velocity = Vector3.zero;
            }
            //transform.LookAt(player.transform);
            /*
            if (Time.time >= currTime)
            {
                Vector3 direction = transform.forward;
                rb.velocity = new Vector3(0, jumpHeight, 0);
                rb.velocity = new Vector3(direction.x, jumpHeight, direction.z);
                currTime += waitTime;
                if (Time.time >= currTime)
                {
                    currTime = Time.time + waitTime;
                }
            }
            */
        }
    }
}
