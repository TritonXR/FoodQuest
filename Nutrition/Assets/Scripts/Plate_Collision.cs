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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bun")
        {
            count = count + 200;
        }

        if (collision.collider.tag == "Tomato")
        {
            count = count + 50;
        }
        print(count);
    }
}
