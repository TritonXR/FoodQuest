using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class classDecision : MonoBehaviour {

    public GameObject warriorPortal;
    public GameObject magePortal;
    public GameObject startArrow;
    public Text classText;

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
            magePortal.SetActive(false);
            startArrow.SetActive(false);
            classText.text = "Now choose a class";
        }
    }
}
