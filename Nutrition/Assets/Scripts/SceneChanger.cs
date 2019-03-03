using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

    
    private int sceneNUmber = 0;

    // gets all the scenes in the build
    private static int sceneCount = SceneManager.sceneCountInBuildSettings;

    // uses the scenceCount to create a list of each scene in order
    private string[] sceneStages = new string[sceneCount];
    private string[] locations;
    private float[] position;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < sceneCount; i++)
        {
            sceneStages[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
        /*foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("enemies"))
        {
           
        }*/
    }

    void getScene()
    {
        Scene currentScene = Scene.GetActiveScene();
        string currentName = currentScene.name;
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
        
        SceneManager.LoadScene(sceneStages[buildIndex], LoadSceneMode.Single); */
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
