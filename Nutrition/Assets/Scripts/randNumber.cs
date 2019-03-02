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
<<<<<<< HEAD
    {       
=======
    {
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4
        //this is now accesible as an instance from other scripts! 
        instanceNum = this;

        calorieMax = GetComponent<Text>();
        randomInt = Random.Range(200, 2000);
        //give the user their random number of calories goal
<<<<<<< HEAD
        calorieMax.text = "Your goal is: " + randomInt.ToString();       
=======
        calorieMax.text = "Your goal is: " + randomInt.ToString();
>>>>>>> b1468c2f4eff200b96847f2dcb35eaba86f56db4

    }

    // Update is called once per frame
    void Update()
    {

    }
}

