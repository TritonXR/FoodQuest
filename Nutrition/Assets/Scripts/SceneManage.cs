using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "warriorPortal")
        {
            SceneManager.LoadScene("Warrior");
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "magePortal")
        {
            SceneManager.LoadScene("Mage");
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "kitchenPortal")
        {
            SceneManager.LoadScene("Kitchen");
            Debug.Log("yes");
        }

        if (other.gameObject.tag == "Player" || gameObject.tag == "Sword" || gameObject.tag == "Shield" && gameObject.tag == "forestPortal")
        {
            SceneManager.LoadScene("Forest");
        }
    }

    public void ForestEscape()
    {
        SceneManager.LoadScene("Forest");
    }
}
