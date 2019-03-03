using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class regenIngredients : MonoBehaviour {

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

        if (other.gameObject.tag == "ingredients")
        {
            Instantiate(other.gameObject, gameObject.transform.position, gameObject.transform.rotation);
            
        }
    }

}
