using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randNumber : MonoBehaviour
{
    //make the class inheritable as an instance
    public static randNumber instanceNum;

    //the goal calories of the user
    public Text calorieMax;

    public float randomInt = 0;

    // Use this for initialization
    void Start()
    {
        //this is now accesible as an instance from other scripts! 
        instanceNum = this;

        calorieMax = GetComponent<Text>();
        randomInt = Random.Range(200, 2000);
        //give the user their random number of calories goal
        calorieMax.text = "Your goal is: " + randomInt.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetGoal()
    {
        randomInt = Random.Range(200, 2000);
    }
}

