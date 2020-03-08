using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn: MonoBehaviour {

	public Transform Spawnpoint; 
	public GameObject Prefab;
	public float delay = 0.75f;

    private bool pressed = true;
	
	public void Repeat()
    {
		InvokeRepeating("FaucetOn", 0, delay); 
	}
	
	// when faucet on button is pressed
	public void FaucetOn ()
    {		
        //create water droplets
		GameObject RigidPrefab = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
        Destroy(RigidPrefab, 1);
	}
	
	public void FaucetOff ()
    {
		CancelInvoke(); 
	}

    void OnTriggerEnter(Collider other)
    {
        if (pressed)
        {
            if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
            {
                Repeat();
                pressed = false;
            }
        }

        else
        {
            if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
            {
                FaucetOff();
                pressed = true;
            }
        }
    }

} 
