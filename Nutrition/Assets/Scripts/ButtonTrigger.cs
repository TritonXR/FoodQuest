using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    public float count = 0;

    // Use this for initialization
    void Start ()
    {
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            count = Trigger_Zone.instance.count;
            Debug.Log(count);
        }
    }
}
