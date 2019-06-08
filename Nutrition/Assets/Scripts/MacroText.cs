using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacroText : MonoBehaviour {

    private string origText;
    private Text text;

	// Use this for initialization
	void Start () {
        origText = "\n3 Oranges = 1 Cup of Juice";
        text = GetComponent<Text>();

        //Reset text on switching/starting macro game
        if(origText != text.text)
        {
            text.text = origText;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateCupText(int fullCup, int partFilledCup)
    {
        text.text = "\nYou have made " + fullCup + " " + partFilledCup + "/3 " + "cups of orange juice.";
    }
}
