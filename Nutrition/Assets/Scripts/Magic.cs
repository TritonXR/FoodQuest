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
    //public Text mytext;
    public static float cooldown = 20;
    private float magicStamp;
    public static float startStamp;

    public Magic instance;

    // Start is called before the first frame update
    void Start()
    {
        MaxMagic = 25f;
        CurrentMagic = MaxMagic;
        magicbar.value = CalculateMagic();
        //mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (startStamp < Time.time)
        {
            if (Time.time > magicStamp)
            {
                magicStamp += cooldown;
                GainMagic(5);
            }
        }
        Debug.Log(startStamp);
    }

    public void LoseMagic(float magiclose)
    {
        CurrentMagic -= magiclose;
        magicbar.value = CalculateMagic();
        //mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    public void GainMagic(float magicgain)
    {
        CurrentMagic += magicgain;
        magicbar.value = CalculateMagic();
    }

    public static float CalculateMagic()
    {
        return CurrentMagic / MaxMagic;
    }
}
