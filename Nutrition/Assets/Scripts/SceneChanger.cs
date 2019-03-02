using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

    private string[] sceneStages = ["scene1", "scene2", "scene3"];
    private int sceneNUmber = 0;
    private string[] locations;
    private float[] position;

	// Use this for initialization
	void Start () {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("enemies"))
        {
           
        }
    }

    void getScene()
    {
        Scene currentScene = Scene.GetActiveScene();
        String currentName = currentScene.name;
        int buildIndex = scene.buildIndex;

        if(next)
        {
            Load_NextScene();
        }
        else if (previous)
        {
            Load_PrevScene();
        }
        else
        {
            Load_Specific(name);
        }
    }

    void Load_Specific (string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void Load_NextScene ()
    {
        Scene currentScene = Scene.GetActiveScene();
        int buildIndex = scene.buildIndex;

        buildIndex++;
        
        SceneManager.LoadScene(sceneStages[buildIndex], LoadSceneMode.Single);
    }

    void Load_PrevScene()
    {
        Scene currentScene = Scene.GetActiveScene();
        int buildIndex = scene.buildIndex;

        buildIndex--;

        SceneManager.LoadScene(sceneStages[buildIndex], LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
