using System.Collections;
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
		if (other.gameObject.tag == "Player") 
		{
			lightt.SetActive (true);
			lSwitch.transform.position = new Vector3 (_inPosition.transform.position.x,
				_inPosition.transform.position.y,
				_inPosition.transform.position.z);

		}

	}

}
