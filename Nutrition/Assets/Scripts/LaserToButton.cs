using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserToButton : MonoBehaviour {

	public static GameObject currentObject;
	public GameObject meatballs;

	int currentID;


	// Use this for initialization
	void Start () {

		currentObject = null;
		currentID = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit[] hits;
		hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

		for (int i = 0; i < hits.Length; i++) {

			RaycastHit hit = hits [i];

			int id = hit.collider.gameObject.GetInstanceID();

			if (currentID != id) {
			
				currentID = id;
				currentObject = hit.collider.gameObject;

				string tag = currentObject.tag;
				if(tag == "MeatBallMixButton")
					meatballs.SetActive(true);

			}
				

		}
	}
}
