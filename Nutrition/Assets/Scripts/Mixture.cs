using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixture : MonoBehaviour {

    public GameObject noodles; public GameObject noodles2;
    public GameObject sauce;
    public GameObject mixed; public GameObject mixed2;
    public GameObject tomatobowl;
    
    
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
        if(gameObject.tag == "Strainer")
        {
            if(other.gameObject.tag == "Water")
            {
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "Cooked Noodles")
            {
                noodles.SetActive(true);
                Destroy(other.gameObject);
                tomatobowl.SetActive(true);
            }
        }

        if (gameObject.tag == "Pan")
        {
            if (other.gameObject.tag == "mixture")
            {
                mixed.SetActive(true);
                Destroy(other.gameObject);
            }
        }

        if (gameObject.tag == "Plate")
        {
            if (other.gameObject.tag == "Finished Noodles")
            {
                noodles2.SetActive(true);
                Destroy(other.gameObject);
            }
        }

        if (gameObject.tag == "Finished Noodles")
        {
            if (other.gameObject.tag == "Sauce")
            {
                sauce.SetActive(true);
                Destroy(other.gameObject);
            }
        }

        if (gameObject.tag == "FinishedSauce")
        {
            if (other.gameObject.tag == "mixture2")
            {
                mixed2.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }
}
