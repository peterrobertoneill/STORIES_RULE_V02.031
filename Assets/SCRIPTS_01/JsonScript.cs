using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;


public class JsonScript : MonoBehaviour
{
    //-- >other classes
    public ObjPowers objPowers;
    public ObjControl objControl;
    public PreControl preControl;

    //public Text CheckIt;
    public InputField CheckIt2_input;
    public InputField MakePresetName;
    public Presets presets;
    public Text ShelfPresetName;
    public GameObject NewPreButton;
    public GameObject OBJ;
    public GameObject theShelf;

    private List<GameObject> buttons = new List<GameObject>();

    public int H_DebugOff = 4;
    public int B_DebugOff = 4;
    public int S_DebugOff = 4;
    public int Load_DebugOff = 4;
    public int subLeafDebugOff = 4;

    public string whichButton = "run";
    public string presetName;

    public Text EndShelfPresetName;
    public InputField newPresetName_Field;
    public int removeThis;
    public string preName;
    public Text ShelfNumber;
    public GameObject LoadingShelves;
    public GameObject theDot1;
    public GameObject theDot2;

   

    //--testing variables
    public GameObject shelf_DropZone;

    public List<string> shelfPresets = new List<string>(); // old?

    //===================================  XXX  =====================================================VVV - old?
    public void WriteToJson_01(string filePath, string shelfName, int shelfIndex, string DataPath_LS)
    {

        if (File.Exists(filePath))  // ---->>>>  Read presets  <<<<----
        {

            string newJson = File.ReadAllText(filePath);     //--- read the file
            shelfPresets = JsonConvert.DeserializeObject<List<string>>(newJson);  //--- convert/DeserializeObject to list ?
            var jSon = JsonConvert.SerializeObject(shelfPresets);

            print("07---read-jSon------->> " + filePath + jSon);

        }
        else                       // ---->>>> OR CREATE presets  <<<<----
        {
            shelfPresets = new List<string>();
            if (shelfName == "00_F_v03") //choose preset file name
            {
                filePath = DataPath_LS + "F_" + "shelfPresets.json";
            }

            else
            {
                filePath = DataPath_LS + "_0" + shelfIndex.ToString() + "_" + "shelfPresets.json";
            }

            shelfPresets.Add("Default_Preset_01");
            string newJson = JsonConvert.SerializeObject(shelfPresets);     // write JsonConver from shelfPresets
            File.WriteAllText(filePath, newJson);             // write to .json file
            print("07---write-jSon------->> " + filePath + newJson);
            objControl.NewObject();

            //CheckIt.text += " / newJson - " + newJson + "\n";
            //CheckIt2_input.text += " / newJson - " + newJson + "\n";
        }

        objControl.SetFirstName(shelfPresets);
        preControl.shelfPresets = shelfPresets;

    }
    //===================================  XXX  ====================================================AAA





    //==========================================================================================================
    //                                       jsonUtility - settups
    //==========================================================================================================

    /// ----------------------------------------
    /// -----------------------------------------
    /// ------------------------------------------
    /// -------------------------------------------
    /// --------------------------------------------
    /// ---------------------------------------------
    /// ----------------------------------------------
    /// -----------------------------------------------
    /// ------------------------------------------------
    /// -------------------------------------------------
    /// --------------------------------------------------
    /// ---------------------------------------------------
    /// ----------------------------------------------------
    /// -----------------------------------------------------
    /// ------------------------------------------------------ Load Presets Utility
    /// -----------------------------------------------------
    /// ----------------------------------------------------
    /// ---------------------------------------------------
    /// --------------------------------------------------
    /// -------------------------------------------------
    /// ------------------------------------------------
    /// -----------------------------------------------
    /// ----------------------------------------------
    /// ---------------------------------------------
    /// --------------------------------------------
    /// -------------------------------------------
    /// ------------------------------------------
    /// -----------------------------------------
    /// ----------------------------------------
    //=======================================    Load Presets Utility()    =======================================



    public void LoadPresetsUtility() //=========================== 001
    {
        //buttons = new List<GameObject>();

        print("<------------------   >> new LoadPresets  LoadPresetsUtility ---------------        ");

        string filePath = "";
        int shelfIndex = this.transform.GetSiblingIndex();
        string shelfName = this.transform.name;

        if (shelfName == "00_F_v03")                                                //---if F then F_shelfPresets.json
            filePath = Application.streamingAssetsPath + "/F_shelfPresets.json";
        else                                                                        //---else _0x_shelfPresets.json
            filePath = Application.streamingAssetsPath + "/_0" + shelfIndex.ToString() + "_shelfPresets.json";

        if (2 + 2 == Load_DebugOff) //notes
        {
            ///print("01----------->> " + DataPath_LS);
            print("02----------->> " + shelfName);
            ///print("03----------->> " + this.transform.parent.name);
            print("04-index---------->> " + shelfIndex);
            print("05----list------->> " + shelfPresets.Count);
            print("06----filePath------->> " + filePath);
        }

        Presets presets = new Presets();
        presets.shelfPresets = new List<string>();

        if (File.Exists(filePath))
        {
            string jsonPresets = File.ReadAllText(filePath);
            presets = JsonUtility.FromJson<Presets>(jsonPresets);

            //print("07---read-jsonPresets------->> " + filePath + "\n" + jsonPresets);
        }
        else
        {
            presets.shelfPresets.Add("default");
            string jsonPresets = JsonUtility.ToJson(presets, true);
            File.WriteAllText(filePath, jsonPresets);

            //print("08---write-jsonPresets------->> " + filePath + "\n" + jsonPresets);
        }


        //===================== Display Preset List ==================== 002

        if (buttons.Count > 0)  //clean up
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear(); // this might have to change to another name "buttons2"
        }


        //print("05----list------->> " + presets.shelfPresets.Count);

        for (int i = 0; i < presets.shelfPresets.Count; i++)  // i set it to 1
        {
            GameObject NewPre = Instantiate(NewPreButton) as GameObject;
            NewPre.SetActive(true);
            NewPre.transform.SetParent(NewPreButton.transform.parent, false);
            NewPre.GetComponentInChildren<Text>().text = presets.shelfPresets[i];

            buttons.Add(NewPre.gameObject);

           // print("06----firstName------->> " + presets.shelfPresets[i]);

        }

    }   // -------------------------------------   LoadPresetsUtility   -------------------<<





    /// ----------------------------------------
    /// -----------------------------------------
    /// ------------------------------------------
    /// -------------------------------------------
    /// --------------------------------------------
    /// ---------------------------------------------
    /// ----------------------------------------------
    /// -----------------------------------------------
    /// ------------------------------------------------
    /// -------------------------------------------------
    /// --------------------------------------------------
    /// ---------------------------------------------------
    /// ----------------------------------------------------
    /// -----------------------------------------------------
    /// ------------------------------------------------------ Add Remove List
    /// -----------------------------------------------------
    /// ----------------------------------------------------
    /// ---------------------------------------------------
    /// --------------------------------------------------
    /// -------------------------------------------------
    /// ------------------------------------------------
    /// -----------------------------------------------
    /// ----------------------------------------------
    /// ---------------------------------------------
    /// --------------------------------------------
    /// -------------------------------------------
    /// ------------------------------------------
    /// -----------------------------------------
    /// ----------------------------------------
    // ------------------------------------- JSON SCRIPT -------------------------====== Add Remove List ======
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================

    public void AddRemoveList() //===================================== 001
    {
        //buttons = new List<GameObject>();

        print("<------------------   >> Add Remove list");

        string filePath = "";
        int shelfIndex = this.transform.GetSiblingIndex();
        string shelfName = this.transform.name;

        if (shelfName == "00_F_v03")                                                //---if F then F_shelfPresets.json
            filePath = Application.streamingAssetsPath + "/F_shelfPresets.json";
        else                                                                        //---else _0x_shelfPresets.json
            filePath = Application.streamingAssetsPath + "/_0" + shelfIndex.ToString() + "_shelfPresets.json";

        if (2 + 2 == Load_DebugOff) //notes
        {
            ///print("01----------->> " + DataPath_LS);
            print("02----------->> " + shelfName);
            ///print("03----------->> " + this.transform.parent.name);
            print("04-index---------->> " + shelfIndex);
            print("05----list------->> " + shelfPresets.Count);
            print("06----filePath------->> " + filePath);
        }

        Presets presets = new Presets();

        presets.shelfPresets = new List<string>();
        string jsonPresets = File.ReadAllText(filePath);
        presets = JsonUtility.FromJson<Presets>(jsonPresets);

        //print("07---read-jsonPresets------->> " + filePath + "\n" + jsonPresets);

        //---------------------------add remove ---------------------==== 002

        //print("08---- which button ------->> " + whichButton);
        

        if (whichButton == "add")
        {
            presetName = newPresetName_Field.text; //new preset Name
            ShelfPresetName.text = presetName; //place preset name on shelf title
            EndShelfPresetName.text = presetName;
            presets.shelfPresets.Insert(0, presetName);         //list

            //print("09---- new preset ------->> " + presetName);
        }


        if (whichButton == "remove")
            if (presetName != "default")
                presets.shelfPresets.RemoveAt(removeThis - 1);  //list


        jsonPresets = JsonUtility.ToJson(presets, true);  // write to presets
        File.WriteAllText(filePath, jsonPresets);
        //print("10--- write Presets ------->> " + filePath + "\n" + jsonPresets);



        LoadPresetsUtility();  // reload presets list


    }  // ------------------   AddREmoveList









    // ------------------------------------- JSON SCRIPT -------------------------====== Preset Selected ======
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================

    public InputField CheckSubJs;

    public void PresetSelected(string presetSelect) // preset is selected
    {
        ShelfPresetName.text = presetSelect;    // main bar = the button selected
        EndShelfPresetName.text = presetSelect;  //  "
       // print("02--preset selected---------->> " + presetSelect);
        ReadObjListUtility();

    }  // ------------------   PresetSelected








    //======================================================================================================
    //=======================================    Read Obj List Utility()    ===================================
    //======================================================================================================

    //---------------------
    // NN    NN
    // NNNN  NN
    // NN NN NN
    // NN  NNNN
    // NN   NNN     // NOTE: ADD IN LAST SAVED TO SHELF $$
    //----------------------------------------------------
    // Read in LastFlowSaved
    // Read in LastSaved



    /// ----------------------------------------
    /// -----------------------------------------
    /// ------------------------------------------
    /// -------------------------------------------
    /// --------------------------------------------
    /// ---------------------------------------------
    /// ----------------------------------------------
    /// -----------------------------------------------
    /// ------------------------------------------------
    /// -------------------------------------------------
    /// --------------------------------------------------
    /// ---------------------------------------------------
    /// ----------------------------------------------------
    /// -----------------------------------------------------
    /// ------------------------------------------------------ Set Last Saved
    /// -----------------------------------------------------
    /// ----------------------------------------------------
    /// ---------------------------------------------------
    /// --------------------------------------------------
    /// -------------------------------------------------
    /// ------------------------------------------------
    /// -----------------------------------------------
    /// ----------------------------------------------
    /// ---------------------------------------------
    /// --------------------------------------------
    /// -------------------------------------------
    /// ------------------------------------------
    /// -----------------------------------------
    /// ----------------------------------------
    
    // ------------------------------------- JSON SCRIPT -------------------------====== Set Last Saved =======
    // ---------------------------------------------------------------------------=============================
    // ---------------------------------------------------------------------------=============================



    public void SetLastSaved()
    {
        
        /// to do
        /// --TO DO --
        /// Set != Null if no files
        /// set count on shelves if less than that in Last Savedt
        ///


        LastSaved lastSaved = new LastSaved();   // I just had an 'yes' moment!  -- declaration!
        lastSaved.lastPreset = new List<string>();

        LastFlowSaved lastFlowSaved = new LastFlowSaved();
        lastFlowSaved.lastFlowPreset = new List<string>();

        string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
        if (File.Exists(filePath))
        {
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);
        }
        

        filePath = Application.streamingAssetsPath + "/LastSaved.json";
        if (File.Exists(filePath))
        {
            string ShelfJson = File.ReadAllText(filePath);
            lastSaved = JsonUtility.FromJson<LastSaved>(ShelfJson);
        }
         


       // print("00--lastSaved json read---------->> " + Application.streamingAssetsPath + "/LastSaved.json" + "\n" + ShelfJson);

        if (shelf_DropZone.transform.parent.gameObject.name == "00_F_v03")
        {
            shelf_DropZone.transform.parent.parent.GetChild(4).gameObject.transform.GetChild(8).GetComponentInChildren<Text>().text = lastFlowSaved.lastFlowPreset[0];
        }
        else
        {
           // print("number of shelves-------------> " + shelf_DropZone.transform.parent.parent.childCount);
            int shelfCount = shelf_DropZone.transform.parent.parent.childCount;
            int lastSavedCount = lastSaved.lastPreset.Count;

            //for (int i = 0; i < lastSaved.lastPreset.Count; i++)
            for (int i = 0; i < lastSavedCount; i++)
            {
               // print("00 -----------------lastSaved -->" + lastSaved.lastPreset[i]);

                shelf_DropZone.transform.parent.parent.GetChild(i+1).gameObject.transform.GetChild(5).GetComponentInChildren<Text>().text = lastSaved.lastPreset[i];

                //ShelfPresetName.text = lastSaved.lastPreset[i];


            }

        }

       
    }



    // ------------=============-----   ReadObjListUtility---=====================------ 


    /// ----------------------------------------
    /// -----------------------------------------
    /// ------------------------------------------
    /// -------------------------------------------
    /// --------------------------------------------
    /// ---------------------------------------------
    /// ----------------------------------------------
    /// -----------------------------------------------
    /// ------------------------------------------------
    /// -------------------------------------------------
    /// --------------------------------------------------
    /// ---------------------------------------------------
    /// ----------------------------------------------------
    /// -----------------------------------------------------
    /// ------------------------------------------------------ Read Obj List Utility
    /// -----------------------------------------------------
    /// ----------------------------------------------------
    /// ---------------------------------------------------
    /// --------------------------------------------------
    /// -------------------------------------------------
    /// ------------------------------------------------
    /// -----------------------------------------------
    /// ----------------------------------------------
    /// ---------------------------------------------
    /// --------------------------------------------
    /// -------------------------------------------
    /// ------------------------------------------
    /// -----------------------------------------
    /// ----------------------------------------
    /// ---------------------------------------
    // ------------------------------------- JSON SCRIPT -------------------------====== Read Obj List Utility ====== 001
    // ---------------------------------------------------------------------------===================================
    // ---------------------------------------------------------------------------===================================

    public void ReadObjListUtility() 
    {

        ///
        /// ReadObjListUtility only sets up the objects  << THIS
        /// It is then set to TriggerSave  -  whitch triggers sV - NewNamedObj / oP = trigerSuberPowers / JsObjListWrite(again)
        /// oP - VideoButtonImage / and tDot - POpen
        /// 
        ///


        LoadingShelves.SetActive(true);
        LoadingShelves.GetComponent<Text>().text = "Loading shelves...";

        // Read in LastFlowSaved
        // Read in LastSaved

       // print("<------------------     >> new ReadObjListUtility  <<       ------------------");

        string filePath = ""; // allread declared

        int ShelfIndex = this.transform.GetSiblingIndex();   //--- get the shelfindex
        ShelfNumber.text = ShelfIndex.ToString();
        string ShelfName = this.transform.name;
          //  "

        if (ShelfName == "00_F_v03") // what shelf is it? - choose name to read.
        {
            filePath = Application.streamingAssetsPath + "/F_" + ShelfPresetName.text + ".json"; //--- set filePath
        }
        else
        {
            filePath = Application.streamingAssetsPath + "/" + ShelfIndex.ToString() + "_" + ShelfPresetName.text + ".json"; //--- set filePath
        }

        HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
        homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
        Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
        branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

        if (File.Exists(filePath))
        {
            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            print("04--json read---------->> " + filePath + "\n" + jSonObjs);

        }
        else  // writing default
        {
            branch.ObjName = "default";                 // setting the default
            branch.objOrder = 0;

            homeTree.branch.Add(branch);

            branch.subLeaf.Add(new SubLeaf              // setting the default
            {
                RunOrder = 0,
                JName = "default",
                JOrder = 0,

                v_ON = false,
                v_CLOSE = false,
                v_HOLD = false,
                v_LOOP = false,
                v_VOL = 5.0f,
                v_IMAGEFILE = "default",
                v_IMAGEFILE_END = "default",
                v_FADE_IN = 2.0f,
                v_FADE_OUT = 2.0f,

                i_ON = false,
                i_HOLD = false,
                i_IMAGEFILE = "default",
                i_HOLD_TIME = 3f,

                a_ON = false,
                a_OVER = false,
                a_AFTER = false,
                a_FADE_IN = 2.0f,
                a_FADE_OUT = 2.0f,
                a_AUDIOFILE = "default.mp3",
                a_VOL = 8.0f,
                a_CUES = 1,
                a_SECONDS = 3.25f

            });

                                                                // writing the default
            string jSonObjs = JsonUtility.ToJson(homeTree, true);
            File.WriteAllText(filePath, jSonObjs);

            print("04--json written---------->> " + filePath + "\n" + jSonObjs);

        }// writing default

        EndShelfPresetName.text = ShelfPresetName.text;

        int oldObjs = theShelf.transform.childCount;

        for (int i = 1; i <oldObjs; i++)  //cleanup
        {
            Destroy(theShelf.transform.GetChild(i).gameObject);
        }

        //------------------------------------------------------- Branch LOOP STARTS ----------------  002

        int count = 0;
        int branchCount = homeTree.branch.Count;

        for (count = 0; count < branchCount; count++)
        {

            GameObject NewObj = Instantiate(OBJ) as GameObject; //---------- Display Objects  -------
            NewObj.SetActive(true);
            NewObj.transform.SetParent(OBJ.transform.parent, false);
            //print(NewObj.transform.parent);

            string obOrder = homeTree.branch[count].objOrder.ToString();
            string obName = homeTree.branch[count].ObjName;

            NewObj.GetComponent<StreamVideo>().SetFlowOrder(obOrder);
            //NewObj.GetComponent<StreamVideo>().SavedNamedObj(obName);

            if (2 + 2 == B_DebugOff)
            {
                print("<------------------------   POPULATE SHELF   ------------------------>");

                print("B------------------------------------= B  ReadObjListUtility  <=---------------------------------------------B");
                print("------------------------------------=====---------------------------------------------");
                //print("--------------------B-" + i + " -00 -- Sub Count Is---> " + NewNameInputCount);
                print("--------------------B-" + count + " -01 -- Index is ---> " + obOrder);
                print("--------------------B-" + count + " -02 -- Name is ---> " + obName);

            }

            //------------------------  Getting to the SUB --- < I don't think I'm using this

            GameObject obj = shelf_DropZone.transform.GetChild(count).gameObject;               //    object
            GameObject PANELOpen = obj.transform.GetChild(1).gameObject;                    //    PANELOpen
            GameObject NewMedia_SCROLLreC = PANELOpen.transform.GetChild(7).gameObject;    //    NewMedia_SCROLLreC
            GameObject NewInviewer = NewMedia_SCROLLreC.transform.GetChild(1).gameObject;   //    NewInviewer
            GameObject NContent = NewInviewer.transform.GetChild(0).gameObject;             //    NContent 


            //------------------------------------------------------- SUB LOOP STARTS ----------------  003

            int subcount = homeTree.branch[count].subLeaf.Count;

            //Destroy(NewObj);  // clearing out memeory - maybe?

        }//------------------------------------------------------- Branch LOOP end ----------------
    
        Invoke("triggerSAVE", 0.2f);
        LoadingShelves.GetComponent<Text>().text = "Loading images...";

    } // ++++++++++++++++++++++++++++++++++  ReadObjListUtility END <<----------



    // ------------------------------------- JSON SCRIPT -------------------------======== trigger SAVE ====== 002
    // ---------------------------------------------------------------------------============================
    // ---------------------------------------------------------------------------====== onClick Invoke ======

    public void triggerSAVE() //trigger save off all objects on a shelf------------000
    {
        int objCount = shelf_DropZone.transform.childCount;
       // print("01--objCount=====================================%---------->> " + objCount);
        for (int y = 1; y < objCount; y++)
        {
            GameObject objw = shelf_DropZone.transform.GetChild(y).gameObject;
            GameObject PaneilOpen = objw.transform.GetChild(1).gameObject;
            GameObject save_MS_Btn = PaneilOpen.transform.GetChild(5).gameObject;
            Button save = save_MS_Btn.GetComponent<Button>();
            save.onClick.Invoke();
            //objPowers.VideoButtonImage();
        }

        LoadingShelves.SetActive(false);  //what is this?

        theDot1.SetActive(false);
        theDot2.SetActive(false);

    }//-------------------------------trigger save off all objects on a shelf------------000




    /// ----------------------------------------
    /// -----------------------------------------
    /// ------------------------------------------
    /// -------------------------------------------
    /// --------------------------------------------
    /// ---------------------------------------------
    /// ----------------------------------------------
    /// -----------------------------------------------
    /// ------------------------------------------------
    /// -------------------------------------------------
    /// --------------------------------------------------
    /// ---------------------------------------------------
    /// ----------------------------------------------------
    /// -----------------------------------------------------
    /// ------------------------------------------------------ Js Obj List Write
    /// -----------------------------------------------------
    /// ----------------------------------------------------
    /// ---------------------------------------------------
    /// --------------------------------------------------
    /// -------------------------------------------------
    /// ------------------------------------------------
    /// -----------------------------------------------
    /// ----------------------------------------------
    /// ---------------------------------------------
    /// --------------------------------------------
    /// -------------------------------------------
    /// ------------------------------------------
    /// -----------------------------------------
    /// ----------------------------------------
    /// ---------------------------------------
    /// ------------------------------------- JSON SCRIPT -------------------------======== Js Obj List Write ====== 003
    /// ---------------------------------------------------------------------------=================================
    /// ---------------------------------------------------------------------------====== write obj to json ========

    public GameObject NewNameContent;
    public GameObject NewNameContentTest;
    public SubScripting01 subScripting01;

    public void JsObjListWrite()            //Write objects from objects to Json <<-------------------      >> 001 <<
    {

        HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
        homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

        //-------------------------------------- HomeTree --------------------------------------H
        //-----------------------------------------=====----------------------------------------
        //-----------------------------------------=====----------------------------------------
        string shelfName = this.transform.name;                             // b shelf Name
        
        int objCount = shelf_DropZone.transform.childCount;                 // b obj count

        int shelfIndex = shelf_DropZone.transform.GetSiblingIndex();          // b shelf index

        if (2 + 2 == H_DebugOff)
        {
            print("H------------------------------------= H =---------------------------------------------H");
            print("------------------------------------=====---------------------------------------------");
            print("------------------------------------=====---------------------------------------------");
            print("--------------------H 00 -- shelfName is --->" + shelfName);
            print("--------------------H 01 -- obj count is --->" + objCount);
            print("--------------------H 02 -- shelf index is --->" + shelfIndex);
        }

        //-------------------------------------- Branch -------------------------------------- B         >> 002 <<
        //-----------------------------------------=====----------------------------------------

        for (int i = 1; i < objCount; i++)              //----====----> BASE LOOP START
        {
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();

            //------------------------  Getting to the SUB --- <

            GameObject obj = shelf_DropZone.transform.GetChild(i).gameObject;               //    object
            GameObject PANELOpen = obj.transform.GetChild(1).gameObject;                    //    PANELOpen
            GameObject NewMedia_SCROLLreC = PANELOpen.transform.GetChild(7).gameObject;     //    NewMedia_SCROLLreC
            GameObject NewInviewer = NewMedia_SCROLLreC.transform.GetChild(1).gameObject;   //    NewInviewer
            GameObject NContent = NewInviewer.transform.GetChild(0).gameObject;             //    NContent 
            

            int NewNameInputCount = NContent.transform.childCount;      // NewNameInput is the child of NContent <----- count
                                                                        // s sub count
            int objIndex = i;
            string objName = obj.transform.GetChild(3).GetComponentInChildren<Text>().text; // name of object - base Text 

            if (2 + 2 == B_DebugOff)
            {
                print("B------------------------------------= B =---------------------------------------------B");
                print("------------------------------------=====---------------------------------------------");
                print("--------------------B-" + i + " -00 -- Sub Count Is---> " + NewNameInputCount);
                print("--------------------B-" + i + " -01 -- Index is ---> " + objIndex);
                print("--------------------B-" + i + " -02 -- Name is ---> " + objName);
            }

            // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------   

            branch.ObjName = objName;
            branch.objOrder = objIndex;
            //print(branch.objOrder);

            homeTree.branch.Add(branch);

            // <<<<<<<<<<<<<<<<<<----------------------------

            //print("--------------------B-" + i + " -01 -- Index is -------------------------------------------------------------> " + objIndex);


            //-------------------------------------- SubLeaf ------------------------ S       >> 003 <<

            for (int x = 1; x < NewNameInputCount; x++)     //set to 1 to drop the extra                    //-----------> SUB LOOP START
            {
                //float i_hold_time;

                GameObject NFeild_parent = NContent.transform.GetChild(x).gameObject; // each SUB obj
                string NewNameIs = NFeild_parent.transform.GetChild(0).GetComponentInChildren<InputField>().text;  //spelunk to SUB Name
                GameObject _Settings = NFeild_parent.transform.GetChild(2).gameObject;

                GameObject video_settings = _Settings.transform.GetChild(5).gameObject; // into video settings
                GameObject v_viewer = video_settings.transform.GetChild(0).gameObject;
                GameObject v_content = v_viewer.transform.GetChild(0).gameObject;
                GameObject blank = v_content.transform.GetChild(0).gameObject;

                Toggle v_on = blank.transform.GetChild(0).GetComponent<Toggle>();                           // v on 
                Toggle v_close = blank.transform.GetChild(1).GetComponent<Toggle>();                        // v close 
                Toggle v_hold = blank.transform.GetChild(2).GetComponent<Toggle>();                         // v hold 
                Toggle v_loop = blank.transform.GetChild(3).GetComponent<Toggle>();                         // v loop 
                string v_imageFile = blank.transform.GetChild(4).GetComponentInChildren<InputField>().text; // v_imageFile 

                string v_imageFile_END;
                if ((blank.transform.GetChild(8).GetComponentInChildren<InputField>().text == "") || (blank.transform.GetChild(8).GetComponentInChildren<InputField>().text == "default"))
                {
                    v_imageFile_END = v_imageFile; // making END image the same as START image
                }
                else
                {
                    v_imageFile_END = blank.transform.GetChild(8).GetComponentInChildren<InputField>().text; // v_imageFile 
                }
                
                float v_vol = float.Parse(blank.transform.GetChild(5).GetComponentInChildren<Text>().text); // v_vol


                float v_fade_out;
                print("v fade out --- on RESAVE -- Js Obj List Write --> " + blank.transform.GetChild(9).GetComponentInChildren<InputField>().text);
                if ((blank.transform.GetChild(9).GetComponentInChildren<InputField>().text == "") || (blank.transform.GetChild(9).GetComponentInChildren<InputField>().text == "0"))
                {
                    v_fade_out = 2.3f;
                    blank.transform.GetChild(9).GetComponentInChildren<InputField>().text = v_fade_out.ToString();
                }
                else
                {
                    print("v fade out --- Js Obj List Write --> " + blank.transform.GetChild(9).GetComponentInChildren<InputField>().text);
                    v_fade_out = float.Parse(blank.transform.GetChild(9).GetComponentInChildren<InputField>().text); // v_fade_out -- NEW   
                }

                GameObject image_settings = _Settings.transform.GetChild(4).gameObject; // into image settings
                GameObject i_viewer = image_settings.transform.GetChild(0).gameObject;
                GameObject i_content = i_viewer.transform.GetChild(0).gameObject;
                GameObject blank_0 = i_content.transform.GetChild(0).gameObject;
                
                Toggle i_on = blank_0.transform.GetChild(0).GetComponent<Toggle>();                       // i_on
                Toggle i_hold = blank_0.transform.GetChild(1).GetComponent<Toggle>();                     // i_hold
                string i_imageFile = blank_0.transform.GetChild(2).GetComponentInChildren<InputField>().text;  // i_imageFile
               
               string i_hold_time = blank_0.transform.GetChild(3).GetComponentInChildren<InputField>().text;
                
                GameObject audio_settings = _Settings.transform.GetChild(3).gameObject; // into audio settings
                GameObject a_viewer = audio_settings.transform.GetChild(0).gameObject;
                GameObject a_content = a_viewer.transform.GetChild(0).gameObject;
                GameObject a_blank = a_content.transform.GetChild(0).gameObject;

                Toggle a_on = a_blank.transform.GetChild(0).GetComponent<Toggle>();                           // a_on
                Toggle a_over = a_blank.transform.GetChild(1).GetComponent<Toggle>();                         // a_over
                Toggle a_after = a_blank.transform.GetChild(2).GetComponent<Toggle>();                        // a_after
                //Toggle a_loop = a_blank.transform.GetChild(3).GetComponent<Toggle>();                        // a_after
                string a_AudioFile = a_blank.transform.GetChild(4).GetComponentInChildren<InputField>().text;  // a_AudioFile

                float a_Vol = float.Parse(a_blank.transform.GetChild(5).GetComponentInChildren<Text>().text);  // aVol - converted from tring to float

                string a_Cues = a_blank.transform.GetChild(6).GetComponentInChildren<InputField>().text;

                float a_Seconds;
                if((a_blank.transform.GetChild(7).GetComponentInChildren<InputField>().text == "") || (a_blank.transform.GetChild(7).GetComponentInChildren<InputField>().text == "0"))
                {
                    a_Seconds = 2.2222f;
                    a_blank.transform.GetChild(7).GetComponent<InputField>().text = a_Seconds.ToString();
                }
                else
                {
                    a_Seconds = float.Parse(a_blank.transform.GetChild(7).GetComponentInChildren<InputField>().text);
                }


                



                if (NewNameIs == "")
                    NewNameIs = "default";
                if (v_imageFile == "")
                    v_imageFile = "default";
                if (i_imageFile == "")
                    i_imageFile = "default";


                if (a_AudioFile == "")
                    a_AudioFile = "default.mp3";



                int subIndexNow = x;                                       // s Index
                int subIndex = subIndexNow;

                if (2 + 2 == S_DebugOff)                                         // Debug
                {
                    print("S-------------------------------------= S =-----------------------------------------------S");
                    print("--------------------S- " + x + " -01 -- Name Is---> " + NewNameIs);

                    print("S-------------------------------------= video - S =-----------------------------------------------S");
                    print("--------------------vS-" + i + " -02 -- v on toggle state is ---> " + v_on.isOn);
                    print("--------------------vS-" + i + " -03 -- v_close toggle state is ---> " + v_close.isOn);
                    print("--------------------vS-" + i + " -04 -- v_hold toggle state is ---> " + v_hold.isOn);
                    print("--------------------vS-" + i + " -05 -- v_loop toggle state is ---> " + v_loop.isOn);
                    print("--------------------vS-" + i + " -06 -- v_imageFile button is ---> " + v_imageFile);
                    print("--------------------vS-" + i + " -06 -- v_imageFile button is ---> " + v_vol);

                    print("S-------------------------------------= image - S =-----------------------------------------------S");
                    print("--------------------vS-" + i + " -07 -- i_on toggle state is ---> " + i_on.isOn);
                    print("--------------------vS-" + i + " -08 -- i_hold toggle state is ---> " + i_hold.isOn);
                    //print("--------------------vS-" + i + " -08 -- i_hold toggle state is ---> " + i_hold_time);
                    print("--------------------vS-" + i + " -09 -- i_imageFile  is ---> " + i_imageFile);

                    print("S-------------------------------------= audio - S =-----------------------------------------------S");
                    print("--------------------vS-" + i + " -10 -- a_on toggle state is ---> " + a_on.isOn);
                    print("--------------------vS-" + i + " -11 -- a_over toggle state is ---> " + a_over.isOn);
                    print("--------------------vS-" + i + " -12 -- a_after toggle state is ---> " + a_after.isOn);
                    print("--------------------vS-" + i + " -13 -- a_AudioFile  is ---> " + a_AudioFile);
                    print("--------------------vS-" + i + " -14 -- aVol is ---> " + a_Vol);

                    print("--------------------S- " + x + " -02 -- order is ---> " + subIndex);
                   // print("--------------------S- " + x + " -05 -- Hold Time is ---> " + Holdit);
                    //print("--------------------S- " + x + " -06 -- v IN is ---> " + v_IN);
                    //print("--------------------S- " + x + " -07 -- v IN is ---> " + v_OUT);

                    
                }
                // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------   

                branch.subLeaf.Add(new SubLeaf { JName = NewNameIs, JOrder = subIndex,
                    v_ON = v_on.isOn,
                    v_CLOSE = v_close.isOn,
                    v_HOLD = v_hold.isOn,
                    v_LOOP = v_loop.isOn,
                    v_IMAGEFILE = v_imageFile,
                    v_IMAGEFILE_END = v_imageFile_END,
                    v_VOL = v_vol,
                    v_FADE_OUT = v_fade_out,

                    i_ON = i_on.isOn,
                    i_HOLD = i_hold.isOn,
                    i_IMAGEFILE = i_imageFile,
                    i_HOLD_TIME = int.Parse(i_hold_time),

                    a_ON = a_on.isOn,
                    a_OVER = a_over.isOn,
                    a_AFTER = a_after.isOn,
                    a_AUDIOFILE = a_AudioFile,
                    a_VOL = a_Vol,
                    a_CUES = int.Parse(a_Cues),
                    a_SECONDS = a_Seconds } );

                // <<<<<<<<<<<<<<<<<<---------------------------- // removed for now -- i_HOLD_TIME = i_hold_time,
            }                                                                    //-----------> SUB LOOP END




        }                                                  //---====-----> BASE LOOP END


        //====================================== Write to file ======================    >> 004 <<
        shelfIndex = this.transform.GetSiblingIndex();              // shelfIndex
        shelfName = this.transform.name;                            // shelfName
        string filePath; 

        if (shelfName == "00_F_v03") //choose preset file name
            filePath = "F_" + ShelfPresetName.text + ".json";        // if F - filePath
        else                                                            // else _0 filePath
            filePath =  shelfIndex.ToString() + "_" + ShelfPresetName.text + ".json";

        string jSonObj = JsonUtility.ToJson(homeTree, true);
        File.WriteAllText(Application.streamingAssetsPath + "/" + filePath, jSonObj);

        print(Application.streamingAssetsPath + "/" + filePath + "\n" + jSonObj);


        

        // ------------------------------------ FLOW FILE ------------------------------
        //------------------------------------------------------------------------------
       // print("07 ------------------------------------- > FlowName and LastSaved -- ");

        string fName = filePath;
        string sName = filePath;

       // print("08 ------------------------------------- > fName -- " + fName);

        List<FlowPreset> FlowName = new List<FlowPreset>();  // list

        for (int i = 0; i < 1; i++)
        {
            if (fName[0] == 'F')
            {
               // print("06 ---- > if F then - the flowProject preset name is -- " + fName);

                FlowName.Add(new FlowPreset { FlowPresetName = fName });

                string FlowJson = JsonUtility.ToJson(homeTree, true);
                File.WriteAllText(Application.streamingAssetsPath + "/FlowPreset.json", FlowJson);

                print(Application.streamingAssetsPath + "/FlowPreset.json" + "\n" + FlowJson);
            }             
        }

        // ------------------  WRITE Last FLOW FILE - NOTE - SAME AS THE FLOWPRESET (could even get rid of that)  --------------
        //----------------------------------------------------------------------------------------------------------------------


        int shelfCount = shelf_DropZone.transform.parent.parent.childCount;

        ///print("07 ------------------------------------- > shelf count -- " + shelfCount);
        ///print("07a ------------------------------------- > shelf name -- " + shelf_DropZone.transform.parent.gameObject.name);
         
        LastSaved lastSaved = new LastSaved();   // I just had an 'yes' moment!  -- declaration!
        lastSaved.lastPreset = new List<string>();

        if (shelf_DropZone.transform.parent.gameObject.name == "00_F_v03")
        {

            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string lastFlowName = shelf_DropZone.transform.parent.parent.GetChild(4).gameObject.transform.GetChild(8).GetComponentInChildren<Text>().text;
            ///print("07b ------------------------------------- > last Flow name -- " + lastFlowName);
            ///filePath = "F_" + lastFlowName + ".json";
            lastFlowSaved.lastFlowPreset.Add(lastFlowName);

            string LastFlowJson = JsonUtility.ToJson(lastFlowSaved, true);
            File.WriteAllText(Application.streamingAssetsPath + "/LastFlowSaved.json", LastFlowJson);
            
            print(Application.streamingAssetsPath + "/LastFlowSaved.json" + "\n" + LastFlowJson);

            return;

        }

        // ------------------------------------ WRITE Last FILES FOR ALL SHELVES  ------------------------------
        //------------------------------------------------------------------------------

        for (int i = 1; i < shelfCount; i++)
        {
            string LastPresetName = shelf_DropZone.transform.parent.parent.GetChild(i).gameObject.transform.GetChild(5).GetComponentInChildren<Text>().text;
           /// filePath = i + "_" + LastPresetName + ".json";
            ///filePath = LastPresetName;
            lastSaved.lastPreset.Add(LastPresetName);

        }

        string ShelfJson = JsonUtility.ToJson(lastSaved, true);
        File.WriteAllText(Application.streamingAssetsPath + "/LastSaved.json", ShelfJson);

        ///print(Application.streamingAssetsPath + "/LastSaved.json" + "\n" + ShelfJson);


    }










    //---------------------
    // NN    NN
    // NNNN  NN
    // NN NN NN
    // NN  NNNN
    // NN   NNN     // NOTE: THESE ARE THE ORIGONAL TEST FILES THAT WRITE TO THE ON SCREEN DEBUGER $$
    //----------------------------------------------------


    //*******88888888888888888888888888888888888888888888888888888888888888***********************

    public void JsonUtWrite()  // JsObjListWrite  ///////    tester / style
    {
        Presets presets = new Presets();
        presets.shelfPresets = new List<string>();

        string JpresetName = MakePresetName.text;

        presets.shelfPresets.Add(Random.Range(0f, 100000f).ToString());
        presets.shelfPresets.Add("two");
        presets.shelfPresets.Add("three");
        presets.shelfPresets.Add(Random.Range(0f, 100000f).ToString());
        presets.shelfPresets.Add("five");

        string jsonPresets = JsonUtility.ToJson(presets, true);

        //CheckIt2_input.text += Application.streamingAssetsPath + JpresetName + ".json" + "\n";
        //Debug.Log(Application.streamingAssetsPath + JpresetName + ".json");

        File.WriteAllText(Application.streamingAssetsPath + "/" + JpresetName + ".json", jsonPresets);

        CheckIt2_input.text = Application.streamingAssetsPath + "/" + JpresetName + ".json" + "\n" + " / json Presets = " + "\n" + jsonPresets + "\n";

    }//tester



    public void JsonUtRead()
    {

        Presets presets = new Presets();
        presets.shelfPresets = new List<string>();

        string returnThis = "";
        string JpresetName = MakePresetName.text;

        string filePath = Application.streamingAssetsPath + "/" + JpresetName + ".json";
        string jsonPresets = File.ReadAllText(filePath);
        presets = JsonUtility.FromJson<Presets>(jsonPresets);

        foreach (string i in presets.shelfPresets)
        {
            returnThis += i + "\n";
        }

        CheckIt2_input.text = Application.streamingAssetsPath + "/" + JpresetName + ".json" + "\n" + returnThis;
    }//tester






}




