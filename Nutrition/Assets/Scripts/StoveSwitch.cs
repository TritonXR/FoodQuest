using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSwitch : MonoBehaviour {

	public GameObject lightt;
	public GameObject lSwitch;

	public GameObject _outPosition;
	public GameObject _inPosition;

    public static bool HeatOn;

    private bool stoveOn;
    private bool stoveOff;

	void Start()
	{
        stoveOn = true;
        stoveOff = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand") 
		{
            if (stoveOn)
            {
                lightt.SetActive(true);
                lSwitch.transform.position = new Vector3(_inPosition.transform.position.x,
                    _inPosition.transform.position.y,
                    _inPosition.transform.position.z);
                HeatOn = true;
                stoveOn = false;
                stoveOff = true;
            }

            else if (stoveOff)
            {
                lightt.SetActive(false);
                lSwitch.transform.position = new Vector3(_outPosition.transform.position.x,
                    _outPosition.transform.position.y,
                    _outPosition.transform.position.z);
                HeatOn = false;
                stoveOn = true;
                stoveOff = false;
            }
		}
	}
}
