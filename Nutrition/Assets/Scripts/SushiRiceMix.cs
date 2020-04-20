using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiRiceMix : MonoBehaviour {

	private int count = 0;
	private bool zone1; private bool zone2; private bool mix;
<<<<<<< HEAD
<<<<<<< HEAD
	public GameObject plate;
    public Material sauced;
    public GameObject sauce;
    public Renderer rice;
=======
	public GameObject plainRice;
>>>>>>> 6a983bf8a47377a8ab9f0751ba475da79f2000f5
=======
	public GameObject pan;
>>>>>>> parent of 33b9918... sushirice

	// Use this for initialization
	void Start () 
	{
		zone1 = true;
		zone2 = false;
		mix = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{
<<<<<<< HEAD
<<<<<<< HEAD
		if(other.gameObject.tag == "Vinegar Sauce")
=======
		if(other.gameObject.tag == "Vinegar" && other.gameObject.tag == "Rice" )
>>>>>>> 6a983bf8a47377a8ab9f0751ba475da79f2000f5
=======
		if(other.gameObject.tag == "Vinegar")
>>>>>>> parent of 33b9918... sushirice
		{
			mix = true;
            Destroy(other.gameObject);
            sauce.SetActive(true);
		}


		if (mix == true)
		{
			if (count < 3)
			{
				if(other.gameObject.tag == "Spatula")
				{
					if (zone1)
					{
						transform.localPosition = new Vector3(-0.4f, -0.1f, 1.6f);
						zone1 = false;
						zone2 = true;
					}

					else if (zone2)
					{
						transform.localPosition = new Vector3(-0.8f, -0.2f, 3.0f);
						zone1 = true;
						zone2 = false;
						count += 1;
					}
				}
			}

			else if(count >= 3)
			{
<<<<<<< HEAD
<<<<<<< HEAD
				gameObject.GetComponent<BoxCollider> ().enabled = false;
                Destroy(sauce);
                rice.material = sauced;
=======
				plainRice.gameObject.tag = "SushiRiceN";
>>>>>>> 6a983bf8a47377a8ab9f0751ba475da79f2000f5
=======
				gameObject.GetComponent<BoxCollider> ().enabled = false;

>>>>>>> parent of 33b9918... sushirice
			}
		}
	}
}
