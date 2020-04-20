using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riceWash : MonoBehaviour {

	private int count;

	public Renderer rend;

	public GameObject RawRice;
	public GameObject water;


	// Use this for initialization
	void Start ()
	{
		count = 0;
		rend = GetComponent<Renderer>();
		rend.enabled = false;
		transform.localScale = new Vector3(2, 0.1f, 2);
		transform.localPosition = new Vector3(-0.7f, -0.7f, 2.2f);
		RawRice.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "RawRice")
		{
			if (other.gameObject.tag == "Water" ) 
			{
				if (count == 0) 
				{
					rend.enabled = true;
					count += 1;
				} 

				else if (count < 2) 
				{
					transform.localScale = new Vector3 (2, transform.localScale.y + 0.1f, 2);
					transform.localPosition = new Vector3 (-0.7f, transform.localPosition.y + 0.1f, 2.2f);
					count += 1;
				} 

				else 
				{
				GameObject.FindGameObjectWithTag ("Faucet").GetComponent<WaterSpawn> ().enabled = false;
				}

			}
		}

		if ( count >= 2)
		{
			Destroy(other.gameObject);
			RawRice.gameObject.tag = "RiceInWater";
		}

		if(other.gameObject.tag == "RiceInWater")
		{
			if(gameObject.tag == "Strainer")
			{
				Destroy(water);
			}
		}
	}
}
