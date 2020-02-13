using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatballMix : MonoBehaviour 
{

	bool beeff = false;
	bool saltt = false;
	bool pepperr = false;
	bool ingre = false;
	bool ges = false;
	int count = 0;
	int countt = 0;
	public string[] stuffInPlate;
	public GameObject meatball;

	// Use this for initialization
	void onTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Beef") {

			stuffInPlate [0] = other.gameObject.tag; 
			beeff = true;
		}

		if (other.gameObject.tag == "Pepper") {
			stuffInPlate [1] = other.gameObject.tag; 
			pepperr = true;
		}

		if (other.gameObject.tag == "Salt") {
			stuffInPlate [2] = other.gameObject.tag; 
			saltt = true;
		}

		if (other.gameObject.tag == "leftHand"){
			stuffInPlate [3] = other.gameObject.tag;
			count++;
			}

		if (other.gameObject.tag == "rightHand"){
			stuffInPlate [4] = other.gameObject.tag; 
			countt++;
		}

		if (beeff && saltt && pepperr) {
			ingre = true;
		}

		if (count == 3 && countt == 3) {
			ges = true;

		}

		if (ingre && ges) {
			meatball.SetActive (true);
		}
	}


	void onTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "leftHand"){
			stuffInPlate = RemoveIndices (stuffInPlate, 3);
		}

		if (other.gameObject.tag == "rightHand"){
			stuffInPlate = RemoveIndices (stuffInPlate, 4);
		}
	}

	private string[] RemoveIndices(string[] IndicesArray, int RemoveAt)
	{
		string[] newIndicesArray = new string[IndicesArray.Length];

		int i = 0;
		while (i < IndicesArray.Length)
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
}
