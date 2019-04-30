using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueImpMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float waitTime;
    private float currTime;
    private float distance;
    private Rigidbody rb;
    private GameObject player;
    private float rotX;
    private float rotZ;

    // Use this for initialization
    void Start () {
        if(moveSpeed == 0f)
        {
            moveSpeed = 1.0f;
        }
        if(waitTime == 0f)
        {
            waitTime = 2.0f;
        }
        if(jumpHeight == 0f)
        {
            jumpHeight = 5.0f;
        }
        
        currTime = Time.time;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 1000, 0);
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
            
           //moveTo = transform.forward;
           // if(transform.position.y > .5f)
           // {
           //     moveTo.y = 0f;
           // }

            if (distance > 2f) {
                //if (distance > 2f)
                //{
                rb.constraints = RigidbodyConstraints.None;
                //rb.velocity = moveTo * moveSpeed;
                //}              
            }
            else
            {
                //rot.x = rotX;
                //rot.z = rotZ;

                rb.constraints = RigidbodyConstraints.FreezePosition;

            }
            transform.rotation = rot;
            //rotX = rot.x;
            //rotZ = rot.z;



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
