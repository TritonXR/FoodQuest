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

    // Use this for initialization
    void Start()
    {
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

            //calculate over or underestimation %
            if (total > goal)
            {

                randNumber.instanceNum.calorieMax.text += "\n" + "you over estimated your calories by " + getPercent() + "%";
            }
            else if (total < goal)
            {
                randNumber.instanceNum.calorieMax.text += "\n" + "you under estimated your calories by " + getPercent() + "%";
            }

            // display the components calories????

            // logic for winner or loser
            // score swith

        }
    }
}