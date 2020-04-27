using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRice : MonoBehaviour {

	// Use this for initialization
	public GameObject riceInContainer; 
	public GameObject riceInCup; 
	public GameObject ricePot; 
	int counter = 0; 
	public GameObject riceInPot1;
	public GameObject riceInPot2;
	void OnTriggerEnter (Collider other) {
		if (other == riceInContainer) {
			riceInCup.SetActive(true); 
			counter++; 
		}
		if (other == ricePot) {
			if (counter == 1) {
				riceInPot1.SetActive(true); 
				riceInCup.SetActive(false); 
			}
			if (counter == 2) {
				riceInPot1.SetActive(false); 
				riceInPot2.SetActive(true); 
				riceInCup.SetActive(false); 
				counter = 0; 
			}
		}
	}
}
