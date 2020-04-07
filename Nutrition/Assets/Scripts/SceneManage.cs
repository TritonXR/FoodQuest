using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "warriorPortal")
        {
            SceneManager.LoadScene(3);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "magePortal")
        {
            SceneManager.LoadScene(2);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "kitchenPortal")
        {
            SceneManager.LoadScene(5);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "forestPortal")
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ForestEscape()
    {
        SceneManager.LoadScene(0);
    }
}
