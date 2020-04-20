using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinegarSauce : MonoBehaviour
{
    public GameObject salt;
    public GameObject sugar;
    public GameObject vinegar;
    public GameObject[] stuffInPlate = new GameObject[3];
    public GameObject mixture;

    // Use this for initialization
    void Start()
    {
        salt.SetActive(false);
        sugar.SetActive(false);
        vinegar.SetActive(false);
        mixture.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Salt")
        {
            Destroy(other.gameObject);
            salt.SetActive(true);
            stuffInPlate[0] = salt;
        }

        if (other.gameObject.tag == "Sugar")
        {
            Destroy(other.gameObject);
            stuffInPlate[1] = sugar;
        }

        if (other.gameObject.tag == "Vinegar")
        {
            Destroy(other.gameObject);
            stuffInPlate[2] = vinegar;
        }

        if (CanMake())
        {
            mixture.SetActive(true);
            vinegar.transform.parent = mixture.transform;
            salt.transform.parent = mixture.transform;
            sugar.transform.parent = mixture.transform;
        }

    }

    private bool CanMake()
    {
        for (int i = 0; i < 3; i++)
        {
            if (stuffInPlate[i] == null)
                return false;
        }

        return true;
    }
}