using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSushiIngredients : MonoBehaviour {

	public GameObject salmon;
	public GameObject avocado; 
	public GameObject cucumber; 

	//other is the object colliding into the collider
	void OnTriggerEnter(Collider other) {
		salmon.SetActive(true); 
		avocado.SetActive(true); 
		cucumber.SetActive(true); 
	}
}
