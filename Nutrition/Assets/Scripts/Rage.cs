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
    public int cooldown;
    private float timeStamp;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        cooldown = 5;
        warrior.SetActive(true);
        rage.SetActive(false);
    }

    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchValue.x > -1.0f && touchValue.x < 1.0f)
            {
                warrior.SetActive(false);
                rage.SetActive(true);
                timeStamp = Time.time + cooldown;
                Debug.Log(timeStamp);
            }
        }

        if (timeStamp <= Time.time)
        {
            warrior.SetActive(true);
            rage.SetActive(false);
        }
    }
}