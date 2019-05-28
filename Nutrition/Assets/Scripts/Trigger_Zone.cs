using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Zone : MonoBehaviour
{

    public static Trigger_Zone instance;
    public float count = 0;
    public float duration = 0f;
    public GameObject plate;
    public int fruitCount = 0;
    private Material origMat;
    private Color origClr;
    private Color targetColor;
    private float lerp = 0f;
    private float timeLeft = 0f;
    private bool clrChangeCheck = false;

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
        duration = 5f;
        origMat = plate.GetComponent<Renderer>().material;
        origClr = origMat.color;
    }

    void Update()
    {
        //if transition complete
        if (timeLeft <= 0f)
        {
            //assign original plate color
            origMat.color = origClr;
        }
        else
        {
            // calculate interpolated color
            origMat.color = Color.Lerp(targetColor, origClr, (duration - timeLeft) * (1/timeLeft));

            // update the timer
            timeLeft -= Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orange")
        {
            fruitCount++;
        }
        else
        {
            string name = other.gameObject.tag;
            //Debug.Log(name);
            int calorieVal = dict[name];
            Debug.Log(calorieVal);
            count = count + calorieVal;
            Debug.Log("count" + count);
        }
        
        colorChange(Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Orange")
        {
            fruitCount--;
        }
        else
        {
            string name = other.gameObject.tag;
            //Debug.Log(name);
            int calorieVal = dict[name];
            Debug.Log(calorieVal);
            count = count - calorieVal;
            Debug.Log("count" + count);
        }
        
        colorChange(Color.red);
    }

    //Changes target color for plate transition
    public void colorChange(Color newClr)
    {
        targetColor = newClr;
        clrChangeCheck = true;
        timeLeft = duration * 1.25f;
    }

}