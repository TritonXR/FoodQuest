using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateSmoke : MonoBehaviour {

	public GameObject smoke; 
	private float cookingStartTime; 
	private float cookingEndTime; 

	public void startTime () {
		cookingStartTime = Time.time; 
		InvokeRepeating("smokeOn", 0, 0.0001f); 


	}
	
	// Update is called once per frame
	public void smokeOn () {
		cookingEndTime = Time.time; 
		if (cookingEndTime - cookingStartTime >= 5f) {
			smoke.SetActive(true); 
		}
		
	}

	public void smokeOff() {
		CancelInvoke(); 
			smoke.SetActive(false); 

	}
}
