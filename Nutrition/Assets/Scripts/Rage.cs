using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class Rage : Roles
{ 
    private SteamVR_TrackedObject TrackedObject; //= null;
    public SteamVR_Controller.Device Device;
    public GameObject warriorSword;
    public GameObject rageSword;
    public GameObject warriorShield;
    public GameObject rageShield;
    public float ragemode = 4;
    public float cooldown = 10;
    private float timeStamp;
    private float rageStamp;
    public Slider magicbar;
    public Text magic;
    public GameObject Pause;
    private bool pause;

    // This will track the controller
    void Awake()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    //This will spawn the player with the basic warrior weapons
    void Start()
    {
        warriorSword.SetActive(true);
        rageSword.SetActive(false);
        warriorShield.SetActive(true);
        rageShield.SetActive(false);
        pause = true;
        Pause.SetActive(false);
    }

    void OnEnable()
    {
        warriorSword.SetActive(true);
        rageSword.SetActive(false);
        warriorShield.SetActive(true);
        rageShield.SetActive(false);
        pause = true;
        Pause.SetActive(false);
    }

     void OnDisable()
    {
        warriorSword.SetActive(false);
        rageSword.SetActive(false);
        warriorShield.SetActive(false);
        rageShield.SetActive(false);
        pause = true;
        Pause.SetActive(false);
    }

    //This controls the use of rage mode
    void Update()
    {
        Device = SteamVR_Controller.Input((int)TrackedObject.index);

        // This allows rage mode to be active for a couple seconds
        if((timeStamp <= Time.time))
        {
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Vector2 touchValue = Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                if (touchValue.y > 0.8f && touchValue.y < 1.0f)
                {
                    timeStamp = Time.time + cooldown;
                    warriorSword.SetActive(false);
                    rageSword.SetActive(true);
                    warriorShield.SetActive(false);
                    rageShield.SetActive(true);
                    rageStamp = Time.time + ragemode;
                    Magic.CurrentMagic -= 10;
                    magicbar.value = Magic.CalculateMagic();
                    Magic.magicRegen = true;
                    magic.text = "MP: " + Magic.CurrentMagic.ToString() + "/" + Magic.MaxMagic.ToString();
                    Debug.Log(magic.text);
                }
            }
        }


        //This adds a cooldown system to rage mode
        if (rageStamp <= Time.time)
        {
            warriorSword.SetActive(true);
            rageSword.SetActive(false);
            warriorShield.SetActive(true);
            rageShield.SetActive(false);
        }

        if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (pause)
            {
                Pause.SetActive(true);
                pause = false;
            }

            else
            {
                Pause.SetActive(false);
                pause = true;
            }
        }
    }
}