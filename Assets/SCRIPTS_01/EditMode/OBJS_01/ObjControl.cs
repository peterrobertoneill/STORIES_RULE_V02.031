using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;


public class ObjControl : MonoBehaviour
{
    //--------other Scripts------------
    //public MediaPath mediaPath;
    public UMP.UmpScript umpScript;
    public UMP.AudioSetUp audioSetUp;
    public StreamVideo streamVideo;
    public PreControl preControl;
    public AddRemoveControl addRemoveControl;
    public SubScripting01 subScripting01;
    public JsonScript jsonScript;
    public SettingOpen settingOpen;
    public ObjPowers objPower;

    //---------data paths--------
    public string dir;
    public string dataPath;
    public string DataPath_LS;
    private string mainDataPath;
    private string mPath;
    private string imgPathF;
    public FlowTwo flowTwo;
    public ObjTwo objTwo;
    public List<ObjTwo> ObjT;
    public Text ListCount;
    

    //---------GameObjects--------
    //[SerializeField]
    public GameObject OBJ; // the OBJECT
    public GameObject theShelf; //parent of OBJ
    public GameObject tChild;
    public GameObject objNameplate;
    public RawImage rawImage;

    Text theText;

    //---------Presetname
    public string newPresetName;
    public InputField newPresetName_Field;
    public string saveAs;
    public string presetName;
    public Text ShelfPresetName;
   // public Text ShelfPresetName02;
    public Text EndShelfPresetName;
    public int ShelfIndex;
    public GameObject NewPreButton; // preset Button OBJ
    public GameObject presetButtons; // preset Button parent OBJ
    public GameObject SHELVES;
    public Text ShelfNum;

    //---------Data output------------
    public enum objType { video, still, audio };
    public int objOrder;
    public string objName;
    public float objVol;
    //public string DataPath_LS;
    public string dataFileName; // = "Obj2.json";
    public string ShelfName; // to determin if 00_F
    private string filePath;
    public string whichButton;
    public int removeThis;
    public string preName;

    // private 

    private List<GameObject> buttons;
    public List<string> shelfPresets = new List<string>();
    private List<string> fileNames;
    public InputField fileNamesList;
    //public Text fileNamesList2;
    public Text CheckIt;
    public InputField CheckIt2_input;
    public int Load_DebugOff = 4;

    public GameObject NContent_Holder;  //  = OBJ_Streemv / PANELopen / NewMedia_ScrollreC / NewInviewer / NContent

    // ------------------------------------- Obj Controls ------------------------======= Start ====== 001
    // ---------------------------------------------------------------------------====================
    // ---------------------------------------------------------------------------====================

    private void Start() // set up new objects on start //<<<<<

    {

        buttons = new List<GameObject>();
        NewObject();
        jsonScript.SetLastSaved();
        jsonScript.ReadObjListUtility();

        DataPaths();

    }


    // ------------------------------------- Obj Controls ------------------------======= Set First name ====== 002
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================

    public void SetFirstName(List<string> shelfPresets)
    {

        ShelfPresetName.text = shelfPresets[0];    // main bar = the button selected
        EndShelfPresetName.text = shelfPresets[0];  //  "

        CheckIt2_input.text += " / preset Name - " + shelfPresets[0] + "\n";

    }

    // ------------------------------------- Obj Controls ------------------------======= New Object ====== 003
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================

    public void NewObject() // new object on + button //<<<<<<< W <<
    {

        GameObject NewObj = Instantiate(OBJ) as GameObject;  // CLONE Obj
        NewObj.SetActive(true);
        NewObj.transform.SetParent(OBJ.transform.parent, false); // position
        int ObjIndex = NewObj.transform.GetSiblingIndex(); // obj index
        string obOrder = (ObjIndex + 0).ToString();         // set order
        NewObj.GetComponent<StreamVideo>().SetFlowOrder(obOrder);  // send order to obj text
        NewObj.GetComponent<StreamVideo>().SetObjectUpdate(); // set the checkmark to true

        GameObject NFeild_parent = NContent_Holder.transform.GetChild(0).gameObject;

       // print("--- NewObject ------------ New Object made");
    }



    // ------------------------------------- Obj Controls ------------------------======= Up Date It ====== 003
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================

    public void UpDateIt() //<<<<<<<<
    {
        ShelfIndex = theShelf.transform.parent.GetSiblingIndex();   // ---Shelf index
        int counter = theShelf.transform.childCount; // count number of object on shelf
        //int x = 0;
        for (int i = 1; i < counter; i++)
        {
            tChild = theShelf.transform.GetChild(i).gameObject;
            theText = tChild.transform.GetChild(3).GetComponentInChildren<Text>();
            //print(theText.text);
            //objOrder = tChild.transform.GetSiblingIndex();
            tChild.GetComponent<StreamVideo>().SetFlowOrder((i).ToString());
            tChild.GetComponent<StreamVideo>().GoBackToImage();

        }
        
    }

    // ------------------------------------- Obj Controls ------------------------======= Data Paths ====== 003
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================


    public void DataPaths() //<<<<<<<<<<<
    {
        dir = Application.dataPath;
       // CheckIt2_input.text += "/ app level - " + dir + "\n"; //
        
        dir = Directory.GetParent(dir).FullName;
       // CheckIt2_input.text += "/ up 1 level - " + dir + "\n"; //

        dir = Directory.GetParent(dir).FullName;


        dataPath = dir + "/flowmedia/";
       // CheckIt2_input.text += " dataPath - " + dataPath + "\n"; //

        dataPath = dataPath.Replace('\\', '/');
        // CheckIt2_input.text += " dataPath cleaned - " + dataPath + "\n"; //

        mPath = dataPath;
        settingOpen.mPath = mPath;

        // mainDataPath = dir + "/flowmedia/data/";
        // mainDataPath = mainDataPath.Replace('\\', '/');
        mainDataPath = Application.streamingAssetsPath + "/data/";
        DataPath_LS = mainDataPath;
        //DataPath_LS = Application.streamingAssetsPath;
        //CheckIt2_input.text += " dataPath - " + DataPath_LS + "\n"; //

        preControl.DataPath_LS = mainDataPath;
        addRemoveControl.DataPath_LS = mainDataPath;
        umpScript.mPath = mPath;
        //audioSetUp.mPath = mPath;


        //subScripting01.DataPath_LS = mainDataPath;

        // print("-----------paths------------");
        // print("path media --- " + mPath);
        // print("path data --- " + DataPath_LS);

    }
       
}
     