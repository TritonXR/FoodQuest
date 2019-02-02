using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randNumber : MonoBehaviour
{

    public Text calorieMax;
    int randomInt = 0;

    // Use this for initialization
    void Start()
    {

        calorieMax = GetComponent<Text>();
        randomInt = Random.Range(100, 2400);
        calorieMax.text = randomInt.ToString();
        // calorieMax.text = "" + randomInt;

    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetKey(KeyCode.Space))
         {
             randomInt = Random.Range(0, 2000);
             calorieMax.text = randomInt.ToString();
             }
        */
        // calorieMax.text = "" + randomInt;
    }
}
