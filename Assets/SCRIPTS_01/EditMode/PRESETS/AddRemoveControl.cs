using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;


public class AddRemoveControl : MonoBehaviour
{
    public List<string> shelfPresets = new List<string>();
    public ObjControl objControl;
    public PreControl preControl;
    public string DataPath_LS;
    string filePath;
    private List<GameObject> buttons;
    public GameObject NewPreButton;

    public string whichButton = "run";
    public string presetName;
    public Text ShelfPresetName;
    //public Text ShelfPresetName02;
    public Text EndShelfPresetName;
    public InputField newPresetName_Field;
    public int removeThis;
    public string preName;
    public Text ReadOut;


    void Start()
    {
        buttons = new List<GameObject>();
    }

    public void AddRemoveList()
    {
        print("-----------Add Remove lists------------");

        objControl.DataPaths(); // dataPath

        int shelfIndex = this.transform.GetSiblingIndex();
        string shelfName = this.transform.name;

        if (shelfName == "00_F_v03") //choose preset file name
            filePath = DataPath_LS + "F_" + "shelfPresets.json";
        else
            filePath = DataPath_LS + "_0" + shelfIndex.ToString() + "_" + "shelfPresets.json";

        if (2 + 2 == 4) //notes
        {
            print("01----------->> " + DataPath_LS);
            print("02----------->> " + shelfName);
            print("03----------->> " + this.transform.parent.name);
            print("04 index----------->> " + shelfIndex);
            print("05----list------->> " + shelfPresets.Count);
            print("06----filePath------->> " + filePath);
        }
        //---------->>  json
        var setting = new JsonSerializerSettings();     // ---- make data readable (pretty)
        setting.Formatting = Formatting.Indented;
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        string newJson = File.ReadAllText(filePath);     //--- read the file
        shelfPresets = JsonConvert.DeserializeObject<List<string>>(newJson);//--- convert/DeserializeObject to list ?
        var jSon = JsonConvert.SerializeObject(shelfPresets, setting);
        //print("07---read-jSon------->> " + jSon);


        //---------------------------add remove ---------------------

        if (whichButton == "add")
        {
            presetName = newPresetName_Field.text; //new preset Name
            ShelfPresetName.text = presetName; //place preset name on shelf title
            //ShelfPresetName02.text = presetName; // dido
            EndShelfPresetName.text = presetName;
            shelfPresets.Insert(0, presetName);
        }
        if (whichButton == "remove")
            if (presetName != "Default_Preset_01")
                shelfPresets.RemoveAt(removeThis - 1);

        if (whichButton == "run")
            print("run!");

        //print("08---preName - index ------->> " + (removeThis - 1));


        // ----------- write to Json ----------- SAVE

        newJson = JsonConvert.SerializeObject(shelfPresets, setting);     // write JsonConver from shelfPresets
        File.WriteAllText(filePath, newJson);             // write to .json file
        print("07---write-jSon------->> " + filePath  + newJson);

       // ReadOut.text = shelfIndex.ToString() + " - " + shelfName;

        preControl.DisplayPresetList();
    }
    ///
    /// Need to figure out the preName var - is it Text or string
    /// - I don't think it's even used in this script
    /// 
    /// Still need to write all this back to the file
    ///


}
