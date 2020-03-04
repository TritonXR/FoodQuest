using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {


    private GameObject[] cuttingMaterials = new GameObject[4];

    public float foodMovement = 0.02f;
    public float zoneMovement = 0.01f;
    private int i = 0;

    public GameObject cut1;
    public GameObject cut2;
    public GameObject cut3;
    public GameObject cut4;

    // Use this for initialization
    void Start ()
    {
        cuttingMaterials[0] = cut1;
        cuttingMaterials[1] = cut2;
        cuttingMaterials[2] = cut3;
        cuttingMaterials[3] = cut4;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            if(gameObject.tag == "Garlic")
            {
                cuttingMaterials[i].transform.localPosition = new Vector3(-0.0015f, transform.localScale.y + foodMovement, 0);
                transform.localPosition = new Vector3(-0.001f, transform.localScale.y + 0.0058f, 0) - new Vector3(0, zoneMovement, 0);
                foodMovement = foodMovement - 0.005f;
                zoneMovement = zoneMovement + 0.0025f;
                i++;
                gameObject.tag = "Cut Garlic";
            }

            if (gameObject.tag == "Mushroom")
            {
                cuttingMaterials[i].transform.localPosition = new Vector3(0.00262f, transform.localScale.y + foodMovement, 0);
                transform.localPosition = new Vector3(0.0019f, transform.localScale.y + 0.0058f, 0) - new Vector3(0, zoneMovement, 0);
                foodMovement = foodMovement - 0.005f;
                zoneMovement = zoneMovement + 0.0025f;
                i++;
                gameObject.tag = "Cut Mushrooms";
            }
        }
    }
}
