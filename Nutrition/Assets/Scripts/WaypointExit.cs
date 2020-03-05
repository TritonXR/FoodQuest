using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointExit : MonoBehaviour {
    public GameObject target;

    public GameObject Monsters;
    public GameObject Cow;
    public GameObject Portal;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(target);
            this.gameObject.SetActive(false);

            if(gameObject.tag == "Slide 4")
            {
                Destroy(target);
                this.gameObject.SetActive(false);
                Monsters.SetActive(true);
            }

            if(gameObject.tag == "Slide 5")
            {
                Destroy(target);
                this.gameObject.SetActive(false);
                Cow.SetActive(true);
            }

            if(gameObject.tag == "Slide 6")
            {
                Destroy(target);
                this.gameObject.SetActive(false);
                Portal.SetActive(true);
            }
        }

        
    }
}
