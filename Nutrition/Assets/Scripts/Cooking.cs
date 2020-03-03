using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour {

    private int count;
    public GameObject rawFood;
    public GameObject cookedFood;
    private bool zone1; private bool zone2; 
    
    // Use this for initialization
	void Start ()
    {
        zone1 = true; zone2 = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(count < 5)
        {
            if(other.gameObject.tag == "Spatula")
            {
                if (zone1)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    zone1 = false;
                    zone2 = true;
                }

                if (zone2)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    zone1 = true;
                    zone2 = false;
                    count += 1;
                }
            }
        }

        else
        {
            rawFood.SetActive(false);
            cookedFood.SetActive(true);
        }
    }
}
