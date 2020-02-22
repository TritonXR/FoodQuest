using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adding : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            other.transform.parent = transform;
        }
    }
}
