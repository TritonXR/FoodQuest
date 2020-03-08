using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour {

    public GameObject food;
    private Rigidbody enemy;
    private bool hitStatus = false;
    private bool freezeStatus = false;

    public Text nameLabel;
    public Slider healthStatus;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    public Transform player;
    public float speed;
    public float angularSpeed;
    public float singleStep;
    private float movementStamp;
    public float cooldown = 1.0f;
    public float freezeCooldown = 5.0f;
    public float freezeStamp = 0.0f;
    private bool stomp = true;
    private Vector3 targetDirection;

    private float locationStamp = 0.0f;
    private float chargeStamp = 0.0f;
    private float chargeCooldown = 3.0f;
    private float locationCooldown = 3.0f;

    private bool locationBoolean = true;
    private bool chargeBoolean = false;

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        nameLabel.text = gameObject.tag;
        MaxHealth = 150f;
        CurrentHealth = MaxHealth;
        healthStatus.value = CalculateHealth();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        if(gameObject.tag == "Mushbro" || gameObject.tag == "Noodle Snake")
        {
            singleStep = angularSpeed * Time.deltaTime;
            targetDirection = player.position - transform.position;

            if (!hitStatus && !freezeStatus)
            {
                if (Vector3.Distance(transform.position, player.position) > 0.5 && Vector3.Distance(transform.position, player.position) < 7.5)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), angularSpeed * Time.deltaTime);

                    //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    //transform.rotation = Quaternion.LookRotation(newDirection);
                }
            }

            else if (freezeStatus)
            {
                enemy.constraints = RigidbodyConstraints.FreezeAll;

                freezeStamp += Time.deltaTime;

                if (freezeStamp >= freezeCooldown)
                {
                    enemy.constraints = RigidbodyConstraints.None;
                    freezeStatus = false;
                    freezeStamp = 0;
                }
            }


            else
            {
                if (stomp)
                {
                    movementStamp = Time.time + cooldown;
                    stomp = false;
                }

                enemy.velocity = new Vector3(0, 0, 1);

                if (movementStamp <= Time.time)
                {
                    hitStatus = false;
                    stomp = true;
                }
            }
        }
        
        else if(gameObject.tag == "Cow Monster")
        {
            if (!hitStatus && !freezeStatus)
            {
                if (locationBoolean)
                {
                    chargeStamp = 0;

                    if (locationStamp <= locationCooldown)
                    {
                        //targetDirection = player.position - transform.position;
                        //singleStep = angularSpeed * Time.deltaTime;
                        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                        //transform.rotation = Quaternion.LookRotation(newDirection);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), angularSpeed * Time.deltaTime);
                    }

                    if (locationStamp >= 3)
                    {
                        locationBoolean = false;
                        chargeBoolean = true;
                    }

                    locationStamp += Time.deltaTime;
                }


                if (chargeBoolean)
                {
                    locationStamp = 0;

                    if (chargeStamp <= chargeCooldown)
                    {
                        enemy.AddRelativeForce(Vector3.forward * speed);
                    }

                    if (chargeStamp >= 3)
                    {
                        locationBoolean = true;
                        chargeBoolean = false;
                    }

                    chargeStamp += Time.deltaTime;
                }
            }

            else if (freezeStatus)
            {
                enemy.constraints = RigidbodyConstraints.FreezeAll;

                freezeStamp += Time.deltaTime;
                locationBoolean = false;
                chargeBoolean = false;

                if (freezeStamp >= freezeCooldown)
                {
                    enemy.constraints = RigidbodyConstraints.None;
                    freezeStatus = false;
                    freezeStamp = 0;
                    locationBoolean = true;
                    chargeBoolean = false;
                }
            }

            else
            {
                locationBoolean = false;
                chargeBoolean = false;

                if (stomp)
                {
                    movementStamp = Time.time + cooldown;
                    stomp = false;
                }

                enemy.velocity = new Vector3(0, 0, 1);

                if (movementStamp <= Time.time)
                {
                    hitStatus = false;
                    stomp = true;
                    locationBoolean = false;
                    chargeBoolean = true;
                }
            }
        }
    }

    public float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
