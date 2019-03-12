using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Enable_Components : MonoBehaviour {

    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    private Spawner spawner;
    public GameObject Warrior;
    public GameObject Thief;
    public GameObject Archer;

    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        spawner = GetComponent<Spawner>();
        spawner.enabled = false;
        Warrior.SetActive(false);
        Thief.SetActive(false);
        Archer.SetActive(false);
    }

    void Update ()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            if (touchValue.x > 0.8f && touchValue.x < 1.0f)
            {
                Warrior.SetActive(true);
                Thief.SetActive(false);
                Archer.SetActive(false);
                spawner.enabled = false;
            }

            if (touchValue.x > -1.0f && touchValue.x < -0.8f)
            {
                Warrior.SetActive(false);
                Thief.SetActive(true);
                Archer.SetActive(false);
                spawner.enabled = false;
            }

            if (touchValue.y > 0.8f && touchValue.y < 1.0f)
            {
                Warrior.SetActive(false);
                Thief.SetActive(false);
                Archer.SetActive(true);
                spawner.enabled = false;
            }

            if (touchValue.y > -1.0f && touchValue.y < -0.8f)
            {
                Warrior.SetActive(false);
                Thief.SetActive(false);
                Archer.SetActive(false);
                spawner.enabled = true;
            }
        }
    }
}
