using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randNumber : MonoBehaviour
{
    //make the class inheritable as an instance
    public static randNumber instanceNum;
    //text needs to be global 
    //random number needs to be global so the button trigger can compare the two numbers and append the text. 
    public Text calorieMax;
    int randomInt = 0;

    // Use this for initialization
    void Start()
    {
        instanceNum = this;
        //this is now accesible as an instance from other scripts! 
        calorieMax = GetComponent<Text>();
        randomInt = Random.Range(200, 2000);
        calorieMax.text = "Your goal is: " + randomInt.ToString();       

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
