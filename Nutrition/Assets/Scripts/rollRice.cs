using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollRice : MonoBehaviour {

	public GameObject riceFlat;
	public GameObject riceHalfRoll;
	public GameObject riceRoll;
	private int count = 0;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(count == 0 && other.gameObject.tag == "rightHand" && other.gameObject.tag == "leftHand")
		{
			riceFlat.SetActive(false);
			riceHalfRoll.SetActive(true);

			count++;
		}

		else 
			if(count == 1 && other.gameObject.tag == "rightHand" && other.gameObject.tag == "leftHand")
			{
				riceHalfRoll.SetActive(false);
				riceRoll.SetActive(true);

				count++;
			}


	
	}
}
