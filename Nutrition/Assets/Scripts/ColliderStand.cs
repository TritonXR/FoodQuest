using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStand : MonoBehaviour
{

    public GameObject parent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, parent.transform.rotation.z * -1.0f);
    }
}
