using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

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
    public Slider magicbar;
    public Text magic;

    // This will track the controller
    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    //This will spawn the player with the basic warrior weapons
    void Start()
    {
        warrior.SetActive(true);
        rage.SetActive(false);
    }

    //This controls the use of rage mode
    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        // This allows rage mode to be active for a couple seconds
        if((timeStamp <= Time.time))
        {
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                timeStamp = Time.time + cooldown;             
                warrior.SetActive(false);
                rage.SetActive(true);
                rageStamp = Time.time + ragemode;
                Magic.CurrentMagic = Magic.CurrentMagic - 10;
                magicbar.value = Magic.CalculateMagic();
                Magic.magicRegen = true;
                magic.text = "MP:" + " " + Magic.CurrentMagic.ToString() + "/" + Magic.MaxMagic.ToString();
            }
        }

        //This adds a cooldown system to rage mode
        if (rageStamp <= Time.time)
        {
            warrior.SetActive(true);
            rage.SetActive(false);
        }
    }
}