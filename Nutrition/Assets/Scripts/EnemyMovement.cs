using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private float currTime;
    private float distance;
    private float xdistance;
    private float zdistance;
    public Rigidbody rb;
    private GameObject player;
    public bool isGrounded;
    private float timeStamp;
    public float cooldown = 2.0f;
    public int damp = 5;

    //void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    void Start()
    {
        if (moveSpeed == 0f)
        {
            moveSpeed = 1.0f;
        }
        if (jumpHeight == 0f)
        {
            jumpHeight = 2.0f;
        }

        currTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("can't find player");
        }
        else
        {
            xdistance = player.transform.position.x - transform.position.x;
            zdistance = player.transform.position.y - transform.position.y;
            distance = Mathf.Sqrt(Mathf.Pow(xdistance, 2.0f) + Mathf.Pow(zdistance, 2.0f));
            var rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.forward);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp);

            if (distance > 1.0f)
            {
                //rb.constraints = RigidbodyConstraints.None;
                rb.velocity = Vector3.left * moveSpeed;
                Debug.Log(zdistance);
                //rb.AddForce(transform.forward * moveSpeed);
            }
                
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            rb.constraints = RigidbodyConstraints.None;
            timeStamp = Time.time + cooldown;
        }
    }
}

