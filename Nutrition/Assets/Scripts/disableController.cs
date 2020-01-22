using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableController : MonoBehaviour {

    private List<disableCalorie> calObjects;
    private List<disableBMI> bmiObjects;
    private List<disableMacro> macroObjects;

    private bool calState;
    private bool bmiState;
    private bool macroState;

    public GameObject caloriePosition;
    public GameObject bmiPosition;
    public GameObject player;
    public ButtonTrigger btnSwitch;

    // Use this for initialization
    void Start () {
        calObjects = new List<disableCalorie>(Object.FindObjectsOfType<disableCalorie>());
        bmiObjects = new List<disableBMI>(Object.FindObjectsOfType<disableBMI>());
        macroObjects = new List<disableMacro>(Object.FindObjectsOfType<disableMacro>()); 

        //BMI and Macro should be disabled at the start of the scene currently
        //MAY CHANGE IN THE FUTURE
        //States are set to true to force initial check of disabling the noncurrent game's objects
        calState = true;
        bmiState = true;
        macroState = true;

        setBMIState(false);
        setMacroState(false);
        setCalState(true);
    }
	
	// Update is called once per frame
    // TODO: Separate game object active methods for when new games come
	void Update () {
		if(Input.GetKeyDown("[1]"))
        {
            Debug.Log("Switch to BMI Calculator");
            setCalState(false);
            setMacroState(false);
            setBMIState(true);
            player.transform.position = bmiPosition.transform.position;

        }
        if (Input.GetKeyDown("[2]"))
        {
            Debug.Log("Switch to Calorie Game");
            setBMIState(false);
            setMacroState(false);
            setCalState(true);
            btnSwitch.turnOnCal();
            player.transform.position = caloriePosition.transform.position;
        }
        if (Input.GetKeyDown("[3]") || GameDecider.Macro)
        {
            if(GameDecider.Macro)
            {
                GameDecider.Macro = false;
            }
            Debug.Log("Switch to Macro Molecule Game");
            setCalState(false);
            setBMIState(false);
            setMacroState(true);
            btnSwitch.turnOffCal();
            player.transform.position = caloriePosition.transform.position;
        }
    }

    private void setCalState(bool setting)
    {
        //If calorie game is off and we want to turn off, then skip
        if (!setting && !calState)
        {
            return;
        }

        foreach (disableCalorie cal in calObjects)
        {
            cal.gameObject.SetActive(setting);
        }

        calState = setting;
    }

    private void setBMIState(bool setting)
    {
        //If bmi calc is off and we want to turn off, then skip
        if(!setting && !bmiState)
        {
            return;
        }
        
        foreach (disableBMI bmi in bmiObjects)
        {
            bmi.gameObject.SetActive(setting);
        }

        bmiState = setting;

    }

    private void setMacroState(bool setting)
    {
        //If macro game is off and we want to turn off, then skip
        if (!setting && !macroState)
        {
            return;
        }

        foreach (disableMacro macro in macroObjects)
        {
            macro.gameObject.SetActive(setting);
        }
        
        macroState = setting;
    }

    public void addCalObj(disableCalorie cal)
    {
        calObjects.Add(cal);
    }

    public void addMacroObj(disableMacro macro)
    {
        macroObjects.Add(macro);
    }
}
