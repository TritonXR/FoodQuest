using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float CurrentHealth { get; set; }
    public static float MaxHealth { get; set; }
    public Slider healthbar;
    //public Text mytext;
    public Health instance;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 25f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        //mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        //mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    public static float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
