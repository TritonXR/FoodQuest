using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointExit : MonoBehaviour {
    public GameObject target;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(target);
            this.gameObject.SetActive(false);
        }
    }
}
