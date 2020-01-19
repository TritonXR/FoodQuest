using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public static float CurrentHealth { get; set; }
    public static float MaxHealth { get; set; }
    public Slider healthbar;
    public Text health;
    public HP instance;
    public Text tomatoText;
  

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 25f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        health.text = "HP:" + " " + CurrentHealth.ToString() + "/" + MaxHealth.ToString();
        tomatoText.text = Item.tomato.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tomatoText.text = Item.tomato.ToString();
    }

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        health.text = "HP:" + " " + CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    public static float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
