using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {
    
    bool isGrabbed = false;
    GameObject controllerScript;
  //  SteamVR_TrackedController controller = controllerScript.GetComponent<SteamVR_TrackedController>();

    // Use this for initialization
    void Start () {
        //SteamVR_TrackedController controller = controllerScript.GetComponent<SteamVR_TrackedController>();

    }
	
	// Update is called once per frame
	void Update () {
	//	if(controller.gripped)
    //    {

    //    }
	}

    public void test()
    {
      //  if (SteamVR_TrackedCamera.triggerPressed) ;
    }
    public void attach(GameObject obj)
    {
        if (isGrabbed)
        {
          //  obj.transform.SetParent(controller);

        }
        else
        {
            obj.transform.SetParent(null);
        }
    }
}
