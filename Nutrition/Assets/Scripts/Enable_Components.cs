using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Enable_Components : MonoBehaviour {

    public SteamVR_TrackedObject TrackeObject = null;
    public SteamVR_Controller.Device Device;
    private BoxCollider banana;
    
    void Start()
    {
        banana = GetComponent<BoxCollider>();
    }

    void Awake()
    {
        TrackeObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update ()
    {
        Device = SteamVR_Controller.Input((int)TrackeObject.index);

        if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            banana.enabled = !banana.enabled;
        }

        if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchValue.x > 0.8f || touchValue.x < 1.0f)
            {
                banana.enabled = !banana.enabled;
            }
        }
    }
}
