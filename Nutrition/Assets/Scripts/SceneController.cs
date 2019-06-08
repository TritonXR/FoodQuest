using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    private int currentSceneIndex;
    private int nextSceneIndex;

    // Use this for initialization
    void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            nextScene(false);
        }
        else if (Input.GetKeyUp(KeyCode.Backspace))
        {
            prevScene();
        }

        if (nextSceneIndex != currentSceneIndex)
        {
            Debug.Log("Scene is definitely changing");
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void nextScene(bool macro)
    {
        GameDecider.Macro = macro;

        nextSceneIndex++;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        Debug.Log("Scene should change " + nextSceneIndex);
    }

    public void prevScene()
    {
        nextSceneIndex--;
        if (nextSceneIndex < 0)
            nextSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
    }
}
