using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Zone : MonoBehaviour
{

    public static Trigger_Zone instance;
    public float count = 0;

    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"Danish", 721 },
        {"Seed Roll", 285 },
        {"Croissant", 300 },
        {"Big Bread", 350 },
    };

    void Start()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.tag;
        Debug.Log(name);
        int calorieVal = dict[name];
        Debug.Log(calorieVal);
        count = count + calorieVal;
        Debug.Log("count" + count);
    }

    private void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.tag;
        Debug.Log(name);
        int calorieVal = dict[name];
        Debug.Log(calorieVal);
        count = count - calorieVal;
        Debug.Log("count" + count);
    }

}