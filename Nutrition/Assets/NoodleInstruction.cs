using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoodleInstruction : MonoBehaviour {


	public Text textt;
	public int stepCount = 0;
	public string[] noodleIns = new string[8] ;

	public void Start(){
		
		noodleIns [0] = "Put water in pot.";
		noodleIns [1] = "Boil water, once boiled, put noodles in side.";
		noodleIns [2] = "Mix ingredients for meat.";
		noodleIns [3] = "Cut mushroom and garlic.";
		noodleIns [4] = "Put all ingredients in to a pan, mix it around until fully cooked.";
		noodleIns [5] = "Place the noodles, and cooked ingredients on a plate.";
		noodleIns [6] = "Much tomatoes into sause.";
		noodleIns [7] = "Mix everything, and enjoy!";
	
	}
		
	public void ChangeText () {

		textt.text = noodleIns [stepCount];

		stepCount++;
		
	}
	

}
