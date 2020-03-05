using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour {

    private int count;
    public GameObject rawFood;
    public GameObject cookedFood;
    private bool zone1; private bool zone2;
    public GameObject strainer; public GameObject pan;

    // Use this for initialization
	void Start ()
    {
        zone1 = true;
        zone2 = false;
        strainer.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mixture")
        {
            Destroy(other.gameObject);
            rawFood.SetActive(true);
        }


        if (count < 5)
        {
            if(other.gameObject.tag == "Spatula" && StoveSwitch.HeatOn)
            {
                if (gameObject.tag == "Pot")
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

                if (gameObject.tag == "Pan")
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
        }

        else
        {
            rawFood.SetActive(false);
            cookedFood.SetActive(true);

            if(gameObject.tag == "Pot")
            {
                strainer.SetActive(true);
                pan.SetActive(true);
            }


        }
    }
}
