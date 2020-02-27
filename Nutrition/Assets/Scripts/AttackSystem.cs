using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour {

    public GameObject food;
    Rigidbody enemy;
    public static bool hitStatus = false;
    public static bool freezeStatus = false;

    public Text nameLabel;
    public Slider healthStatus;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        enemy = GetComponent<Rigidbody>();

        nameLabel.text = gameObject.tag;
        MaxHealth = 150f;
        CurrentHealth = MaxHealth;
        healthStatus.value = CalculateHealth();
    }
    // The amount of damage that certain weapons will deal
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Sword")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 50;
            healthStatus.value = CalculateHealth();
            Debug.Log("Enemy has been damaged");
        }

        if (otherObj.gameObject.tag == "Rage Sword")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 75;
            healthStatus.value = CalculateHealth();
            Debug.Log("Enemy has been damaged");
        }

        if (otherObj.gameObject.tag == "Shield")
        {
            hitStatus = true;
        }

        if (otherObj.gameObject.tag == "Rage Shield")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 25;
            healthStatus.value = CalculateHealth();
            Debug.Log("Enemy has been damaged");
        }

        if (otherObj.gameObject.tag == "Fireball")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 50;
            healthStatus.value = CalculateHealth();
            Destroy(otherObj.gameObject);
        }

        if (otherObj.gameObject.tag == "Iceball")
        {
            freezeStatus = true;
            CurrentHealth = CurrentHealth - 25;
            healthStatus.value = CalculateHealth();
            Destroy(otherObj.gameObject);
        }

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(food, transform.position, transform.rotation);
            Debug.Log("Enemy has been slayed");
        }

    }
    //Will freeze the opponent for 3 seconds if hit by iceball
    void Update()
    {

    }

    public float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
