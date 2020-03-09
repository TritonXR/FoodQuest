using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoSauce : MonoBehaviour {

	// Use this for initialization
	int count = 0;
	public GameObject[] stuffInPlate = new GameObject[2];
	public string[] stuffInPlateName = new string[2] ;
	public GameObject mushedTomato; public GameObject pot2;

    public AudioClip correct;
    private AudioSource ears;
    public Text ingredients;

    void Start()
	{
        ears = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Tomato") {

			stuffInPlate [0] = other.gameObject; 
			stuffInPlateName [0] = other.gameObject.tag;
		}
			

		if (other.gameObject.tag == "leftHand") {
			stuffInPlate [1] = other.gameObject;
			stuffInPlateName [1] = other.gameObject.tag;
			count++;
		}

		Debug.Log (stuffInPlateName);
		/*
		if (other.gameObject.tag == "rightHand"){
			stuffInPlate [4] = other.gameObject; 
			stuffInPlateName [4] = other.gameObject.tag;
			countt++;
		}
       */
		if (count == 3) {

			if (CanMake ())
            {

				count = 4;

				Destroy (stuffInPlate [0].gameObject);

                pot2.SetActive(true);
                mushedTomato.SetActive(true);
                ears.PlayOneShot(correct);
                ingredients.text = "Now, put the sauce inside of the pot";
            }

		}
	}


	void OnTriggerExit(Collider other)
	{

		for (int i = 0; i < 1; i++) {
			if (other.gameObject.tag == stuffInPlateName [i])
				stuffInPlateName [i] = null;
		}

	}


	private bool CanMake()
	{
		for(int i = 0; i < 1; i++)
		{
			if (stuffInPlateName [i] == null)
				return false;	
		}

		return true;
	}


}
