using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class MonsterBehavior : MonoBehaviour {
    public GameObject food;
    public Text nameLabel;
    public Slider healthStatus;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform player;
    public float speed;
    public float angularSpeed;
    public float singleStep;
    public float cooldown = 1.0f;
    public float freezeCooldown = 5.0f;
    public float freezeStamp = 0.0f;
    
    [HideInInspector]
    public Rigidbody enemy;
    [HideInInspector]
    public bool hitStatus = false;
    [HideInInspector]
    public bool freezeStatus = false;
    [HideInInspector]
    public bool stomp = true;
    [HideInInspector]
    public float movementStamp;
    [HideInInspector]
    public Vector3 targetDirection;
    // Use this for initialization
    public void Start () {
        enemy = GetComponent<Rigidbody>();
        nameLabel.text = gameObject.tag;
        MaxHealth = 150f;
        CurrentHealth = MaxHealth;
        healthStatus.value = CalculateHealth();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void OnCollisionEnter(Collision otherObj)
    {
        this.SwordCollision(otherObj);
        this.RageSwordCollision(otherObj);
        this.ShieldCollision(otherObj);
        this.RageShieldCollision(otherObj);
        this.FireballCollision(otherObj);
        this.IceballCollision(otherObj);

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(food, transform.position, transform.rotation);
            Debug.Log("Enemy has been slayed");
        }
    }

    public float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    public virtual void SwordCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Sword")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 50;
            healthStatus.value = CalculateHealth();
        }
    }

    public virtual void RageSwordCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Rage Sword")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 75;
            healthStatus.value = CalculateHealth();
        }
    }

    public virtual void ShieldCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Shield")
        {
            hitStatus = true;
        }
    }

    public virtual void RageShieldCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Rage Shield")
        {
            hitStatus = true;
            CurrentHealth = CurrentHealth - 25;
            healthStatus.value = CalculateHealth();
            Debug.Log("Enemy has been damaged");
        }
    }

    public virtual void FireballCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Fireball")
        {
            hitStatus = true;
        }
    }

    public virtual void IceballCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Iceball")
        {
            freezeStatus = true;
            CurrentHealth = CurrentHealth - 25;
            healthStatus.value = CalculateHealth();
            Destroy(otherObj.gameObject);
        }
    }
}
