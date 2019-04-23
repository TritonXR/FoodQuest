 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Rage : MonoBehaviour
{ 
    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject warrior;
    public GameObject rage;
    public float ragemode = 4;
    public float cooldown = 10;
    private float timeStamp;
    private float rageStamp;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        warrior.SetActive(true);
        rage.SetActive(false);
    }

    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if((timeStamp <= Time.time))
        {
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                timeStamp = Time.time + cooldown;
                warrior.SetActive(false);
                rage.SetActive(true);
                rageStamp = Time.time + ragemode;
                Debug.Log("Button");
            }
        }

        if (rageStamp <= Time.time)
        {
            warrior.SetActive(true);
            rage.SetActive(false);
        }
    }
}