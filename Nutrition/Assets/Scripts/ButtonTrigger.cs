using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonTrigger : MonoBehaviour {
    public float total = 0;
    public float goal = 0;
    public string userText;
    public float percentOff = 0;
    public Boolean reset = false;

    // Use this for initialization
    void Start()
    {
        if (goal == 0)
        {
            goal = randNumber.instanceNum.randomInt;
        }
    }

    void Update()
    {

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            randNumber.instanceNum.calorieMax.text = "";
            //Reset if plate is empty
            total = Trigger_Zone.instance.count;
            if (total == 0)
            {
                randNumber.instanceNum.resetGoal();
                goal = randNumber.instanceNum.randomInt;
                randNumber.instanceNum.calorieMax.text += "Your goal is: " + goal;
            }
            else
            {
                randNumber.instanceNum.calorieMax.text += "Your goal is: " + goal;
                userText = randNumber.instanceNum.calorieMax.text;
                //update their text, show them their estimation
                //randNumber.instanceNum.calorieMax.text += "\n" + "Your calories: " + count;

                //total += 2000;
                randNumber.instanceNum.calorieMax.text += "\n" + "Your calories: " + total;

                float difference = Math.Abs(goal - total);


                //calculate the difference
                randNumber.instanceNum.calorieMax.text += "\n" + "You were off by: " + difference;

                //calculate over or underestimation %
                if (total > goal)
                {

                    randNumber.instanceNum.calorieMax.text += "\n" + "Calories were over estimated your by " + (int)getPercent() + "%";
                }
                else if (total < goal)
                {
                    randNumber.instanceNum.calorieMax.text += "\n" + "Calories were under estimated your by " + (int)getPercent() + "%";
                }

                // display the components calories????

                // logic for winner or loser
                // score swith
            }

            

        }
    }
}