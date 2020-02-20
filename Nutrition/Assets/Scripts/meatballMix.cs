using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatballMix : MonoBehaviour 
{

	int count = 0;
	public GameObject[] stuffInPlate = new GameObject[4];
	public string[] stuffInPlateName = new string[4] ;
	public GameObject meatball;

	// Use this for initialization
	void onTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Beef") {

			stuffInPlate [0] = other.gameObject; 
			stuffInPlateName [0] = other.gameObject.tag;
		}

		if (other.gameObject.tag == "Pepper") {
			stuffInPlate [1] = other.gameObject; 
			stuffInPlateName [1] = other.gameObject.tag;
		}

		if (other.gameObject.tag == "Salt") {
			stuffInPlate [2] = other.gameObject; 
			stuffInPlateName [2] = other.gameObject.tag;
		}

		if (other.gameObject.tag == "leftHand"){
			stuffInPlate [3] = other.gameObject;
			stuffInPlateName [3] = other.gameObject.tag;
			count++;
		}

		/*
		if (other.gameObject.tag == "rightHand"){
			stuffInPlate [4] = other.gameObject; 
			stuffInPlateName [4] = other.gameObject.tag;
			countt++;
		}
       */


		if (count == 3) {

			if (CanMake ()) {

				meatball.SetActive (true);

				count = 0;

				for (int i = 0; i < 3; i++) {

					Destroy (stuffInPlate [i].gameObject);
				}
			}
		}

	}


	void onTriggerExit(Collider other)
	{

		for (int i = 0; i < 3; i++) {
			if (other.gameObject.tag == stuffInPlateName [i])
				stuffInPlateName [i] = null;

		}

	}

	/*
	private string[] RemoveIndices(string[] IndicesArray, int RemoveAt)
	{
		string[] newIndicesArray = new string[4];

		int i = 0;
		while (i < 3)
		{
			if (i != RemoveAt)
			{
				newIndicesArray[i] = IndicesArray[i];
				i++;
			}

			newIndicesArray [i] = null;
			i++;
		}

		return newIndicesArray;
	}
	*/


	private bool CanMake()
	{
		for(int i = 0; i < 3; i++)
		{
			if (stuffInPlateName [i] == null)
				return false;	
		}

		return true;
	}


}
