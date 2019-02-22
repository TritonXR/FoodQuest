using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumPad : MonoBehaviour {

    //[SerializeField]
    public Text BMIText;
    public Text inputFieldWeight;
    public Text inputFieldHeight;
    public Text inputFieldHeightFt;
    public Text inputFieldHeightIn;
    public Button buttonFt;
    public Button buttonIn;
    public Button buttonInputWeight;
    public Button buttonInputHeight;
    public Button buttonInputFt;
    public Button buttonInputIn;
    public Button buttonFtIn;
    public Button buttonKg;
    public Button buttonM;
    public Button buttonLbs;
    public static bool kgIsClicked = false;
    public static bool lbsIsClicked = false;
    public static bool mIsClicked = false;
    public static bool ftInIsClicked = false;

    string inputStringW;
    int valueW;
    string inputStringH;
    int valueH;
    string inputStringHFt;
    int valueHFt;
    string inputStringHIn;
    int valueHIn;

    float valueWForBMI;
    float valueHForBMI;
    float valueHFtForBMI;
    float valueHInForBMI;

    // For buttons, 'SetActive(false)' sets the UI.gameObject to invisible, 'UI.interactable = false' doesn't allow for interaction (but still visible)
    // Getting NullReferenceException when using SetActive() or .interactable in Start(), so setting the default activeness and interactability of
    // the UIs in the Inspector instead 

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
    /************** RESPONSIBLE FOR HANDELING USER INPUT********************/
    public void ButtonPressed(string buttonDigit) {
        if (buttonInputWeight.interactable == true)
        {
            if (buttonDigit == "delete")
            {
                if (inputStringW == null || inputStringW.Length == 1)
                {
                    inputStringW = "0";
                }
                else
                {
                    inputStringW = inputStringW.Substring(0, inputStringW.Length - 1);
                }
                SetText(inputFieldWeight, inputStringW);
            }
            else if (buttonDigit == "enter")
            {
                if (inputStringW == null || inputStringW == "")
                {
                    valueW = 0;
                }
                else
                {
                    valueW = int.Parse(inputStringW);
                }
                Debug.Log(valueW); // value of weight (might be in kg or lbs)
                valueWForBMI = valueW;
                outPutBMI(ftInIsClicked, mIsClicked, kgIsClicked, lbsIsClicked);
            }
            else
            {
                if (inputStringW == "0")
                {
                    inputStringW = "";
                }
                inputStringW += buttonDigit;
                SetText(inputFieldWeight, inputStringW);
            }
        }

        if (buttonInputHeight.interactable == true && buttonInputHeight.gameObject.activeSelf == true)
        {
            if (buttonDigit == "delete")
            {
                if (inputStringH == null || inputStringH.Length == 1)
                {
                    inputStringH = "0";
                }
                else
                {
                    inputStringH = inputStringH.Substring(0, inputStringH.Length - 1);
                }
                SetText(inputFieldHeight, inputStringH);
            }
            else if (buttonDigit == "enter")
            {
                if (inputStringH == null || inputStringH == "")
                {
                    valueH = 0;
                }
                else
                {
                    valueH = int.Parse(inputStringH);
                }
                Debug.Log(valueH); // value of height (in m);
                valueHForBMI = valueH;
                outPutBMI(ftInIsClicked, mIsClicked, kgIsClicked, lbsIsClicked);
            }
            else
            {
                if (inputStringH == "0")
                {
                    inputStringH = "";
                }
                inputStringH += buttonDigit;
                SetText(inputFieldHeight, inputStringH);
            }
        }

        if (buttonInputFt.interactable == true && buttonInputFt.gameObject.activeSelf == true)
        {
            if (buttonDigit == "delete")
            {
                if (inputStringHFt == null || inputStringHFt.Length == 1)
                {
                    inputStringHFt = "0";
                }
                else
                {
                    inputStringHFt = inputStringHFt.Substring(0, inputStringHFt.Length - 1);
                }
                SetText(inputFieldHeightFt, inputStringHFt);
            }
            else if (buttonDigit == "enter")
            {
                if (inputStringHFt == null || inputStringHFt == "")
                {
                    valueHFt = 0;
                }
                else
                {
                    valueHFt = int.Parse(inputStringHFt);
                }
                Debug.Log(valueHFt); // value of height (the part in ft)
                valueHFtForBMI = valueHFt;
                outPutBMI(ftInIsClicked, mIsClicked, kgIsClicked, lbsIsClicked);
            }
            else
            {
                if (inputStringHFt == "0")
                {
                    inputStringHFt = "";
                }
                inputStringHFt += buttonDigit;
                SetText(inputFieldHeightFt, inputStringHFt);
            }
        }

        if (buttonInputIn.interactable == true && buttonInputIn.gameObject.activeSelf == true)
        {
            if (buttonDigit == "delete")
            {
                if (inputStringHIn == null || inputStringHIn.Length == 1)
                {
                    inputStringHIn = "0";
                }
                else
                {
                    inputStringHIn = inputStringHIn.Substring(0, inputStringHIn.Length - 1);
                }
                SetText(inputFieldHeightIn, inputStringHIn);
            }
            else if (buttonDigit == "enter")
            {
                if (inputStringHIn == null || inputStringHIn == "")
                {
                    valueHIn = 0;
                }
                else
                {
                    valueHIn = int.Parse(inputStringHIn);
                }
                Debug.Log(valueHIn); // value of height (the part in in)
                valueHInForBMI = valueHIn;
                outPutBMI(ftInIsClicked, mIsClicked, kgIsClicked, lbsIsClicked);
            }
            else
            {
                if (inputStringHIn == "0")
                {
                    inputStringHIn = "";
                }
                inputStringHIn += buttonDigit;
                SetText(inputFieldHeightIn, inputStringHIn);
            }
        }
    } // end of ButtonPressed

    /************** FUNCTIONS HERE ARE RESPONSIBLE FOR HANDELING THE STATE OF BUTTONS********************/
    public void weightClicked()
    {
        buttonInputWeight.interactable = true;
        buttonInputHeight.interactable = false;
        buttonInputFt.interactable = false;
        buttonInputIn.interactable = false;
        buttonFtIn.interactable = false;
        buttonFt.interactable = false;
        buttonIn.interactable = false;
        buttonM.interactable = false;
        buttonKg.interactable = true;
        buttonLbs.interactable = true;
    }
    public void heightClicked()
    {
        buttonInputWeight.interactable = false;
        buttonInputHeight.interactable = true;
        buttonFtIn.interactable = true;
        buttonM.interactable = true;
        buttonKg.interactable = false;
        buttonLbs.interactable = false;
    }

    public void ftInClicked()
    {
        buttonInputFt.gameObject.SetActive(true);
        buttonInputIn.gameObject.SetActive(true);
        buttonInputFt.interactable = false;
        buttonInputIn.interactable = false;
        buttonFt.gameObject.SetActive(true);
        buttonIn.gameObject.SetActive(true);
        buttonFt.interactable = true;
        buttonIn.interactable = true;
        buttonInputHeight.gameObject.SetActive(false);

        mIsClicked = false;
        ftInIsClicked = true;
        Debug.Log("kgIsClicked: " + kgIsClicked + "; lbsIsClicked: " + lbsIsClicked + "; mIsClicked: " + mIsClicked + "; ftInIsClicked: " + ftInIsClicked);/////////////////////////////////
    }
    

    public void ftClicked()
    {
        if (buttonInputWeight.interactable == false)
        {
            buttonInputFt.interactable = true;
            buttonInputIn.interactable = false;
        }
    }

    public void InClicked()
    {
        if (buttonInputWeight.interactable == false)
        {
            buttonInputIn.interactable = true;
            buttonInputFt.interactable = false;
        }
    }

    public void mClicked()
    {
        buttonInputFt.gameObject.SetActive(false);
        buttonInputIn.gameObject.SetActive(false);
        buttonFt.gameObject.SetActive(false);
        buttonIn.gameObject.SetActive(false);
        buttonFt.interactable = false;
        buttonIn.interactable = false;
        buttonInputHeight.gameObject.SetActive(true);

        mIsClicked = true;
        ftInIsClicked = false;
        Debug.Log("kgIsClicked: " + kgIsClicked + "; lbsIsClicked: " + lbsIsClicked + "; mIsClicked: " + mIsClicked + "; ftInIsClicked: " + ftInIsClicked);///////////////////////////////
    }

    public void kgClicked()
    {
        kgIsClicked = true;
        lbsIsClicked = false;
        Debug.Log("kgIsClicked: " + kgIsClicked + "; lbsIsClicked: " + lbsIsClicked + "; mIsClicked: " + mIsClicked + "; ftInIsClicked: " + ftInIsClicked);////////////////////////////////
    }

    public  void lbsClicked()
    {
        kgIsClicked = false;
        lbsIsClicked = true;
        Debug.Log("kgIsClicked: " + kgIsClicked + "; lbsIsClicked: " + lbsIsClicked + "; mIsClicked: " + mIsClicked + "; ftInIsClicked: " + ftInIsClicked);/////////////////////////////////
    }

    public void SetText(Text textField, string input) {
        textField.text = input;
    }
     /************** FUNCTIONS ABOVE ARE RESPONSIBLE FOR HANDELING THE STATE OF BUTTONS********************/

   /************** RESPONSIBLE FOR OUTPUT OF BMI VALUE ********************/
    public void outPutBMI(bool ftInIsClicked, bool mIsClicked, bool kgIsClicked, bool lbsIsClicked) {
        float valBMI = 0f;
        if(ftInIsClicked && lbsIsClicked)
        {
            Debug.Log("ftInIsClicked && lbsIsClicked");/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Debug.Log("valueWForBMI: " + valueWForBMI + "; valueHForBMI: " + valueHForBMI + "; valueHFtForBMI: " + valueHFtForBMI + "; valueHInForBMI: " + valueHInForBMI);/////////////////
            if(valueHFtForBMI != 0 || valueHInForBMI != 0)
            {
                valBMI = valueWForBMI / ((valueHFtForBMI * 12 + valueHInForBMI) * (valueHFtForBMI * 12 + valueHInForBMI)) * 703; // English BMI conversion
            }
            SetText(BMIText, "BMI value:" + valBMI.ToString() + "  (ft/in & lbs)");
        }
        else if (mIsClicked && kgIsClicked)
        {
            Debug.Log("mIsClicked && kgIsClicked");/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Debug.Log("valueWForBMI: " + valueWForBMI + "; valueHForBMI: " + valueHForBMI + "; valueHFtForBMI: " + valueHFtForBMI + "; valueHInForBMI: " + valueHInForBMI);/////////////////
            if (valueHForBMI != 0)
            {
                valBMI = valueWForBMI / ((valueHForBMI / 100) * (valueHForBMI / 100)); // Metric BMI conversion
            }
            SetText(BMIText, "BMI value:" + valBMI.ToString() + "  (cm & kg)");
        }
        else if (ftInIsClicked && kgIsClicked)
        {
            Debug.Log("ftInIsClicked && kgIsClicked");///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Debug.Log("valueWForBMI: " + valueWForBMI + "; valueHForBMI: " + valueHForBMI + "; valueHFtForBMI: " + valueHFtForBMI + "; valueHInForBMI: " + valueHInForBMI);/////////////////

            if (valueHFtForBMI != 0 || valueHInForBMI != 0)
            {
                valBMI = valueWForBMI * 2.2046f / ((valueHFtForBMI * 12 + valueHInForBMI) * (valueHFtForBMI * 12 + valueHInForBMI)) * 703; // English BMI conversion
            }

            SetText(BMIText, "BMI value:" + valBMI.ToString() + "  (ft/in & kg)");
        }
        else if (mIsClicked && lbsIsClicked)
        {
            Debug.Log("mIsClicked && lbsIsClicked");/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Debug.Log("valueWForBMI: " + valueWForBMI + "; valueHForBMI: " + valueHForBMI + "; valueHFtForBMI: " + valueHFtForBMI + "; valueHInForBMI: " + valueHInForBMI);//////////////////
            if (valueHForBMI != 0)
            {
                valBMI = valueWForBMI * 0.4536f / ((valueHForBMI / 100) * (valueHForBMI / 100)); // Metric BMI conversion
            }
            SetText(BMIText, "BMI:" + valBMI.ToString() + "  (cm & lbs)");
        }
        else
        {
            SetText(BMIText, "Select & hit enter for both units");
        }

    }
}
