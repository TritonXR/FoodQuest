using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour {

    private Vector3 moveDirection;
    public int iceballCooldown;
    public GameObject food;
    Rigidbody enemy;
    private float timeStamp;
    public static bool hitStatus = false;
    public float speed = 100;

    public Text nameLabel;
    public Slider healthStatus;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        enemy = GetComponent<Rigidbody>();

        iceballCooldown = 3;
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
            CurrentHealth = CurrentHealth - 25;
            healthStatus.value = CalculateHealth();
            Destroy(otherObj.gameObject);
            enemy.constraints = RigidbodyConstraints.FreezeAll;
            timeStamp = Time.time + iceballCooldown;
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
        if (timeStamp <= Time.time)
        {
            //enemy.constraints = RigidbodyConstraints.None;
        }
    }

    public float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
