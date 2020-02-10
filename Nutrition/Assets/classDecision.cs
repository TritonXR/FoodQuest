using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classDecision : MonoBehaviour {

    public GameObject warriorPortal;
    public GameObject magePortal;

    void Start()
    {
        warriorPortal.SetActive(false);
        magePortal.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            warriorPortal.SetActive(true);
            magePortal.SetActive(true);
        }
    }
}
