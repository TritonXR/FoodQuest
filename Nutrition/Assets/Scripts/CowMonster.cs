using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMonster : MonsterBehavior {
    private float locationStamp = 0.0f;
    private float chargeStamp = 0.0f;
    private float chargeCooldown = 3.0f;
    private float locationCooldown = 3.0f;

    private bool locationBoolean = true;
    private bool chargeBoolean = false;
    private bool blocked = false;
    // Update is called once per frame
    void Update () {
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

            enemy.velocity = new Vector3(0, 0, 0);

            if (movementStamp <= Time.time)
            {
                hitStatus = false;
                stomp = true;
                locationBoolean = false;
                chargeBoolean = true;
                blocked = false;
            }
        }
    }

    public override void SwordCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Sword")
        {
            CurrentHealth = CurrentHealth - 50;
            healthStatus.value = CalculateHealth();
        }
    }

    public override void RageSwordCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Rage Sword")
        {
            CurrentHealth = CurrentHealth - 75;
            healthStatus.value = CalculateHealth();
            blocked = false;
        }
    }

    public override void ShieldCollision(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Shield")
        {
            blocked = true;
            hitStatus = true;
        }
    }
}
