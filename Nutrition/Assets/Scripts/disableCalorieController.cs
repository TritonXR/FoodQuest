using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCalorieController : MonoBehaviour {

    private disableCalorie[] calObjects;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        calObjects = Object.FindObjectsOfType<disableCalorie>();
    }
	
	// Update is called once per frame
    // TODO: Separate game object active methods for when new games come
	void Update () {
		if(Input.GetKeyDown("[1]"))
        {
            Debug.Log("Remove calorie game");
            foreach (disableCalorie test in calObjects)
            {
                test.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown("[2]"))
        {
            Debug.Log("Set Calorie game");
            foreach (disableCalorie test in calObjects)
            {
                test.gameObject.SetActive(true);
            }
        }
    }
}
