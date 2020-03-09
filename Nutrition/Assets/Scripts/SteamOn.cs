using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteamOn : MonoBehaviour {

    public GameObject waterSteam;
    public GameObject water;

    public GameObject sauceSteam;

    public GameObject mixedSteam;

    private float flameStamp1;
    private float flameStartup1;
    private float flameStamp2;
    private float flameStartup2;
    private float flameStamp3;
    private float flameStartup3;

    private float chillStamp1;
    private float chillStartup1;
    private float chillStamp2;
    private float chillStartup2;
    private float chillStamp3;
    private float chillStartup3;

    public AudioClip correct;
    private AudioSource ears;
    public Text instructions;

    // Use this for initialization
    void Start ()
    {
        flameStamp1 = 0;
        chillStamp1 = 0;
        flameStartup1 = 3;
        chillStartup1 = 5;
        flameStamp2 = 0;
        chillStamp2 = 0;
        flameStartup2 = 3;
        chillStartup2 = 5;
        flameStamp3 = 0;
        chillStamp3 = 0;
        flameStartup3 = 3;
        chillStartup3 = 5;
        ears = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Pot")
        {
            if (StoveSwitch.HeatOn)
            {
                chillStamp1 = 0;
                if (flameStamp1 >= flameStartup1)
                {
                    waterSteam.SetActive(true);
                    water.tag = "Boiled Water";                    
                }

                flameStamp1 += Time.deltaTime;
            }

            else if (StoveSwitch.HeatOn != true)
            {
                flameStamp1 = 0;
                if (chillStamp1 >= chillStartup1)
                {
                    if (water.tag == "Boiled Water")
                    {
                        waterSteam.SetActive(false);
                        water.tag = "Water";
                    }

                    else
                    {
                        waterSteam.SetActive(false);
                        water.tag = "Water";
                    }
                }
                chillStamp1 += Time.deltaTime;
            }
        }

        if(other.gameObject.tag == "Sauce Pot")
        {
            if (StoveSwitch.HeatOn)
            {
                chillStamp2 = 0;
                if (flameStamp2 >= flameStartup2)
                {
                    sauceSteam.SetActive(true);
                }

                flameStamp2 += Time.deltaTime;
            }

            else if (StoveSwitch.HeatOn != true)
            {
                flameStamp2 = 0;
                if (chillStamp2 >= chillStartup2)
                {
                    sauceSteam.SetActive(false);
                }
                chillStamp2 += Time.deltaTime;
            }
        }

        if (other.gameObject.tag == "Pan")
        {
            if (StoveSwitch.HeatOn)
            {
                chillStamp3 = 0;
                if (flameStamp3 >= flameStartup3)
                {
                    mixedSteam.SetActive(true);
                }

                flameStamp3 += Time.deltaTime;
            }

            else if (StoveSwitch.HeatOn != true)
            {
                flameStamp3 = 0;
                if (chillStamp3 >= chillStartup3)
                {
                    mixedSteam.SetActive(false);
                }
                chillStamp3 += Time.deltaTime;
            }
        }
    }
}
