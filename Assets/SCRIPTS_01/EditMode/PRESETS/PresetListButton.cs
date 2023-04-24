using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresetListButton : MonoBehaviour
{
    //[SerializeField]
   // private PresetListControl presetListControl;
    public ObjControl objControl;
    public JsonScript jsonScript;
    public Text presetText;
    private string presetSelect;

    public void SetText()
    {
        presetSelect = presetText.text;
        print("01--preset selected---------->> " + presetSelect);
        jsonScript.PresetSelected(presetSelect);
        //objControl.Invoke("UpDateIt", 2f);
       // objControl.UpDateIt();
    }




}

