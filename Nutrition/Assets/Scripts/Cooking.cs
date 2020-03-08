using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour {

    private int count;
    public GameObject rawFood;
    public GameObject cookedFood;
    private bool zone1; private bool zone2;
    public GameObject strainer; public GameObject pan;
    public GameObject plate;
    public AudioClip correct;
    private AudioSource ears;
    public Text instructions;

    // Use this for initialization
    void Start ()
    {
        zone1 = true;
        zone2 = false;
        ears = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mixture")
        {
            other.gameObject.SetActive(false);
            rawFood.SetActive(true);
            instructions.text = "Now, stir the mixed ingredients until they are mixed.";
        }


        if (count < 5)
        {
            if(other.gameObject.tag == "Spatula" && StoveSwitch.HeatOn)
            {
                if (gameObject.tag == "Pot" || gameObject.tag == "Sauce Pot")
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
        }

        else if(count >= 5)
        {
            rawFood.SetActive(false);
            cookedFood.SetActive(true);

            if(gameObject.tag == "Pot")
            {
                strainer.SetActive(true);
                ears.PlayOneShot(correct);
                instructions.text = "Now, take the pot and drain the noodles using the strainer.";
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            if (gameObject.tag == "Sauce Pot")
            {
                pan.SetActive(true);
                ears.PlayOneShot(correct);
                instructions.text = "Now, take the mixed ingredients and put them on the pan.";
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            if (gameObject.tag == "Pan")
            {
                plate.SetActive(true);
                ears.PlayOneShot(correct);
                instructions.text = "Since, everything is finished take the noodles from the strainer and place it on the plate.";
                gameObject.GetComponent<BoxCollider>().enabled = false;

            }


        }
    }
}
