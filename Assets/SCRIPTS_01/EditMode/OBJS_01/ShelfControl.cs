using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShelfControl : MonoBehaviour
{

    //---**------other scripts ---------------
    public MediaPath mediaPath;
    public PresetSaveLoad presetSaveLoad;

    //---------------objects----------------------
    public GameObject presetListButton;

    //---------------lists---------------------------
    private List<GameObject> buttons = new List<GameObject>();
    public List<ObjDataList> objDataLists = new List<ObjDataList>();
    public List<PresetData> presetDataList = new List<PresetData>();
    public List<string> presetStrings = new List<string>();

    public string newPresetName;
    public InputField newPresetName_Field;

    public string saveAs;
    public string presetName;

    private void Start()
    {
        presetSaveLoad.LoadPresetData();
    }

    public void NewPresetName()
    {
        presetName = newPresetName_Field.text;
        print(presetName);

        presetStrings = new List<string>();

        presetStrings.Add(presetName);

        //GenPresetButs();
        presetSaveLoad.SaveObjData();

        GenPresetButs();
    }

    public void GenPresetButs()
    {
               
       // presetSaveLoad.LoadPresetData(); // go get DATA

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        /*
        int counter = 0;
        print(presetDataList.Count);
        foreach (PresetData aPreset in presetDataList)
        {
            string presetL = presetDataList[counter].presetName.ToString();
            GameObject but = Instantiate(presetListButton) as GameObject;
            but.SetActive(true);
            print(presetL);

            but.GetComponent<PresetListButton>().SetText(presetL);
            but.transform.SetParent(presetListButton.transform.parent, false);

            counter++;
            buttons.Add(but.gameObject);
        }
        */

        int counter = 0;
        print(presetStrings.Count);
        foreach (string aPreset in presetStrings)
        {
            string presetL = presetStrings[counter];
            GameObject but = Instantiate(presetListButton) as GameObject;
            but.SetActive(true);
            print(presetL);

          // but.GetComponent<PresetListButton>().SetText(presetL);
            but.transform.SetParent(presetListButton.transform.parent, false);

            counter++;
            buttons.Add(but.gameObject);
        }

    }

    public void PresetSelected(string presetName)
    {
        print("the button is " + presetName);

        presetSaveLoad.dataFileName = presetName + ".json";


    }


}

