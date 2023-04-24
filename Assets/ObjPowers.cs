using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ObjPowers : MonoBehaviour
{
    public UMP.UmpScript umpScript;

    public ObjControl objControl;
    public MediaList_MS mediaList_MS;
    public JsonScript jsonScript;

    public RawImage ButtonImage;
    public GameObject NFeild_parent;
    public GameObject NContent_Holder;
    public GameObject thisObject;
    public GameObject theShelf;
    public GameObject shelf_DropZone;

    public int objCount;
    public string MainName01;
    public Text title_name;
    public Text ShelfPresetName;
    private List<GameObject> buttons;
    private List<string> TheNames;

    public int B_DebugOff = 4;
    public int subLeafDebugOff = 4;

    public GameObject RefreshOne;
    public GameObject RefreshTwo;
    public Toggle object_updated;
    public Text mediaNum;

    private void Start()
    {

        buttons = new List<GameObject>();

    }


    //==================================    SUPER_POWERS   =============================================================


    // ------------------------------------- Obj Powers --------------------------======= triger Super Powers ====== 001
    // ---------------------------------------------------------------------------==================================
    // ---------------------------------------------------------------------------==================================

    public void trigerSuperPowers() //trigger save off all objects on a shelf------------000
    {
        objCount = shelf_DropZone.transform.childCount;
       // print("01--objCount=====================================%---------->> " + objCount);
        for(int y = 1; y < objCount; y++)
        {
            GameObject objw = shelf_DropZone.transform.GetChild(y).gameObject;
            GameObject mediaSetting_btnSetUp = objw.transform.GetChild(5).gameObject;
            GameObject vMButs_bk = mediaSetting_btnSetUp.transform.GetChild(1).gameObject;
            Button vMBut_C = vMButs_bk.transform.GetChild(2).GetComponent<Button>();
            vMBut_C.onClick.Invoke(); // forces opening of object panel
            VideoButtonImage(); // Go down to video button image and set the image.
            Button vMBut_O = vMButs_bk.transform.GetChild(0).GetComponent<Button>();
            vMBut_O.onClick.Invoke(); // forces closing of object pane1
        }

    }//-------------------------------trigger save off all objects on a shelf------------000

    // ------------------------------------- Obj Powers --------------------------======== triger Video Button Image ====== 001
    // ---------------------------------------------------------------------------=========================================
    // ---------------------------------------------------------------------------=============================== =========
    public void trigerVideoButtonImage()
    {
        objCount = shelf_DropZone.transform.childCount; // this does the same as the one above - without going to VideoButtonImage
        print("01--objCount=====================================%---------->> " + objCount);
        for (int y = 1; y < objCount; y++)
        {
            GameObject objw = shelf_DropZone.transform.GetChild(y).gameObject;
            GameObject mediaSetting_btnSetUp = objw.transform.GetChild(5).gameObject;
            GameObject vMButs_bk = mediaSetting_btnSetUp.transform.GetChild(1).gameObject;
            Button vMBut_C = vMButs_bk.transform.GetChild(2).GetComponent<Button>();
            vMBut_C.onClick.Invoke();
            Button vMBut_O = vMButs_bk.transform.GetChild(0).GetComponent<Button>();
            vMBut_O.onClick.Invoke();
        }

    }

    private string mPathF; // vars
    private bool v_onCheck;
    private string v_imageFileCheck;
    private bool i_onCheck;
    private string i_imageFileCheck;

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
    /// ------------------------------------------------------ Video Button Image
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
    // ------------------------------------- Obj Powers --------------------------======== Video Button Image ====== 001
    // ---------------------------------------------------------------------------==================================
    // ---------------------------------------------------------------------------======================== =========

    private string NameOfSubStory;
    public void VideoButtonImage()
    {
        MPath();

        //--------------- note: this is only using information from the 1st Sub Button of each obj  -----------


        if (NContent_Holder.transform.childCount > 1) // CHECK TO SEE IF IT'S A NEW BUTTON - true if not - find name of video or image
        {
            GameObject NFeild_par = NContent_Holder.transform.GetChild(1).gameObject;
            MainName01 = NFeild_par.transform.GetChild(0).GetComponentInChildren<InputField>().text; // name of sub but Inputfeild
            //print(" -- VideoButtonImage---111---MainName01--->" + MainName01);
            NameOfSubStory = MainName01;

            GameObject _Settings = NFeild_par.transform.GetChild(2).gameObject;

            GameObject video_settings = _Settings.transform.GetChild(5).gameObject; // into video settings
            GameObject v_viewer = video_settings.transform.GetChild(0).gameObject;
            GameObject v_content = v_viewer.transform.GetChild(0).gameObject;
            GameObject blank = v_content.transform.GetChild(0).gameObject;

            v_onCheck = blank.transform.GetChild(0).GetComponent<Toggle>().isOn; // is video on
            v_imageFileCheck = blank.transform.GetChild(4).GetComponentInChildren<InputField>().text; // get button image?

            if((v_imageFileCheck == "default") && (NameOfSubStory != "default")) // -- same as if statement below
            {
                v_imageFileCheck = NameOfSubStory;
                blank.transform.GetChild(4).GetComponentInChildren<InputField>().text = NameOfSubStory;
            }


            ///print("--- video button image ----122----- v_onCheck --> " + v_onCheck);
            ///print("--- video button image ----123----- v_imageFileCheck --> " + v_imageFileCheck);

            GameObject image_settings = _Settings.transform.GetChild(4).gameObject; // into image settings
            GameObject i_viewer = image_settings.transform.GetChild(0).gameObject;
            GameObject i_content = i_viewer.transform.GetChild(0).gameObject;
            GameObject i_blank = i_content.transform.GetChild(0).gameObject;

            i_onCheck = i_blank.transform.GetChild(0).GetComponent<Toggle>().isOn;
            i_imageFileCheck = i_blank.transform.GetChild(2).GetComponentInChildren<InputField>().text; // get image file name

            if((i_imageFileCheck == "default") && (NameOfSubStory != "default")) // if the i_image file IS "default" and the Name of Sub Story is NOT "default"
            {
                i_imageFileCheck = NameOfSubStory; // then make the i_image file the same as the Name of Sub Story
                i_blank.transform.GetChild(2).GetComponentInChildren<InputField>().text = NameOfSubStory; // make the i_image field text the same as Name of Sub Story
            } // NOTE: ##########  THIS ONLY WORKS FOR THE FIRST SUB OBJECT (WOULD NEED A LOOP TO DO ALL OF THEM)
         
            ///print("--- video button image ----132----- i_onCheck --> " + i_onCheck);
           /// print("--- video button image ----133----- i_imageFileCheck --> " + i_imageFileCheck);

        }
        else
        {
            GameObject NFeild_parent = NContent_Holder.transform.GetChild(0).gameObject;
            //print("--- video button image ----138---mess-- it's a new button --> " );

            GameObject MakeBtn = Instantiate(NFeild_parent) as GameObject;   // make a new button
            MakeBtn.SetActive(true);
            MakeBtn.transform.SetParent(NFeild_parent.transform.parent, false);

            GameObject NFeild_parent_created = NContent_Holder.transform.GetChild(1).gameObject; // new object setup
            MainName01 = "default";
            NFeild_parent_created.transform.GetChild(0).GetComponentInChildren<InputField>().text = MainName01;

            NFeild_parent.SetActive(false);

            //v_onCheck = true;

            MainName01 = NFeild_parent_created.transform.GetChild(0).GetComponentInChildren<InputField>().text;


        }

        if (v_onCheck == true) //-------------------- IMAGE CHECK ---------------------------------------------------------------------
        {
            if(v_imageFileCheck != null)
            {
                if (v_imageFileCheck != "default") // if there is different image for butten the use it
                {
                    MainName01 = v_imageFileCheck; // use set video image button
                    mPathF = "file:///" + mPath + MainName01 + ".jpg";
                }
                else
                {
                    MainName01 = v_imageFileCheck;
                    mPathF = "file:///" + mPath + MainName01 + ".jpg";
                }

                ///print("--- video button image ----165----- MainName01 --> " + MainName01);
                ///print(mPathF);

            }
           
        }
        if (i_onCheck == true)
        {
            if (i_imageFileCheck != null)
            {
                if(i_imageFileCheck != "default")
                {
                    MainName01 = i_imageFileCheck; // use still image
                    mPathF = "file:///" + mPath + MainName01 + ".jpg"; 
                }
                else
                {
                    MainName01 = i_imageFileCheck;
                    mPathF = "file:///" + mPath + MainName01 + ".jpg";
                }

                ///MainName01 = i_imageFileCheck; // use still image
               ///print("image file ----->----" + i_imageFileCheck);

            }
                
        }

       // mPathF = "file:///" + mPath + MainName01 + ".jpg";

       if (MainName01 == null)
        {
            MainName01 = NameOfSubStory;
            mPathF = "file:///" + mPath + MainName01 + ".jpg";
        }

       /// print("NameOfSubStory 206 ----->----" + NameOfSubStory);
       /// print("MainName01 207 ----->----" + MainName01);
       /// print("mPath 208 ----->----" + mPathF);

        if (mPathF ==  null)
        {
            MainName01 = NameOfSubStory;
            mPathF = "file:///" + mPath + MainName01 + ".jpg";
        }

        //if (mPathF == null)

        jsonScript.LoadingShelves.GetComponent<Text>().text = "Loading images...";

        StartCoroutine(SetVideoImage(mPathF)); // set button image
        
        title_name.text = MainName01;  //set title

    }

    public IEnumerator SetVideoImage(string url) 
    {

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

        ButtonImage.texture = www.texture;
        www.Dispose();
        www = null;

    }//---------------------------------------------set the video image button-----------001



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
    /// ------------------------------------------------------ Super Powers
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
    // ------------------------------------- Obj Powers --------------------------======== Super Powers ====== 001
    // ---------------------------------------------------------------------------============================
    // ---------------------------------------------------------------------------======== set sub vars ======
    public void SuperPowers()
    {

        if (object_updated.isOn == true)
            return;
        

        string filePath = "";
        int ShelfIndex = theShelf.transform.GetSiblingIndex();   
        ///--- get the shelfindex
        ///objControl.DataPaths();                            
        ///---get dataPaths
        ///ShelfNum.text = ShelfIndex.ToString(); 
        /// set shelf number
        string ShelfName = theShelf.transform.name;
        string thisObject = this.transform.name;
        int thisObjectIndex = this.transform.GetSiblingIndex();

        ///string presetName = ShelfPresetName.text;            
        ///--- get the presetName -note: will need to add something like this to set the preset button list
        ///print("01--thisObject---------->> " + thisObject);
        ///print("02--shelf-Name---------->> " + ShelfName);

        if (ShelfName == "00_F_v03")
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
           // print("04--json read---------->> " + filePath + "\n" + jSonObjs);

        }
        else  // writing default
        {
            branch.ObjName = "default";                 // setting the default
            branch.objOrder = 0;

            homeTree.branch.Add(branch);

            branch.subLeaf.Add(new SubLeaf              // setting the default
            {
                JName = "default",
                JOrder = 0,
                v_ON = true,
                v_CLOSE = true,
                v_HOLD = false,
                v_LOOP = false,
                v_VOL = 5.0f,
                v_IMAGEFILE = "default",
                v_IMAGEFILE_END = "default",
                v_FADE_IN = 2.0f,
                v_FADE_OUT = 2.0f,

                i_ON = false,
                i_HOLD = true,
                //i_HOLD_TIME = 3f,
                i_IMAGEFILE = "default",


                a_ON = false,
                a_OVER = true,
                a_AFTER = false,
                a_AUDIOFILE = "default.mp3",
                a_VOL = 8.0f,
                a_CUES = 1,
                a_SECONDS = 2.555f,
                a_FADE_IN = 2.0f,
                a_FADE_OUT = 2.0f

            });

            // writing the default
            string jSonObjs = JsonUtility.ToJson(homeTree, true);
            File.WriteAllText(filePath, jSonObjs);
            print("04--json written---------->> " + filePath + "\n" + jSonObjs);

        }// writing default

        //print("<------------------------   POPULATE SHELF   ------------------------>");
        ///-------------------------- Branch LOOP STARTS ---------================== 002

        int count = thisObjectIndex - 1;
        string obOrder = homeTree.branch[count].objOrder.ToString();
        string obName = homeTree.branch[count].ObjName;

        if (2 + 2 == B_DebugOff)
        {
            print("B------------------------------------= B  ReadObjListUtility  <=---------------------------------------------B");
            print("------------------------------------=====---------------------------------------------");
            //print("--------------------B-" + i + " -00 -- Sub Count Is---> " + NewNameInputCount);
            print("--------------------B-" + count + " -01 -- Index is ---> " + obOrder);
            print("--------------------B-" + count + " -02 -- Name is ---> " + obName);

        }

        //------------------------------------------------------- SUB LOOP STARTS ----------------

        if (buttons.Count > 0)  //clean up
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        ///print("--------------- object child count -  > " + this.transform.parent.childCount);
        ///print("--------------- cout -  > " + count);
        ///print("--------------- NContent child cout -  > " + NContent_Holder.transform.childCount);


        TheNames = new List<string>();  // MIGHT NOT BE USED

        int subcount = homeTree.branch[count].subLeaf.Count;
        for (int x = 0; x < subcount; x++)
        {

            GameObject MakeBtn = Instantiate(NFeild_parent) as GameObject;   // make button
            MakeBtn.SetActive(true);
            MakeBtn.transform.SetParent(NFeild_parent.transform.parent, false);


            string NewNameIs = homeTree.branch[count].subLeaf[x].JName;

            int subIndex = homeTree.branch[count].subLeaf[x].JOrder;

            // ---------------------------------------------------------- get values from MAIN VARIABLES
            // video
            bool v_on = homeTree.branch[count].subLeaf[x].v_ON;
            bool v_close = homeTree.branch[count].subLeaf[x].v_CLOSE;
            bool v_hold = homeTree.branch[count].subLeaf[x].v_HOLD;
            bool v_loop = homeTree.branch[count].subLeaf[x].v_LOOP;
            float v_Vol = homeTree.branch[count].subLeaf[x].v_VOL;
            string v_imageFile = homeTree.branch[count].subLeaf[x].v_IMAGEFILE;
            string v_imageFile_END = homeTree.branch[count].subLeaf[x].v_IMAGEFILE_END;

            float v_fade_out = homeTree.branch[count].subLeaf[x].v_FADE_OUT;
            print(" v fade out from ObjPowers --> " + homeTree.branch[count].subLeaf[x].v_FADE_OUT);

            // image
            bool i_on = homeTree.branch[count].subLeaf[x].i_ON;
            bool i_hold = homeTree.branch[count].subLeaf[x].i_HOLD;
            float i_hold_time = homeTree.branch[count].subLeaf[x].i_HOLD_TIME;
            string i_imageFile = homeTree.branch[count].subLeaf[x].i_IMAGEFILE;

            // audio
            bool a_on = homeTree.branch[count].subLeaf[x].a_ON;
            bool a_over = homeTree.branch[count].subLeaf[x].a_OVER;
            bool a_after = homeTree.branch[count].subLeaf[x].a_AFTER;
            string a_AudioFile = homeTree.branch[count].subLeaf[x].a_AUDIOFILE;
            float a_Vol = homeTree.branch[count].subLeaf[x].a_VOL;
            int a_Cues = homeTree.branch[count].subLeaf[x].a_CUES;
            float a_Seconds = homeTree.branch[count].subLeaf[x].a_SECONDS;


            //GameObject NFeild_parent = NContent.transform.GetChild(x).gameObject;


            if (2 + 2 == subLeafDebugOff)
            {
                print("-- subLeafDebugOff -b----------431-------------> " + count + "---s-> " + x + "\n" +

                "NewNameIs  > " + NewNameIs + " -- " +
                "subIndex  > " + subIndex + "\n" +
                "v_on  > " + v_on + "\n" +
                "v_close  > " + v_close + "\n" +
                "v_hold  > " + v_hold + "\n" +
                "v_loop  > " + v_loop + "\n" +
                "v_Vol  > " + v_Vol + "\n" +
                "v_imageFile  > " + v_imageFile + "\n" +
                "v_imageFile_END  > " + v_imageFile_END + "\n" +
                "i_on  > " + i_on + "\n" +
                "i_hold  > " + i_hold + "\n" +
                "i_hold_time  > " + i_hold_time + "\n" +
                "i_imageFile  > " + i_imageFile + "\n" +
                "a_on  > " + a_on + "\n" +
                "a_over  > " + a_over + "\n" +
                "a_after  > " + a_after + "\n" +
                "a_AudioFile  > " + a_AudioFile + "\n" +
                "a_Vol  > " + a_Vol + "\n" +
                "a_Cues  > " + a_Cues + "\n" +
                "a_Seconds  > " + a_Seconds + "\n" 
                );
            }

            // ---> BUILD SHELF CONTENT <---

            //GameObject NFeild_p = NContent_Holder.transform.GetChild(x).gameObject;

            NFeild_parent.transform.GetChild(0).GetComponentInChildren<InputField>().text = NewNameIs; // + " b" + count.ToString() + " s" + x;
            GameObject _Settings = NFeild_parent.transform.GetChild(2).gameObject;

            GameObject video_settings = _Settings.transform.GetChild(5).gameObject; // into video settings
            GameObject v_viewer = video_settings.transform.GetChild(0).gameObject;
            GameObject v_content = v_viewer.transform.GetChild(0).gameObject;
            GameObject blank = v_content.transform.GetChild(0).gameObject;

            blank.transform.GetChild(0).GetComponent<Toggle>().isOn = v_on;
            blank.transform.GetChild(1).GetComponent<Toggle>().isOn = v_close;
            blank.transform.GetChild(2).GetComponent<Toggle>().isOn = v_hold;
            blank.transform.GetChild(3).GetComponent<Toggle>().isOn = v_loop;
            blank.transform.GetChild(4).GetComponentInChildren<InputField>().text = v_imageFile;
            blank.transform.GetChild(8).GetComponentInChildren<InputField>().text = v_imageFile_END;
            blank.transform.GetChild(5).GetComponentInChildren<Text>().text = v_Vol.ToString();

            blank.transform.GetChild(9).GetComponentInChildren<InputField>().text = v_fade_out.ToString(); //  -- new
            print(" v fade out from ObjPowers --> " + blank.transform.GetChild(9).GetComponentInChildren<InputField>().text);

            // blank.transform.GetChild(6).GetComponentInChildren<Slider>().value = v_Vol / 10;
            // print()

            //print("--- SuperPowers -----472----->  " + blank.transform.GetChild(5).GetComponentInChildren<Text>().text);

            GameObject image_settings = _Settings.transform.GetChild(4).gameObject; // into image settings
            GameObject i_viewer = image_settings.transform.GetChild(0).gameObject;
            GameObject i_content = i_viewer.transform.GetChild(0).gameObject;
            GameObject i_blank = i_content.transform.GetChild(0).gameObject;

            i_blank.transform.GetChild(0).GetComponent<Toggle>().isOn = i_on;
            i_blank.transform.GetChild(1).GetComponent<Toggle>().isOn = i_hold;
            i_blank.transform.GetChild(2).GetComponentInChildren<InputField>().text = i_imageFile;
            i_blank.transform.GetChild(3).GetComponentInChildren<InputField>().text = i_hold_time.ToString(); //-- TO DO

            GameObject audio_settings = _Settings.transform.GetChild(3).gameObject; // into image settings
            GameObject a_viewer = audio_settings.transform.GetChild(0).gameObject;
            GameObject a_content = a_viewer.transform.GetChild(0).gameObject;
            GameObject a_blank = a_content.transform.GetChild(0).gameObject;

            a_blank.transform.GetChild(0).GetComponent<Toggle>().isOn = a_on;
            a_blank.transform.GetChild(1).GetComponent<Toggle>().isOn = a_over;
            a_blank.transform.GetChild(2).GetComponent<Toggle>().isOn = a_after;
            //blank.transform.GetChild(3).GetComponent<Toggle>().isOn = a_loop;
            a_blank.transform.GetChild(4).GetComponent<InputField>().text = a_AudioFile;
            a_blank.transform.GetChild(5).GetComponentInChildren<Text>().text = a_Vol.ToString();

            a_blank.transform.GetChild(6).GetComponent<InputField>().text = a_Cues.ToString();

            a_blank.transform.GetChild(7).GetComponent<InputField>().text = a_Seconds.ToString();



            buttons.Add(MakeBtn.gameObject);

           mediaNum.text = subIndex.ToString();  // <------------ index number on button

           // Destroy(MakeBtn);

        }
        //------------------------------------------------------- SUB LOOP end ----------------

        NContent_Holder.transform.GetChild(0).gameObject.transform.SetSiblingIndex(subcount); // send top to bottom (i don't know why it goes up there)
        NContent_Holder.transform.GetChild(0).gameObject.SetActive(false);                    // make default vanish

        object_updated.isOn = true;  // this objects has been saved... don't do this again.


    }

    // ------------------------------------- Obj Powers --------------------------======== Path to Flowmedia ======= 001
    // ---------------------------------------------------------------------------==================================
    // ---------------------------------------------------------------------------==================================

    public string dir;
    public string dataPath;
    public string mPath;

    public void MPath() // path to movies
    {
        dir = Application.dataPath;
        dir = System.IO.Directory.GetParent(dir).FullName;
        dir = System.IO.Directory.GetParent(dir).FullName;

        dataPath = dir + "/flowmedia/";
        dataPath = dataPath.Replace('\\', '/');
        //Debug.Log("path = " + dataPath);

        mPath = dataPath;
        //print(mPath);

        //makeTestList.dataPath2 = dataPath;
        //instTestList.dataPath3 = dataPath;
        //objListControl.dataPath4 = dataPath;


    }


}






