using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

	public Transform Spawnpoint; 
	public Rigidbody Prefab;
	public float delay = 0.75f; 
	
	public void repeat() {
		InvokeRepeating("faucetOn", 0, delay); 
	}
	
	// when faucet on button is pressed
	public void faucetOn () {
		Rigidbody RigidPrefab; 
		//create water droplets
		RigidPrefab = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody; 
	
		
	}
	
	public void faucetOff () {
			CancelInvoke(); 

	}
	
	
} 
