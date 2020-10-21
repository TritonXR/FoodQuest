using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Roles
{
    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject harvestTool;

    // This will track the controller
    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void OnEnable()
    {
        harvestTool.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
        harvestTool.SetActive(true);
    }

    void OnDisable()
    {
        harvestTool.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
