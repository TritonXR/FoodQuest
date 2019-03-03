using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

    // next or previous scene
    private int option;

    // gets all the scenes in the build
    private static int sceneCount = SceneManager.sceneCountInBuildSettings;

    // uses the scenceCount to create a list of each scene in order
    private string[] sceneStages = new string[sceneCount];

    // not used yet for implementing saving scene when switching scenes
    private string[] locations;
    private float[] position;

    void Start()
    {

        for (int i = 0; i < sceneCount; i++)
        {
            sceneStages[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
        /*foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("enemies"))
        {
           // for saving object locations
        }*/
    }

    void getScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentName = currentScene.name;
        int buildIndex = currentScene.buildIndex;

        if (option == 1)
        {
            Load_NextScene();
        }
        else if (option == 0)
        {
            Load_PrevScene();
        }
        else
        {
            Load_Specific(name);
        }
    }

    void Load_Specific(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void Load_NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;

        buildIndex++;

        SceneManager.LoadScene(sceneStages[buildIndex], LoadSceneMode.Single);
    }

    void Load_PrevScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;

        buildIndex--;

        SceneManager.LoadScene(sceneStages[buildIndex], LoadSceneMode.Single);
    }

}