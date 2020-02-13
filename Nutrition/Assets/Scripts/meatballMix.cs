using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatballMix : MonoBehaviour 
{

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
		}

		if (other.gameObject.tag == "Pepper") {
			stuffInPlate [1] = other.gameObject.tag; 
		}

		if (other.gameObject.tag == "Salt") {
			stuffInPlate [2] = other.gameObject.tag; 
		}

		if (other.gameObject.tag == "leftHand"){
			stuffInPlate [3] = other.gameObject.tag;
			count++;
			}

		if (other.gameObject.tag == "rightHand"){
			stuffInPlate [4] = other.gameObject.tag; 
			countt++;
		}
			

		if (count == 3 && countt == 3) {
			ges = true;

		}

		if (ges) {
			bool meatballl = CanMake ();
			if (meatballl)
				meatball.SetActive (true);
		}
	
	}


	void onTriggerExit(Collider other)
	{
		
		for (int i = 0; i <= stuffInPlate.Length; i++) {
			if(other.gameObject.tag == stuffInPlate[i])
				stuffInPlate = RemoveIndices (stuffInPlate, i);
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


	private bool CanMake()
	{
		for(int i = 0; i<stuffInPlate.Length; i++)
		{
			if (stuffInPlate [i] == null)
				return false;	
		}
			
		return true;
	}


}
