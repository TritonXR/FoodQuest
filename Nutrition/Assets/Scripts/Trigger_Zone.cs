using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Zone : MonoBehaviour
{

    public static Trigger_Zone instance;
    public float count = 0;
    public GameObject plate;
    private Color orig;

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
        orig = plate.GetComponent<Renderer>().material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.tag;
        Debug.Log(name);
        int calorieVal = dict[name];
        Debug.Log(calorieVal);
        count = count + calorieVal;
        Debug.Log("count" + count);
        StartCoroutine(changer(Color.green));
    }

    private void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.tag;
        Debug.Log(name);
        int calorieVal = dict[name];
        Debug.Log(calorieVal);
        count = count - calorieVal;
        Debug.Log("count" + count);
        StartCoroutine(changer(Color.red));
    }

    private IEnumerator changer(Color clr) {
        plate.GetComponent<Renderer>().material.SetColor("Standard", clr);
        yield return new WaitForSecondsRealtime(3);
        plate.GetComponent<Renderer>().material.SetColor("Standard", orig);
    }

}