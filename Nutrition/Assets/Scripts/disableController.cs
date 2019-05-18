using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableController : MonoBehaviour {

    private disableCalorie[] calObjects;
    private disableBMI[] bmiObjects;

    public GameObject caloriePosition;
    public GameObject bmiPosition;
    public GameObject player;

    // Use this for initialization
    void Start () {
        calObjects = Object.FindObjectsOfType<disableCalorie>();
        bmiObjects = Object.FindObjectsOfType<disableBMI>();
    }
	
	// Update is called once per frame
    // TODO: Separate game object active methods for when new games come
	void Update () {
		if(Input.GetKeyDown("[1]"))
        {
            Debug.Log("Switch to BMI Calculator");
            foreach (disableCalorie cal in calObjects)
            {
                cal.gameObject.SetActive(false);
            }
            foreach (disableBMI bmi in bmiObjects)
            {
                bmi.gameObject.SetActive(true);
            }
            player.transform.position = bmiPosition.transform.position;

        }
        if (Input.GetKeyDown("[2]"))
        {
            Debug.Log("Switch to Calorie Game");
            foreach (disableCalorie cal in calObjects)
            {
                cal.gameObject.SetActive(true);
            }
            foreach (disableBMI bmi in bmiObjects)
            {
                bmi.gameObject.SetActive(false);
            }
            player.transform.position = caloriePosition.transform.position;
        }
    }
}
