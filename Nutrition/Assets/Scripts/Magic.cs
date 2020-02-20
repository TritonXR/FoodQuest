using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public static float CurrentMagic { get; set; }
    public static float MaxMagic { get; set; }
    public Slider magicbar;
    public Text magic;
    public static float cooldown = 3;
    private float magicStamp;
    public float startStamp;
    public static bool magicRegen;

    // Start is called before the first frame update
    void Start()
    {
        MaxMagic = 25f;
        CurrentMagic = MaxMagic;
        magicbar.value = CalculateMagic();
        startStamp = 0f;
        magic.text = "MP:" + " " + CurrentMagic.ToString() + "/" + MaxMagic.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (magicRegen)
        {
            if (startStamp >= cooldown)
            {
                if (Time.time > magicStamp)
                {
                    magicStamp += cooldown;
                    GainMagic(5);
                    startStamp = 0;
                }
            }

            else
            {
                startStamp += Time.deltaTime;
            }
        }
        if (magicbar.value == 1)
        {
            magicRegen = false;
            startStamp = 0;
        }
        //if(startStamp != 0) 
        //Debug.Log(startStamp);
    }

    public void GainMagic(float magicgain)
    {
        CurrentMagic += magicgain;
        magicbar.value = CalculateMagic();
        magic.text = "MP:" + " " + CurrentMagic.ToString() + "/" + MaxMagic.ToString();
    }

    public static float CalculateMagic()
    {
        return CurrentMagic / MaxMagic;
    }
}
