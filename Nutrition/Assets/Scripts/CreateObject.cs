using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

	public Transform Spawnpoint; 
	public GameObject Prefab;
	public float delay = 0.75f; 
	private float waterStartTime; 
	private float waterEndTime;
	public GameObject water; 
	public GameObject pot; 
	public void Repeat()
    {	
		waterStartTime = Time.time; 
		InvokeRepeating("FaucetOn", 0, delay); 
	}
	
	// when faucet on button is pressed
	public void FaucetOn () {
		
        //create water droplets
		GameObject RigidPrefab = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
        Destroy(RigidPrefab, 1);
		waterEndTime = Time.time; 

		/* if (waterEndTime - waterStartTime > 5f) {
			//pot = GameObject.Find("Pot"); 
			water = GameObject.FindObjectsOfTypeAll(WaterInPot);
			water.SetActive(true); 
		}*/


		
	}
	
	public void FaucetOff ()
    {
			CancelInvoke(); 
	}
	
	
} 
