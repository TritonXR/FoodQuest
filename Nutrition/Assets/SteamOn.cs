using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamOn : MonoBehaviour {

    public GameObject steam;
    public GameObject water;
    public GameObject noodles;

    private float flameStamp;
    private float flameStartup;

    private float chillStamp;
    private float chillStartup;
    
    // Use this for initialization
	void Start ()
    {
        flameStamp = 0;
        chillStamp = 0;
        flameStartup = 3;
        chillStartup = 5;
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
                Debug.Log("yaes");
                chillStamp = 0;
                if (flameStamp >= flameStartup)
                {
                    steam.SetActive(true);
                    water.tag = "Boiled Water";
                }

                flameStamp += Time.deltaTime;
            }

            else if (StoveSwitch.HeatOn != true)
            {
                flameStamp = 0;
                if (chillStamp >= chillStartup)
                {
                    if (water.tag == "Boiled Water")
                    {
                        steam.SetActive(false);
                        water.tag = "Water";
                        noodles.tag = "Boiled Noodles";
                    }

                    else
                    {
                        steam.SetActive(false);
                        water.tag = "Water";
                    }
                }
                chillStamp += Time.deltaTime;
            }
        }
    }
}
