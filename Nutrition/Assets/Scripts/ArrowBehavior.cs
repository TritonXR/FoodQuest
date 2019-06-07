using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    private GameObject player;
    private GameObject arrowModel;
    private float distance;
    private Vector3 tempPos;
    private Vector3 origPos;

    public float freq = 1f;
    public float ampli = 0.5f;
    public float damp = 0.1f;

	// Use this for initialization
	void Start () {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        arrowModel = transform.GetChild(0).gameObject;
        origPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position, player.transform.position);

        //if distance between player and arrow is within 3ft and the arrow is on
        if (distance <= 3 && arrowModel.activeSelf)
        {
            arrowModel.SetActive(false);
        }
        //if player is past 3ft of arrow and arrow is off
        else if(distance > 3 && !arrowModel.activeSelf)
        {
            arrowModel.SetActive(true);
        }

        //transform.LookAt(player.transform.position);
        Quaternion rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position);
        rotationAngle.z = 0;
        rotationAngle.x = 0;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp);
        transform.rotation = rotationAngle;

        //Use sin wave to make arrow float
        //P.S. MATH!!!!
        tempPos = origPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * ampli;
        transform.position = tempPos;

    }
}
