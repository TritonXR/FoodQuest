using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonTrigger : MonoBehaviour {

    private bool calGame = true;

    private int totalFruit = 0;
    private int fullCup = 0;
    private int partFilledCup = 0;
    private int numCup = 0;
    private List<GameObject> allCups = new List<GameObject>();

    public float total = 0;
    public float goal = 0;
    public string userText;
    public float percentOff = 0;
    public Boolean reset = false;

    public float xSpacing = -0.5f;
    public float zSpacing = 0.2f;

    public GameObject cup;
    public GameObject cupSpawnLocation;
    public disableController gameController;

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
            Debug.Log(calGame);
            if(calGame)
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

            else
            {
                //First clear any cups from previous iteration
                allCups.Clear();
                GameObject temp;
                totalFruit = Trigger_Zone.instance.fruitCount;
                Debug.Log("totalFruit: " + totalFruit);
                fullCup = Mathf.FloorToInt(totalFruit/3);               //Number of full cups to spawn
                partFilledCup = totalFruit % 3;                  //Partly filled cup

                Vector3 spawn = cupSpawnLocation.transform.position;
                //third of the way filled
                if(partFilledCup == 1)
                {
                    temp = Instantiate(cup, spawn, Quaternion.Euler(0, 0, 0));
                    allCups.Add(temp);
                    //Add cups to disableMacro as well so when we switch games they will all disable
                    gameController.addMacroObj(temp.GetComponent<disableMacro>());
                    Debug.Log("spawned a cup third way filled");
                    foreach (Transform child in temp.transform)
                    {
                        //disable top and middle cylinder to simulate a third filled cup
                        if(child.name == "juice2" || child.name == "juice3")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    numCup++;
                }
                else if(partFilledCup == 2)
                {
                    temp = Instantiate(cup, spawn, Quaternion.Euler(0, 0, 0));
                    allCups.Add(temp);
                    gameController.addMacroObj(temp.GetComponent<disableMacro>());
                    foreach (Transform child in temp.transform)
                    {
                        //disable top cylinder to simulate a cup filled 2/3
                        if (child.name == "juice3")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    numCup++;
                }

                Vector3 spawnAdjust = spawn;
                for(int i=numCup; i < fullCup; i++)
                {
                    spawnAdjust += new Vector3(xSpacing, 0, 0);

                    if(spawnAdjust.x <= 13.1)
                    {
                        spawnAdjust = spawn;
                        spawnAdjust += new Vector3(0, 0, zSpacing);
                    }

                    temp = Instantiate(cup, spawnAdjust, Quaternion.Euler(0, 0, 0));
                    allCups.Add(temp);
                    gameController.addMacroObj(temp.GetComponent<disableMacro>());
                }
            }

        }
    }
    public void turnOffCal()
    {
        calGame = false;
        Debug.Log("cal game off");
    }
    public void turnOnCal()
    {
        calGame = true;
        Debug.Log("cal game on ");
    }
}