using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightOffset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;

        gameObject.transform.position = new Vector3(x, 15f, z);
	}
}
