using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mixture : MonoBehaviour {

    public GameObject noodles; public GameObject noodles2;
    public GameObject sauce;
    public GameObject mixed; public GameObject mixed2;
    public GameObject tomatobowl;
    public Material sauced;
    public Renderer noodless;
    public AudioClip correct;
    private AudioSource ears;
    public Text instructions;


    // Use this for initialization
    void Start ()
    {
        ears = GetComponent<AudioSource>();
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
                other.gameObject.SetActive(false);
            }

            if(other.gameObject.tag == "Cooked Noodles")
            {
                noodles.SetActive(true);
                other.gameObject.SetActive(false);
                tomatobowl.SetActive(true);
                ears.PlayOneShot(correct);
                instructions.text = "Now, use put the tomato into the bowl and mush it into a paste while using your hands.";
            }
        }

        if (gameObject.tag == "Pan")
        {
            if (other.gameObject.tag == "mixture")
            {
                mixed.SetActive(true);
                other.gameObject.SetActive(false);
                tomatobowl.SetActive(true);
                ears.PlayOneShot(correct);
                instructions.text = "Now, stir it around until the mixture is cooked";
            }
        }

        if (gameObject.tag == "Plate")
        {
            if (other.gameObject.tag == "Finished Noodles")
            {
                noodles2.SetActive(true);
                other.gameObject.SetActive(false);
                noodles.tag = "Done Noodles";
                ears.PlayOneShot(correct);
                instructions.text = "Take the sauce pot and put the sauce on the noodles.";
            }
        }

        if (gameObject.tag == "Done Noodles")
        {
            if (other.gameObject.tag == "Finished Sauce")
            {
                noodless.material = sauced;
                other.gameObject.SetActive(false);
                gameObject.tag = "Sauced Noodles";
                ears.PlayOneShot(correct);
                instructions.text = "Finally, put the mixture with the sauced noodles";
            }
        }

        if (gameObject.tag == "Sauced Noodles")
        {
            if (other.gameObject.tag == "Finished Mixture")
            {
                mixed2.SetActive(true);
                other.gameObject.SetActive(false);
                ears.PlayOneShot(correct);
                instructions.text = "Congratulations, you have created the noodles.";
            }
        }
    }
}
