using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Behavior : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float waitTime;
    private float currTime;
    private Rigidbody rb;
    private GameObject player;

	// Use this for initialization
	void Start() {
        moveSpeed = 1.0f;
        waitTime = 2.0f;
        jumpHeight = 3.0f;
        currTime = Time.time;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.LookAt(player.transform);
        if(Time.time >= currTime)
        {
            Vector3 direction = transform.forward;
            rb.velocity = new Vector3(direction.x, jumpHeight, direction.z);
            currTime += waitTime;
            if(Time.time >= currTime)
            {
                currTime = Time.time + waitTime;
            }
        }
    }

    IEnumerator Jump(float time)
    {
        yield return new WaitForSeconds(time);
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
