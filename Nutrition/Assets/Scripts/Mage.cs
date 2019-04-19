using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Mage : MonoBehaviour {

    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject Fireball;
    public GameObject Iceball;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject fireball = Instantiate(Fireball, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(Vector3.forward * 15);
            Destroy(fireball, 1);

        }

        if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchValue.y > -1.0f && touchValue.y < -0.8f)
            {
                GameObject fireball = Instantiate(Iceball, transform.position, transform.rotation) as GameObject;
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = transform.TransformDirection(Vector3.forward * 15);
                Destroy(fireball, 1);
            }
        }
    }
}
