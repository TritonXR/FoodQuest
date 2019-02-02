using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

 

	// Use this for initialization
	void Start ()
    {
        //    count = Trigger_Zone.instance.count;
        public float count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            float count = Trigger_Zone.instance.count;
            Debug.Log(count);
        }
    }
}
