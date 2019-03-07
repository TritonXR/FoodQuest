using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Spawn : MonoBehaviour {

    public GameObject Food;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bread")
            Instantiate(Food);
    }
}
