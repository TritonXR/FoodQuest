using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class regenIngredients : MonoBehaviour {


    // Use this for initialization
    void Start () {
        Debug.Log("start");
    }

    void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.tag;
        Debug.Log(name);
        Debug.Log("entered");

    }

    private void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.name;
        Debug.Log("exitted");
        Debug.Log(name);

        if (name == "item1")
        {
            Instantiate(other.gameObject, gameObject.transform.position, gameObject.transform.rotation);
            
        }
    }

}
