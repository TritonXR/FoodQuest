using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Collision : MonoBehaviour {

    public int count;

	// Use this for initialization
	void Start ()
    {
        count = 0;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collisionInfo)
    {
		if (collisionInfo.collider.tag == "Bun")
        {
            count = count + 200;         
        }
	}

  
}
