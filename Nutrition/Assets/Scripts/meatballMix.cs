using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatballMix : MonoBehaviour 
{

	int count = 0;
	public GameObject[] stuffInPlate = new GameObject[4];
	public string[] stuffInPlateName = new string[4] ;
	public GameObject meatball; public GameObject knife;
    public GameObject Cutting1; public GameObject Cutting2;
    public GameObject mushrooms; public GameObject garlic;
    public GameObject spatula;
    public Text instructions;
    private bool mush; private bool gar;

    public GameObject pot; public GameObject noodlebowl;

    void Start()
    {
        mush = false;
        gar = false;
        pot.SetActive(false);
        noodlebowl.SetActive(false);
        spatula.SetActive(false);
    }

    // Use this for initialization
    void OnTriggerEnter(Collider other)
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

        Debug.Log(stuffInPlateName);
		/*
		if (other.gameObject.tag == "rightHand"){
			stuffInPlate [4] = other.gameObject; 
			stuffInPlateName [4] = other.gameObject.tag;
			countt++;
		}
       */
		if (count == 3)
        {

			if (CanMake ())
            {

                Instantiate(meatball, transform.position, transform.rotation);
                count = 4;

				for (int i = 0; i < 3; i++) {

					Destroy (stuffInPlate [i].gameObject);
				}
                Cutting1.SetActive(true);
                Cutting2.SetActive(true);
                knife.SetActive(true);
                instructions.text = "Next, cut the mushrooms and garlic. Once cut, pick up the plate using the grip button and drop them with the grip button into the bowl.";
            }
        }

        else if (count >= 3)
        {
            if (other.gameObject.tag == "CutMushroom")
            {
                Destroy(other.gameObject);
                mushrooms.SetActive(true);
                mush = true;
            }

            if (other.gameObject.tag == "CutGarlic")
            {
                Destroy(other.gameObject);
                garlic.SetActive(true);
                gar = true;
            }
        }

	}


	void OnTriggerExit(Collider other)
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


    void Update()
    {
        if(gar && mush)
        {
            pot.SetActive(true);
            noodlebowl.SetActive(true);
            spatula.SetActive(true);
            instructions.text = "Now, fill up water using the faucet, put the noodles inside the pot, and set it to boil on the stove.";
        }
    }

}
