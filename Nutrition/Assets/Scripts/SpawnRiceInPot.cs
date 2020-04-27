using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiceInPot : MonoBehaviour {

	public GameObject riceInPot1;
	public GameObject riceInPot2;
	int counter; 

	void Start() {
		counter = 0; 
	}
	void OnTriggerEnter(Collider other) {
		if (counter == 0) {
			riceInPot1.SetActive(true); 
		}
		else if (counter == 2) {
			riceInPot1.SetActive(false); 
			riceInPot2.SetActive(true); 
		}
	}
}
