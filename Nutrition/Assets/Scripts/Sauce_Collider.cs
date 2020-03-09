using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sauce_Collider : MonoBehaviour {

    public GameObject CookingSauce;
    public Renderer rend;
    public AudioClip correct;
    private AudioSource ears;
    public Text ingredients;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        ears = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sauce")
        {
            Destroy(other.gameObject);
            rend.enabled = true;
            ears.PlayOneShot(correct);
            ingredients.text = "Now, stir the sauce until it is cooked.";
        }
    }
}
