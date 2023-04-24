using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetListControl : MonoBehaviour
{
    //---**------other scripts ---------------
    public MediaPath mediaPath;
    public LoadSave loadSave;

    public GameObject presetListButton;
    //public GameObject presetButtons;

    private List<GameObject> buttons = new List<GameObject>();


    public int buttonNumber; // used to stop duplications

    public List<ObjDataList> objDataLists = new List<ObjDataList>();
    public List<PresetData> presetDataList = new List<PresetData>();




    public void GenPresetButs()
    {
        loadSave.LoadObjData(); // go get DATA

        


        int counter = 0;

       // if (buttonNumber < s00_presets.Count) //stops duplication
       // {
            // ----clean up----

        //if (buttons.Count != null)
        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }

        /*
        foreach (S00_presets pButton in s00_presets)
            {
            string presetL = s00_presets[counter].presetName.ToString();
            GameObject but = Instantiate(presetListButton) as GameObject;
            but.SetActive(true);
            but.GetComponent<PresetListButton>().SetText(presetL);
            but.transform.SetParent(presetListButton.transform.parent, false);
            //button.transform.SetParent(presetButtons.transform, false);
             // adding to the first list

            int i = 0;
           foreach(ObjDataList objs in objDataLists)
            {
                string obName = objDataLists[i].objName;
                print(obName);
                i++;
            }
            
            counter++;
            buttons.Add(but.gameObject);
            */
    }

    // }
    /*
    print("the count " + s00_presets.Count);
        print("shelf count " + objDataLists.Count);
        Debug.Log(objDataLists[1][0].objOrder);
        Debug.Log(objDataLists[1][0].objName);
        Debug.Log(objDataLists[1].Count);
        */

    /*
    public void ButtonClicked(string presetName)
    {
       print("the button is " + presetName);

    }*/
}
