using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class Miner : Roles {
    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject pickAxe;

    // This will track the controller
    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void OnEnable()
    {
        pickAxe.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        pickAxe.SetActive(true);
	}

    void OnDisable()
    {
        pickAxe.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
