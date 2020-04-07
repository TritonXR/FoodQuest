using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SwitchClass : MonoBehaviour {

    private SteamVR_TrackedObject TrackedObject;
    public SteamVR_Controller.Device Device;
    public int pressCount;
    public Roles class1;
    public Roles class2;
    //public Roles class3;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
        pressCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);
        if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchValue.x > 0.8f && touchValue.x < 1.0f)
            {
                
            }

            if (touchValue.x > -1.0f && touchValue.x < -0.8f)
            {
                
            }

            if (touchValue.y > 0.8f && touchValue.y < 1.0f)
            {
                
            }

            if (touchValue.y > -1.0f && touchValue.y < -0.8f)
            {
                pressCount++;
                switch (pressCount % 3)
                {
                    case 0:
                        class1.enabled = true;
                        class2.enabled = false;
                        //class3.enabled = false;
                        break;
                    case 1:
                        class1.enabled = false;
                        class2.enabled = true;
                        //class3.enabled = false;
                        break;
                    case 2:
                        class1.enabled = false;
                        class2.enabled = false;
                        //class3.enabled = true;
                        break;
                }
            }
        }
    }
    
}
