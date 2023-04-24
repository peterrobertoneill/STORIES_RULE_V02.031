using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PresetSaveLoad : MonoBehaviour
{
    //-----**----other scripts ---------------
    public MediaPath mediaPath;
    //public PopTest popTest;
    public ShelfControl shelfControl;
    //public DefaultSet_01 defaultSet_01;

    //------------data-----------
    public string DataPath_LS;
    private PresetData presetDataList;
    private ObjDataList objDataList;


    [SerializeField]
    private S00_presets s00_presets;

    //public MainData mainData;
    public string dataFileName;       //will be programed


    //-------------------load data--------------------
    public void LoadPresetData()
    {
        print(dataFileName);

        if (dataFileName == null)
            dataFileName = "default.json";

        dataFileName = "default.json";
        mediaPath.MainDataPath();

        print(DataPath_LS + "  " + dataFileName);


        string filePath = DataPath_LS + dataFileName; //DataPath_LS = mainDataPath

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            s00_presets = JsonUtility.FromJson<S00_presets>(dataAsJson);

            shelfControl.objDataLists = s00_presets.objDataList; // the presets
            shelfControl.presetDataList = s00_presets.presetDataList; //send
            shelfControl.presetStrings = s00_presets.presetStrings;
            Debug.Log(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load game data.");
            // -------NOTE: could put a create new
        }
        print("--- LOADED  = " + dataFileName);
        //Debug.Log()


    }

    public void SaveObjData()
    {
        mediaPath.MainDataPath();  //---set path

        string dataAsJson = JsonUtility.ToJson(s00_presets);
        string filePath = DataPath_LS + dataFileName;
        File.WriteAllText(filePath, dataAsJson);

        print("--- SAVED  = " + dataAsJson);
    }


}
