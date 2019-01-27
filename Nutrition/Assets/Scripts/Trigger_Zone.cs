using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Zone : MonoBehaviour {

    public int count;

    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"Bun", 20 },
        {"Tomato", 50 },
        {"Lettuce", 15 },
        {"Meat", 300 },
        {"Cheese", 150 },
        {"Apple", 75 }
    };

    void Start()
    {
        count = 0;
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
