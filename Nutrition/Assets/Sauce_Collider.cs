using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce_Collider : MonoBehaviour {

    public GameObject CookingSauce;
    public Renderer rend;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sauce")
        {
            Destroy(other.gameObject);
            rend.enabled = true;
        }
    }
}
