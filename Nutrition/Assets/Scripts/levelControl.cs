using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class levelControl : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Weapon") || other.CompareTag("Rage Sword"))
        {
            Debug.Log(" scene changer obj? collided with " + other.tag);
            EditorSceneManager.LoadScene(1);
        }
    }
}
