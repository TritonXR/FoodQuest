using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonsterBehavior {
    // Update is called once per frame
    void Update () {
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

            transform.position += Vector3.back * Time.deltaTime;

            if (movementStamp <= Time.time)
            {
                hitStatus = false;
                stomp = true;
            }
        }
    }
}
