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
    public Text tomatoText;
    public Text saltText;
    public Text pepperText;
    public Text mushroomText;
    public Text garlicText;
  

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 25f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        health.text = "HP:" + " " + CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tomatoText.text = Item.food["Tomato"].ToString();
        saltText.text = Item.food["Salt"].ToString();
        pepperText.text = Item.food["Pepper"].ToString();
        mushroomText.text = Item.food["Mushroom"].ToString();
        garlicText.text = Item.food["Garlic"].ToString();
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mushbro")
        {
            DealDamage(5);
        }
    }
}
