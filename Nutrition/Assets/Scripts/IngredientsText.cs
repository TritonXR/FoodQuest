using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class IngredientsText : MonoBehaviour {

	public Text ingredientsText; 
	public int playerIngredients; 
	public int ingredientsNeeded; 
	private float fraction; 
	public string ingredientName; 
	
	void Start () {
		    fraction = playerIngredients/ingredientsNeeded; 

	}
	
	// Update is called once per frame
	void Update () {
		ingredientsText.text = playerIngredients + "/" + ingredientsNeeded + " " + ingredientName; 
		
		if (fraction >= 1) {
			ingredientsText.color = Color.green; 
		}
		else {
			ingredientsText.color = Color.red; 
		}
		
	}
}
