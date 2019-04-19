using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour {

    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject Dagger;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject dagger = Instantiate(Dagger, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = dagger.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(Vector3.forward * 5);
            Destroy(dagger, 1);

        }
    }
}
