using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LoadSave : MonoBehaviour
{
    
    //-----**----other scripts ---------------
    public MediaPath mediaPath;
    public PopTest popTest;
    public PresetListControl presetListControl;
    public DefaultSet_01 defaultSet_01;

    public string DataPath_LS;
    public DefaultData defaultData;
    public ShelfData shelfDataList;
    [SerializeField]
    private S00 s00;

    public MainData mainData;
    private string dataFileName = "S00.json"; //will be programed


    //-------------------load data--------------------
    public void LoadObjData()
    {
        mediaPath.MainDataPath();

        string filePath = DataPath_LS + dataFileName; //DataPath_LS = mainDataPath

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            s00 = JsonUtility.FromJson<S00>(dataAsJson);

            defaultSet_01.presetDataList = defaultData.presetDataList;
        }
        // the presets
         // PETE - I GOT TO HERE - TRYING TO RETIEVE THE LISTS FROM THE DATA
         // I GOT THE FIRST ONE...

        //print(popTest.objDataList[2].objName);
        /*
        presetListControl.s00_presets = s00.s00_presets; //send?
        print(presetListControl.s00_presets[0].presetName);
        print("presetName = " + s00.s00_presets[1].presetName);
        }

    */
        else
        {
            Debug.LogError("Cannot load game data.");
            // -------NOTE: could put a create new
        }
            print("--- LOADED = " + dataFileName);


        }

    
}


