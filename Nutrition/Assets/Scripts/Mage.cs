using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Mage : Roles {

    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject Fireball;
    public GameObject Iceball;
    public float cooldown = 4.0f;
    public float fire = 0.5f;
    private float timeStamp;
    private float fireStamp;
    
    // This will track the controller
    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }
    // This controls the use of fireball and iceball
    void Update()
    {
        //This will check it the controller recieves input 
        Device = SteamVR_Controller.Input((int)TrackedObject.index);
        
        //Creates fireball using touchpad and iceball's cooldown system
        if (fireStamp <= Time.time)
        {
            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GameObject fireball = Instantiate(Fireball, transform.position, transform.rotation) as GameObject;
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = transform.TransformDirection(Vector3.forward * 15);
                Destroy(fireball, 1);
                fireStamp = Time.time + fire;
            }

        }
        //Creates iceball using touchpad and iceball's cooldown system
        if (timeStamp <= Time.time)
        {
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GameObject fireball = Instantiate(Iceball, transform.position, transform.rotation) as GameObject;
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = transform.TransformDirection(Vector3.forward * 15);
                Destroy(fireball, 1);
                timeStamp = Time.time + cooldown;
            }
        }
    }
}
