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
            //getting current val of random calories, their total plate estimate
            randNumber.instanceNum.calorieMax.text += "\n" + "Your calories: " + count;
            //TODO figure out how to Append ^ and the "grade"

            // display the components calories????

            // logic for winner or loser
            // score swith

        }
    }
}
