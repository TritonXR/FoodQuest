using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4
using System;

public class ButtonTrigger : MonoBehaviour {

<<<<<<< HEAD
    public float total = 0;
    public float goal = 0;
=======
    public float goal = 0;
    public float total;
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4
    public string userText;
    public float percentOff = 0;

    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
     
	}
	
	void Update () {
		
	}
=======

    }

    void Update()
    {

    }
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4

    public float getPercent()
    {
        if (total > goal)
        {
            percentOff = 1 - (goal / total);
            return percentOff * 100;
        }
        else
        {
            percentOff = 1 - (total / goal);
            return percentOff * 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
<<<<<<< HEAD
	        //get users calculated total from button click event
=======
            //get users calculated total from button click event
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4
            total = Trigger_Zone.instance.count;
            goal = randNumber.instanceNum.randomInt;
            userText = randNumber.instanceNum.calorieMax.text;

            //update their text, show them their estimation
            //randNumber.instanceNum.calorieMax.text += "\n" + "Your calories: " + count;

            //total += 2000;
            randNumber.instanceNum.calorieMax.text += "\n" + "Your calories: " + total;

            float difference = Math.Abs(goal - total);


            //calculate the difference
            randNumber.instanceNum.calorieMax.text += "\n" + "You were off by: " + difference;
<<<<<<< HEAD

            //calculate over or underestimation %
            if (total > goal)
            {
                
                randNumber.instanceNum.calorieMax.text += "\n" + "you over estimated your calories by " + getPercent() + "%";
            }
            else if (total < goal)
            {
                randNumber.instanceNum.calorieMax.text += "\n" + "you under estimated your calories by " + getPercent() + "%";
            }
=======

            //calculate over or underestimation %
            if (total > goal)
            {

                randNumber.instanceNum.calorieMax.text += "\n" + "you over estimated your calories by " + getPercent() + "%";
            }
            else if (total < goal)
            {
                randNumber.instanceNum.calorieMax.text += "\n" + "you under estimated your calories by " + getPercent() + "%";
            }

>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4

            
            // display the components calories????

            // logic for winner or loser
            // score swith

        }
    }


        public float getPercent()
        {
            if (total > goal)
            {
                percentOff = 1 - (goal / total);
                return percentOff * 100;
            }
            else
            {
                percentOff = 1 - (total / goal);
                return percentOff * 100;
            }
        }

}