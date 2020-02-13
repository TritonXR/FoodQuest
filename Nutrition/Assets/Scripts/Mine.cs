using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mine : MonoBehaviour
{
    private int resetTimer;
    private int mineHealth;
    private bool isActive;
    private float timeStamp;
    public GameObject food;
    Rigidbody mine;
    private Vector3 originalSize;
    public AudioClip audioClip;

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
            Component component;
            AudioSource audioSource;

            Vector3 newPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z+2);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            component = drop.GetComponent<Mine>();
            Destroy(component);
            audioSource = drop.GetComponent<AudioSource>();
            Destroy(audioSource);
            newPosition = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z+2);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            component = drop.GetComponent<Mine>();
            Destroy(component);
            audioSource = drop.GetComponent<AudioSource>();
            Destroy(audioSource);
            newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z-2);
            drop = Instantiate(food, newPosition, food.transform.rotation);
            drop.transform.localScale = new Vector3(25f, 25f, 25f);
            drop.tag = tag;
            component = drop.GetComponent<Mine>();
            Destroy(component);
            audioSource = drop.GetComponent<AudioSource>();
            Destroy(audioSource);

            AudioSource audio = this.GetComponent<AudioSource>();
            audio.PlayOneShot(audioClip);
            Debug.Log("Breaking sound played");
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
                mineHealth = 3;
                this.transform.localScale = originalSize;
            }
        }
    }
}