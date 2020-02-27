<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSwitch : MonoBehaviour {

	public GameObject lightt;
	public GameObject lSwitch;
    public GameObject fire;
	public GameObject _outPosition;
	public GameObject _inPosition;

    private bool switchOn = true;

    void Start()
    {
        lightt.SetActive(false);
        fire.SetActive(false);
    }

    void Awake()
	{
		_inPosition = GameObject.FindWithTag ("InPosition");
		_outPosition = GameObject.FindWithTag ("OutPosition");

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand") 
		{
            if (switchOn)
            {
                lightt.SetActive(true);
                fire.SetActive(true);
                lSwitch.transform.position = new Vector3(_inPosition.transform.position.x, _inPosition.transform.position.y,
                    _inPosition.transform.position.z);
                switchOn = false;
            }


            else
            {
                lightt.SetActive(false);
                fire.SetActive(false);
                lSwitch.transform.position = new Vector3(_outPosition.transform.position.x, _outPosition.transform.position.y,
                    _outPosition.transform.position.z);
                switchOn = true;
            }
		}
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSwitch : MonoBehaviour {

	public GameObject lightt;
	public GameObject lSwitch;

	public GameObject _outPosition;
	public GameObject _inPosition;

	void Awake()
	{
		_inPosition = GameObject.FindWithTag ("InPosition");
		_outPosition = GameObject.FindWithTag ("OutPosition");

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand") 
		{
			lightt.SetActive (true);
			lSwitch.transform.position = new Vector3 (_inPosition.transform.position.x,
				_inPosition.transform.position.y,
				_inPosition.transform.position.z);

		}

	}

}
>>>>>>> parent of 0bc686f... stove stuff
