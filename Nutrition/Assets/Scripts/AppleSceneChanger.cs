using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSceneChanger : MonoBehaviour {

    public SceneController sceneController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if(gameObject.tag == "macro")
            {
                sceneController.nextScene(true);
            }
            else
            {
                sceneController.nextScene(false);
            }
        }
    }
}
