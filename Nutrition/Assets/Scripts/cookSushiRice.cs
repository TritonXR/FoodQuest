using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cookSushiRice : MonoBehaviour {

	private int count = 0;
	private bool zone1; private bool zone2; private bool mix;
	public GameObject sushiRiceN;
	// Use this for initialization
	void Start () 
	{
		zone1 = true;
		zone2 = false;
		mix = false;

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "SushiRiceN")
		{
			mix = true;
		}


		if (mix == true)
		{
			if (count < 3)
			{
				if(other.gameObject.tag == "Spatula" && StoveSwitch.HeatOn)
				{
					if (zone1)
					{
						transform.localPosition = new Vector3(-0.005f, 0f, 0.005f);
						zone1 = false;
						zone2 = true;
					}	

					else if (zone2)
					{
						transform.localPosition = new Vector3(0.007f, 0f, 0.0026f);
						zone1 = true;
						zone2 = false;
						count += 1;
					}
				}
			}


			else if(count >= 3)
			{
				sushiRiceN.gameObject.tag = "SushiRice";
			}
		}
	}
}
