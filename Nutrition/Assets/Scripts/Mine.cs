using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mine : MonoBehaviour
{
    public int resetTimer;
    public int mineHealth;
    public bool isActive;
    private float timeStamp;
    public GameObject food;
    Rigidbody mine;
    private Vector3 originalSize;

    [SerializeField]
    private string tag;

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        originalSize = this.transform.localScale;
        mine = GetComponent<Rigidbody>();
        resetTimer = 15;
        isActive = true;
        if (mineHealth == 0)
        {
            mineHealth = 3;
        }

    }
    // The amount of damage that certain weapons will deal
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Weapon")
        {
            mineHealth = mineHealth - 1;
            Debug.Log("Mine has been hited");
        }

        if (otherObj.gameObject.tag == "Rage Sword")
        {
            mineHealth = mineHealth - 1;
            Debug.Log("Mine has been hited");
        }


        if (otherObj.gameObject.tag == "Fireball")
        {
            mineHealth = mineHealth - 1;
            Destroy(otherObj.gameObject);
            Debug.Log("Mine has been hited");
        }

        if (otherObj.gameObject.tag == "Iceball")
        {
            mineHealth = mineHealth - 1;
            Destroy(otherObj.gameObject);
            Debug.Log("Mine has been hited");
        }

        if (mineHealth <= 0)
        {
            GameObject drop;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
            this.transform.localScale = new Vector3(0, 0, 0);
            isActive = false;
            timeStamp = Time.time + resetTimer;
            Debug.Log("Mine has been destroyed");
        }
    }

    private void Update()
    {
        if(!isActive)
        {
            if(timeStamp <= Time.time)
            {
                isActive = true;
                this.transform.localScale = originalSize;
            }
        }
    }
}