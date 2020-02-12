using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classDecision : MonoBehaviour {

    public GameObject warriorPortal;
    public GameObject magePortal;
    public GameObject startArrow;


    void Start()
    {
        warriorPortal.SetActive(false);
        magePortal.SetActive(false);
        startArrow.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            warriorPortal.SetActive(true);
            magePortal.SetActive(true);
            startArrow.SetActive(false);
        }
    }
}
