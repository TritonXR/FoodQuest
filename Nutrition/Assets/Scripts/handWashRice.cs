using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handWashRice : MonoBehaviour {

	private int count = 0;
	public GameObject riceInWater;
	private bool zone1; private bool zone2;

	// Use this for initialization
	void Start ()
	{
		zone1 = true;
		zone2 = false;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter(Collider other)
	{

		if (count < 3)
		{

			if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand") 
			{
				
				if (other.gameObject.tag == "Water" && other.gameObject.tag == "riceInWater")
				{
					
					if (zone1) 
					{
						transform.localPosition = new Vector3 (-0.4f, -0.1f, 1.6f);
						zone1 = false;
						zone2 = true;
					} 
					else if (zone2) 
					{
						transform.localPosition = new Vector3 (-0.8f, -0.2f, 3.0f);
						zone1 = true;
						zone2 = false;
						count += 1;
					}
				}
					
			}
		}
	

		else if(count >= 3)
		{
			riceInWater.gameObject.tag = "RiceWashed";
		}
	}
}


