using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Spawner : MonoBehaviour {

    public SteamVR_TrackedObject mTrackeObject; //= null;
    public SteamVR_Controller.Device mDevice;
    public GameObject projectile;

    void Awake()
    {
        mTrackeObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        mDevice = SteamVR_Controller.Input((int)mTrackeObject.index);

        if (mDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject fireball = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(Vector3.forward * 20);
        }

        //if (mDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        //{
            //print("Trigger Up");
        //}
    }
}
