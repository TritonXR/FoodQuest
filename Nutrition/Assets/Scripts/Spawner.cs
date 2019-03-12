using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Spawner : MonoBehaviour {

    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject projectile;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject fireball = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(Vector3.forward * 15);
            Destroy(fireball, 1);

        }      
    }
}
