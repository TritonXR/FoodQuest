using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiceCookerSteam : MonoBehaviour {

	public GameObject riceCookerSteam; 
	 float startTime = 0; 
	// Use this for initialization
	public void Start () {
		startTime = Time.time; 
		InvokeRepeating("SpawnSteam", 0, 0.1f); 
	}

	// Update is called once per frame
	public void SpawnSteam () {
		if (Time.time - startTime >= 20) {
			riceCookerSteam.SetActive(true); 
		}

	}

	public void StopSteam() {
		CancelInvoke(); 
		riceCookerSteam.SetActive(false); 
	}
}
