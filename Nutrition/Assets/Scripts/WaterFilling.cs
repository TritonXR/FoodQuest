using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFilling : MonoBehaviour {

    private int count;

    public GameObject noodles;
    
    // Use this for initialization
	void Start ()
    {
        count = 0;
        transform.localScale = new Vector3(2, 0.1f, 2);
        transform.localPosition = new Vector3(-0.7f, -0.7f, 2.2f);
        noodles.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            if(count < 3)
            {
                transform.localScale = new Vector3(2, transform.localScale.y + 0.1f, 2);
                transform.localPosition = new Vector3(-0.7f, transform.localPosition.y + 0.1f, 2.2f);
                count += 1;
            }

            else
            {
                GameObject.Find("faucet").GetComponent<WaterSpawn>().enabled = false;

            }

        }

        if (other.gameObject.tag == "Noodles" && count >= 3)
        {
            Destroy(other.gameObject);
            noodles.SetActive(true);

        }
    }
}
