using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



namespace UMP
{
    public class FlowJect : MonoBehaviour
    {
        //--------other Scripts------------
        //public MediaPath mediaPath;
        //public UMP.SetMedia setMedia;

        //---------data paths--------
        public string dir;
        public string dataPath;
        public string DataPath_LS;
        private string mainDataPath;
        private string mPath;
        public string mPathF;
        private string imgPathF;
        public FlowTwo flowTwo;
        public ObjTwo objTwo;
        public List<ObjTwo> ObjT;


        //---------GameObjects--------
        [SerializeField]
        public GameObject OBJ; // the OBJECT
        public GameObject theShelf; //parent of OBJ
        public GameObject tChild;
        //public GameObject objNameplate;
        public RawImage rawImage;
        public GameObject SubObjects;


        Text theText;

        //---------Presetname
        public string newPresetName;
        public InputField newPresetName_Field;
        public string saveAs;
        public string presetName;
        public Text ShelfPresetName;
        public Text ShelfPresetName02;

        //---------Data output------------
        public enum objType { video, still, audio };
        public int objOrder;
        public string objName;
        public float objVol;
        //public string DataPath_LS;
        public string dataFileName = "Obj2.json";
        public int ShelfIndex;
        public Text info_bar;
        public Camera theMainCamera;
        private CamControl camControl;
        //public CamControl camControl

        // NEW vars readable ========== == v02.05
        public GameObject BlackAndShadow;
        public GameObject branchObj;
        public GameObject contentBlack;
        public GameObject content;
            
        public GameObject subLeafObj;
        public GameObject _Image;
        public GameObject _Audio;

        public int branchCount;
        public int subCount;
        public int Branch_Now;
        public int B;
        public int S;
        public int print_vars_4;

        public GameObject Last_SubObj;
        public GameObject SubObj;


        // ----------------------------------=============== 01 ======= BUILD ========----------------------------------- //








        private void Start()
        {
            MPath(); // where is the content
            //ReadObjList();
            camControl = theMainCamera.GetComponent<CamControl>();
            camControl.Main_Menu = 1;
            // SetFlow();
            BuildFlow();

        }

        // -- information about SetFlow
        // reads lastFlowSaved.json
        // populates screen with appopiate number of screens


        public void Update()
        {
            // audio keys

            // video advance/rewind keys
            // pause/play

            SetDirectAudioVolume();

            if (_mediaPlayer_One.IsPlaying || IsPaused == true)
            {
               // print("video is live and IsPaused is = " + IsPaused);
                Pause_Play_Keys();
            }
                
        }

        private bool IsPaused;

        public void Pause_Play_Keys()
        {
            if (camControl.Main_Menu == 0 || IsPaused == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                   // print("Up Hit");
                    _mediaPlayer_One.Play();
                    IsPaused = false;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                   // print("Down Hit");
                    _mediaPlayer_One.Pause();
                    IsPaused = true;

                }
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    // print("Down Hit");
                    _mediaPlayer_One.Position = _mediaPlayer_One.Position + 0.1f;
                    //IsPaused = true;
                }
                if (Input.GetKeyDown(KeyCode.Minus))
                {
                    // print("Down Hit");
                    _mediaPlayer_One.Position = _mediaPlayer_One.Position - 0.1f;
                    //IsPaused = true;
                }
            }
           
        }

        public void JumpAHead_JumpBack()
        {

        }

        public void SetDirectAudioVolume()  //audio controls
        {
            if (Input.GetKeyDown("1"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.05f);
                _mediaPlayer_One.Volume = 10;
                _mediaPlayer_Audio_One.Volume = 10;
            }
            else if (Input.GetKeyDown("2"))
            {
                // videoPlayer.SetDirectAudioVolume(0, 0.1f);
                _mediaPlayer_One.Volume = 20;
                _mediaPlayer_Audio_One.Volume = 20;
            }
            else if (Input.GetKeyDown("3"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.3f);
                _mediaPlayer_One.Volume = 30;
                _mediaPlayer_Audio_One.Volume = 30;
            }
            else if (Input.GetKeyDown("4"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.4f);
                _mediaPlayer_One.Volume = 40;
                _mediaPlayer_Audio_One.Volume = 40;
            }
            else if (Input.GetKeyDown("5"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.5f);
                _mediaPlayer_One.Volume = 50;
                _mediaPlayer_Audio_One.Volume = 50;
            }
            else if (Input.GetKeyDown("6"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.6f);
                _mediaPlayer_One.Volume = 60;
                _mediaPlayer_Audio_One.Volume = 60;
            }
            else if (Input.GetKeyDown("7"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.7f);
                _mediaPlayer_One.Volume = 70;
                _mediaPlayer_Audio_One.Volume = 70;
            }
            else if (Input.GetKeyDown("8"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.8f);
                _mediaPlayer_One.Volume = 80;
                _mediaPlayer_Audio_One.Volume = 80;
            }
            else if (Input.GetKeyDown("9"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 1.0f);
                _mediaPlayer_One.Volume = 90;
                _mediaPlayer_Audio_One.Volume = 90;
            }
            else if (Input.GetKeyDown("0"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.0f);
                _mediaPlayer_One.Volume = 100;
                _mediaPlayer_Audio_One.Volume = 100;
            }
        }

        public Text infoBar;


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
        /// ------------------------------------------------------ build flow
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
        /// ------------------------------------- FLOW JECT ---------------------------======= BuildFlow ======
        /// ---------------------------------------------------------------------------=======================
        /// ---------------------------------------------------------------------------======= ============ == v02.00
        /// ---- Set up everything!

        public void BuildFlow()
        { 
            LastFlowSaved lastFlowSaved = new LastFlowSaved(); 
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            /// 002 ------------ creat list to readSave the flow data into ------------------------- 002
            /// ------------ Read json file "FlowName" from above  ---------
            ///print(" --- CheckFlow ----- json read all vars---------->> " + filePath + "\n" + jSonObjs);

            int bench_index = 0;
            branchCount = homeTree.branch.Count;

            /// 003 -=--- counts branch
            //print(" -- BuildFlow --- branch count ------> " + branchCount);
            //infoBar.text = "branch count = " + branchCount.ToString(); 

           /* for (bench_index = 0; bench_index < branchCount; bench_index++) // <--- loop Branch -------------------------- 1
            {

                //Black and Shadow
                GameObject NewBlack = Instantiate(BlackAndShadow) as GameObject;
                NewBlack.SetActive(true);
                NewBlack.transform.SetParent(contentBlack.transform, false);
            } */


            for (bench_index = 0; bench_index < branchCount; bench_index++) // <--- loop Branch -------------------------- 1
            {
                subCount = homeTree.branch[bench_index].subLeaf.Count;

                //string obOrder = homeTree.branch[bench_index].objOrder.ToString();
                //string obName = homeTree.branch[bench_index].ObjName;

                GameObject NewObj = Instantiate(branchObj) as GameObject;
                NewObj.SetActive(true);
                NewObj.transform.SetParent(content.transform, false);
                //Color32 ColBlack = new Color32(0, 0, 0, 0);
                //NewObj.transform.GetComponent<Image>().color = ColBlack;


                for (int sub_index = 0; sub_index < subCount; sub_index++) // <--- loop Subleaf -------------------------- 2
                {

                        GameObject subM = Instantiate(subLeafObj) as GameObject;
                        subM.SetActive(true);
                        subM.transform.SetParent(content.transform.GetChild(bench_index), false);

                }


            }

            //Vars_Builder();
            Content_Import();
            //TestCarryOverOfLists(jSonObjs);
            //B = 1;
            //S = 1;

        }










        // ----------------------------------=============== 02 ======= IMPORT ========----------------------------------- //




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
        /// ------------------------------------------------------ content_import
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
        /// ------------------------------------- FLOW JECT ---------------------------======= Content_Import ======
        /// ---------------------------------------------------------------------------======================= 210
        /// ---------------------------------------------------------------------------======= ============ == v02.01
        public void Content_Import()
        {
            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            /// 002 ------------ creat list to readSave the flow data into ------------------------- 002
            /// ------------ Read json file "FlowName" from above  ---------
            ///print(" --- CheckFlow ----- json read all vars---------->> " + filePath + "\n" + jSonObjs);

            int branch_index = 0;
            branchCount = homeTree.branch.Count;

            /// 003 -=--- counts branch

            for (branch_index = 0; branch_index < branchCount; branch_index++) // <--- loop Branch -------------------------- 1
            {
                subCount = homeTree.branch[branch_index].subLeaf.Count;

                string obOrder = homeTree.branch[branch_index].objOrder.ToString();
                string obName = homeTree.branch[branch_index].ObjName;

                for (int sub_index = 0; sub_index < subCount; sub_index++) // < --- loop subleaf ------------------------- 2
                {
                    string _name = homeTree.branch[branch_index].subLeaf[sub_index].JName;
                    string _order = homeTree.branch[branch_index].subLeaf[sub_index].JOrder.ToString();
                    string v_IMAGE = homeTree.branch[branch_index].subLeaf[sub_index].v_IMAGEFILE;
                    string v_IMAGE_END = homeTree.branch[branch_index].subLeaf[sub_index].v_IMAGEFILE_END;
                    string i_IMAGE = homeTree.branch[branch_index].subLeaf[sub_index].i_IMAGEFILE;

                    bool v_ON = homeTree.branch[branch_index].subLeaf[sub_index].v_ON;
                    bool v_CLOSE = homeTree.branch[branch_index].subLeaf[sub_index].v_CLOSE;
                    bool v_HOLD = homeTree.branch[branch_index].subLeaf[sub_index].v_HOLD;
                    bool v_LOOP = homeTree.branch[branch_index].subLeaf[sub_index].v_LOOP;
                    float v_VOL = homeTree.branch[branch_index].subLeaf[sub_index].v_VOL;

                    bool i_ON = homeTree.branch[branch_index].subLeaf[sub_index].i_ON;
                    bool i_HOLD = homeTree.branch[branch_index].subLeaf[sub_index].i_HOLD;
                    float i_HOLD_TIME = homeTree.branch[branch_index].subLeaf[sub_index].i_HOLD_TIME;

                    bool a_ON = homeTree.branch[branch_index].subLeaf[sub_index].a_ON;
                    bool a_OVER = homeTree.branch[branch_index].subLeaf[sub_index].a_OVER;
                    bool a_AFTER = homeTree.branch[branch_index].subLeaf[sub_index].a_AFTER;
                    //bool a_LOOP = homeTree.branch[count].subLeaf[x].a_LOOP; // <--> LATER
                    string a_AUDIOFILE = homeTree.branch[branch_index].subLeaf[sub_index].a_AUDIOFILE;
                    float a_VOL = homeTree.branch[branch_index].subLeaf[sub_index].a_VOL;

                    int a_CUES = homeTree.branch[branch_index].subLeaf[sub_index].a_CUES;
                    float a_SECONDS = homeTree.branch[branch_index].subLeaf[sub_index].a_SECONDS;


                    //string subCount = subCount.ToString();

                    //print(" ** name & order **  " + _name + "  <--->  " + _order);
                    //print(" ** v_image & i_image **  " + v_IMAGE + "  <--->  " + i_IMAGE);

                    if (2 + 2 == print_vars_4) 
                    {
                        print("---- CONTENT IMPORT ---- ###########################-> " + "\n" +
                        "   --------------------" + " B " + obOrder + "   S " + _order + "\n" +
                        "   Branch Order        --> " + obOrder + " \n" +
                        "   Branch Name       --> " + obName + " \n" +
                        "   -------------------- " + "\n" +
                        "   _name        --> " + _name + " \n" +
                        "   _order       --> " + _order + " \n" +
                        "   -------------------- " + "\n" +
                        "   -------------------- " + "\n" +
                        "   v_IMAGE      --> " + v_IMAGE + "\n" +
                        "   v_IMAGE_END      --> " + v_IMAGE_END + "\n" +
                        "   v_ON         --> " + v_ON + "\n" +
                        "   v_CLOSE      --> " + v_CLOSE + "\n" +
                        "   v_HOLD       --> " + v_HOLD + "\n" +
                        "   v_LOOP       --> " + v_LOOP + "\n" +
                        "   v_VOL        --> " + v_VOL + "\n" +
                        "   -------------------- " + "\n" +
                        "   i_IMAGE      --> " + i_IMAGE + "\n" +
                        "   i_ON         --> " + i_ON + "\n" +
                        "   i_HOLD       --> " + i_HOLD + "\n" +
                        "   i_HOLD_TIME  --> " + i_HOLD_TIME + "\n" +
                        "   -------------------- " + "\n" +
                        "   a_ON         --> " + a_ON + "\n" +
                        "   a_OVER       --> " + a_OVER + "\n" +
                        "   a_AFTER      --> " + a_AFTER + "\n" +
                        "   a_AUDIOFILE  --> " + a_AUDIOFILE + "\n" +
                        "   a_VOL        --> " + a_VOL + "\n" +
                        "   a_CUES       --> " + a_CUES + "\n" +
                        "   a_SECONDS    --> " + a_SECONDS

                        );
                    }

                    if (B == 0) B++; if (S == 0) S++; // make B = 1 and S = 1
                    /// 1st positions - set
                    /// print("   " + B + " <- B  ---  S -> " + S);
                    /// 
                    GameObject BranchObj = this.transform.GetChild(branch_index).gameObject;
                    GameObject SubObj_Setup = BranchObj.transform.GetChild(sub_index).gameObject;
                    RawImage RawObj = SubObj_Setup.transform.GetComponent<RawImage>();

                    GameObject _Image = SubObj_Setup.transform.GetChild(0).gameObject; // just the _image
                    RawImage Raw_Image = _Image.transform.GetComponent<RawImage>();


                    /// --- > Get RawImage to apply Image to.
                    ///print("   " + branch_index + " <- branch_index  ---  sub_index -> " + sub_index);
                    /// print("  content_management - 1s - now    " + B + " <- B  ---  S -> " + S);

                    SetContent(i_IMAGE, RawObj, Raw_Image);
                    SubObj_Setup.GetComponent<CanvasGroup>().alpha = 1f;

                    if ((branch_index == 0) && (sub_index == 0))
                        camControl.definedButton = SubObj_Setup;

                    if (sub_index != 0)
                    {
                        SubObj_Setup.GetComponent<CanvasGroup>().alpha = 0f;
                        RawObj.raycastTarget = false;
                        //print(" - made false - ");
                    }   /// --- > Turn off all image but the 1's


                    if (sub_index == 0)
                    {
                        SubObj_Setup.GetComponent<CanvasGroup>().alpha = 1f;
                    }


                } // s loop

            } // b loop

            //SubObj = null; // might not need
        }
        ///
        /// ---------------------------------------------------------------------------======= ============== v02.01
        /// ---------------------------------------------------------------------------====================== 359
        /// ------------------------------------- FLOW JECT ---------------------------======= Content_Import ======



        /// -------------------------------------  FlowJect . SetContent  ------------------======= SetContent ======
        /// -------------------------------------------------------------------------------------====================
        /// -------------------------------------------------------------------------------------======= ============ == v02.01
        /// ---- SetContent
        public void SetContent(string imageFile, RawImage RawObj, RawImage Raw_Image)
        {
            // print("---SET IMAGE ----- name -------> return image ---  >  " + ReturnImage);
            MPath();
            mPathF = "file://" + mPath + imageFile + ".jpg";
            //eprint("--- SET IMAGE ----- path -------> Media path -- " + mPathF);

            //theName.text = imageFile;

            StartCoroutine(SetImage2(mPathF, RawObj, Raw_Image));


        }

        public IEnumerator SetImage2(string mPathF, RawImage RawObj, RawImage Raw_Image)
        {
            WWW www = new WWW(mPathF);
            yield return www;

            RawObj.texture = www.texture;
            Raw_Image.texture = www.texture;
            www.Dispose();
            www = null;

        }   /// -------------------------------------------------------------------------------------====================










        // ----------------------------------=============== 03 ======= CTRL ========----------------------------------- //

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
        /// ------------------------------------------------------ Content Control
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
        /// ----------------------------------------------     ====         ====       ===    ======      ====  ----------------------------
        /// ---------------------------------------------  =====   ====     =========  === ====   ====    ====  -------------------------
        /// -------------------------------------------  ====        ====   =====      =======      ====  ====  -----------------------------
        /// ------------------------------------------  ====                ====       ======       ====  ====  ---------------------------
        /// ------------------------------------------  ====                ====       =======     ====   ====  ---------------------------
        /// -------------------------------------------  ====        ====   ====       ====   ====        ====        ==  -----------------------
        /// --------------------------------------------  =====   =====      ===   =   ====    =====      =============  ------------------------------
        /// ----------------------------------------------   =======          =====    ====      =======  ============  --------------------------------
        /// 



        /// -------------------------------------  FlowJect . Content_Control  ------------------======= Content_Control ======
        /// -------------------------------------------------------------------------------------====================
        /// -------------------------------------------------------------------------------------======= ============ == v02.03
        /// ---- Sets what content is viewed based on Last_B / Last_S & B /S 
        /// /// --- > determin what the Last_Subj and SubObj are to pass to FADE_OUT_IN


        //private IEnumerator FadeInOut;

        public void Content_Control()
        {
            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);
            /// 002 ------------ creat list to readSave the flow data into ------------------------- 002
            /// ------------ Read json file "FlowName" from above  ---------
            ///print(" --- CheckFlow ----- json read all vars---------->> " + filePath + "\n" + jSonObjs);
            ///

            //------------------------------------------------------------------------------------------------------- controls ---------//
            
            if (Last_B == 0)
            {
                Last_B++;
                Last_S++;
            }

            GameObject Last_BranchObj = this.transform.GetChild(Last_B - 1).gameObject;
            Last_SubObj = Last_BranchObj.transform.GetChild(Last_S - 1).gameObject;
            RawImage Last_RawObj = Last_SubObj.transform.GetComponent<RawImage>();

            /// < --Last BS position------------------------------------ 01
            /// 
            /// print("   content_control -  Last    " + Last_B + " <- Last_B  ---  Last_S -> " + Last_S);


            
            GameObject BranchObj = this.transform.GetChild(B - 1).gameObject;
            SubObj = BranchObj.transform.GetChild(S - 1).gameObject;
            RawImage RawObj = SubObj.transform.GetComponent<RawImage>();

            /// < --Now BS position------------------------------------ 02
            ///
            /// print("   content_control - now    " + B + " <- B  ---  S -> " + S);

            StartCoroutine(Fade_Out_In(RawObj, Last_RawObj));

        }
        /// 
        /// ---- Sets what content is viewed based on Last_B / Last_S & B /S 
        /// -------------------------------------------------------------------------------------======= ============ == v02.03
        /// -------------------------------------------------------------------------------------====================
        /// -----------------------------------------  FlowJect . Content_Control  --------------======= Content_Control ======



            /// --------------------------------- ====  =   ===  ====
            /// --------------------------------- ===  ===  =  = ===  -  image
            ///                                   =   =   = ===  ====




        /// -------------------------------------  FlowJect . Fade_Out_In  ----------------------======= Fade_Out_In ======
        /// -------------------------------------------------------------------------------------==================== == 488
        /// -------------------------------------------------------------------------------------======= ============ == v02.04
        /// COROUTINE CALLED BY CONTENT_CONTROL TO FADE BETWEEN SUBS
        /// once up it CALLS MEDIA

        private IEnumerator Fade_Out_In(RawImage RawObj, RawImage Last_RawObj)
        {
            float startTime = Time.time; // time out first fade
            float startTime2 = Time.time; // time out second fade

            if (SubObj != null)
            {
            
                RawObj.raycastTarget = true;
                camControl.definedButton = SubObj;

                if (Last_S != 1)
                {
                    Last_RawObj.raycastTarget = false;
                }

                
                if ((S != 1) && (S > Last_S)) //  --- FADE UP SUB
                {
                    while (SubObj.GetComponent<CanvasGroup>().alpha < 0.99f)
                    {
                        if ((S == 1) || (S > Last_S) || (S != 1))
                        {
                            SubObj.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(SubObj.GetComponent<CanvasGroup>().alpha, 2f, Time.deltaTime * 2);
                            yield return null;

                            if (Time.time - startTime > 2f)
                                break;

                        }
                    }
                }


                if ((Last_S != 1) && (Last_S > S) && (Last_B == B)) //  --- FADE DOWN LAST
                {
                    while (Last_SubObj.GetComponent<CanvasGroup>().alpha > 0.01f)
                    {
                        Last_SubObj.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(Last_SubObj.GetComponent<CanvasGroup>().alpha, -1f, Time.deltaTime * 2);

                        yield return null;

                        if (Time.time - startTime2 > 2f)
                            break;

                    }
                }

                if (Sub_Image != null)
                    if (Sub_Image.GetComponent<CanvasGroup>().alpha < 0.1f)
                        Sub_Image.GetComponent<CanvasGroup>().alpha = 1;


            }

           // print("reached .95");
            yield return new WaitForSeconds(0.25f);
            CALL_Media();
            
        }
        ///
        /// -------------------------------------------------------------------------------------======= ============ == v02.04
        /// -------------------------------------------------------------------------------------==================== == 535
        /// -----------------------------------------  FlowJect . Fade_Out_In  ------------------======= Fade_Out_In ======

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
        /// ------------------------------------------------------ call media
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
        /// -----------------  =====           =====           ====         =========        ====       ======  ====  ---------------------------------
        /// -----------------  ======         ======       =====   ====     ====     ====    ====    ====      =====  ------------------------
        /// -----------------  =======       =======     ====        ====   ====      ====          ====        ====  ------------------------------
        /// -----------------  ========     ========    =======    ======   ====       ====  ====  ====         ====  ------------------------------
        /// -----------------  ==== ====   ==== ====    =================   ====       ====  ====  ====         ====  -----------------------------------
        /// -----------------  ====  ==== ====  ====     ====               ====      ====   ====   ====        ====  --------------------------------
        /// -----------------  ====   =======   ====       =====   =====     ====    ====    ====     =====     =====  ------------------------------
        /// -----------------  ====    =====    ====         =======        ===========      ====        ======= =====   -------------------------


        /// -------------------------------------  FlowJect . CALL_Media  ----------------------======= CALL_Media ======
        /// ------------------------------------------------------------------------------------========================= == 542
        /// ------------------------------------------------------------------------------------======= ================= == v02.04
        /// ----  CALLS AND PLAYS MEDIA -
        /// 

        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer_One = null;
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer_Two = null;
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer_Audio_One = null;
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer_Audio_two = null;

        private int a_CUES;
        private float a_SECONDS;
        private float Audio_One_StartTime;
        private int Cue_Count;
        private string v_IMAGE;
        private string v_IMAGE_END;
        private RawImage Raw_End_Image;
        private bool v_CLOSE;
        private bool v_HOLD;
        private bool i_Hold;



        public void CALL_Media()
        {
            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            /// 002 ------------ creat list to readSave the flow data into ------------------------- 002
            /// ------------ Read json file "FlowName" from above  ---------
            ///print(" --- CheckFlow ----- json read all vars---------->> " + filePath + "\n" + jSonObjs);

            string _name = homeTree.branch[B - 1].subLeaf[S - 1].JName;
            string _order = homeTree.branch[B - 1].subLeaf[S - 1].JOrder.ToString();
            v_IMAGE = homeTree.branch[B - 1].subLeaf[S - 1].v_IMAGEFILE;
            v_IMAGE_END = homeTree.branch[B - 1].subLeaf[S - 1].v_IMAGEFILE_END;
            string i_IMAGE = homeTree.branch[B - 1].subLeaf[S - 1].i_IMAGEFILE;

            bool v_ON = homeTree.branch[B - 1].subLeaf[S - 1].v_ON;
            v_CLOSE = homeTree.branch[B - 1].subLeaf[S - 1].v_CLOSE;
            v_HOLD = homeTree.branch[B - 1].subLeaf[S - 1].v_HOLD;
            bool v_LOOP = homeTree.branch[B - 1].subLeaf[S - 1].v_LOOP;
            float v_VOL = homeTree.branch[B - 1].subLeaf[S - 1].v_VOL;

            bool i_ON = homeTree.branch[B - 1].subLeaf[S - 1].i_ON;
            bool i_HOLD = homeTree.branch[B - 1].subLeaf[S - 1].i_HOLD;
            float i_HOLD_TIME = homeTree.branch[B - 1].subLeaf[S - 1].i_HOLD_TIME; // NEED ANOTHER ONE OF THESE FOR AUDIO

            bool a_ON = homeTree.branch[B - 1].subLeaf[S - 1].a_ON;
            bool a_OVER = homeTree.branch[B - 1].subLeaf[S - 1].a_OVER;
            bool a_AFTER = homeTree.branch[B - 1].subLeaf[S - 1].a_AFTER;
            //bool a_LOOP = homeTree.branch[count].subLeaf[x].a_LOOP; // <--> LATER
            string a_AUDIOFILE = homeTree.branch[B - 1].subLeaf[S - 1].a_AUDIOFILE;
            float a_VOL = homeTree.branch[B - 1].subLeaf[S - 1].a_VOL;
            a_CUES = homeTree.branch[B - 1].subLeaf[S - 1].a_CUES;
            a_SECONDS = homeTree.branch[B - 1].subLeaf[S - 1].a_SECONDS;


            //v_IMAGE, i_IMAGE, 
            //v_ON, v_CLOSE, v_HOLD, v_LOOP, v_VOL, 
            //i_ON, i_HOLD, i_HOLD_TIME, 
            //a_ON, a_OVER, a_AFTER, a_AUDIOFILE, a_VOL, 


            if (2 + 2 == print_vars_4)
            {
                print("---- CALL MEDIA # ---- ###########################-> " + "\n" +

                "   -------------------- " + "\n" +
                "   _name        --> " + _name + " \n" +
                "   _order       --> " + _order + " \n" +
                "   -------------------- " + "\n" +
                "   -------------------- " + "\n" +
                "   v_IMAGE      --> " + v_IMAGE + "\n" +
                "   v_IMAGE_END      --> " + v_IMAGE_END + "\n" +
                "   v_ON         --> " + v_ON + "\n" +
                "   v_CLOSE      --> " + v_CLOSE + "\n" +
                "   v_HOLD       --> " + v_HOLD + "\n" +
                "   v_LOOP       --> " + v_LOOP + "\n" +
                "   v_VOL        --> " + v_VOL + "\n" +
                "   -------------------- " + "\n" +
                "   i_IMAGE      --> " + i_IMAGE + "\n" +
                "   i_ON         --> " + i_ON + "\n" +
                "   i_HOLD       --> " + i_HOLD + "\n" +
                "   i_HOLD_TIME  --> " + i_HOLD_TIME + "\n" +
                "   -------------------- " + "\n" +
                "   a_ON         --> " + a_ON + "\n" +
                "   a_OVER       --> " + a_OVER + "\n" +
                "   a_AFTER      --> " + a_AFTER + "\n" +
                "   a_AUDIOFILE  --> " + a_AUDIOFILE + "\n" +
                "   a_VOL        --> " + a_VOL

                );
            }


            if (v_ON == true)  ///////////////////////////////////////////////////////////////////////// = VIDEO
            {
                GameObject BranchObj = this.transform.GetChild(B - 1).gameObject;
                GameObject SubObj_Setup = BranchObj.transform.GetChild(S - 1).gameObject;
                RawImage RawObj = SubObj_Setup.transform.GetComponent<RawImage>();

                GameObject _Image = SubObj_Setup.transform.GetChild(0).gameObject; // ------------------------------------------ just the _image
                RawImage Raw_Image = _Image.transform.GetComponent<RawImage>();
                Raw_End_Image = Raw_Image;

                Video_Image_Start(); // reset Video Image START 

                GameObject[] VideoOutPutObjects = new GameObject[] { SubObj_Setup }; // CALL UP RAWIMAGE FOR VIDEOS
                _mediaPlayer_One.RenderingObjects = VideoOutPutObjects; // SET RAWIMAGE TO RENDERING OBJECTS
                _mediaPlayer_One.Path = mPath + _name + ".mp4"; // PATH TO VIDEO

                endPos = 0; // SET THE END POSSITION TO 0
                _mediaPlayer_One.Play(); // PLAY
                _mediaPlayer_One.Volume = v_VOL * 10;
                _mediaPlayer_One.Position = 0.0f; // PLAY AT START

                //print(_Image.name + "   =   " + VideoOutPutObjects[0] + "   vol   " + a_VOL);

                StartCoroutine(Fade_Image(_Image));
                Invoke("SetUpEndPos", 0.25f);

                // if (_mediaPlayer_One.IsPlaying)
                //print("Audio is playing");
                print("v_vol = " + v_VOL);
                
            }

            //print(_mediaPlayer_Audio_One.IsPlaying);

            ///Note: this method is not allowing audio to stop before something else happensg


            if (a_ON == true)  ///////////////////////////////////////////////////////////////////////////// = AUDIO
            {
                a_On_Is_True = true;
                Now_a_CUES = a_CUES; // this does not happen if there is no audio active on Next

                if (_mediaPlayer_Audio_One.IsPlaying) //the previous has not stopped playing
                {
                    print("media - 1 audio is playing");
                    if (Cue_Count >= Now_a_CUES)
                        _mediaPlayer_Audio_One.Stop();

                    print("media - 1 audio is playing");
                    print("media - 1 Cue_Count = " + Cue_Count);
                    print("media - 1 Now_a_CUES  =  " + Now_a_CUES);

                    return; // print("----------- Audio is already playing so leave -----------");
                }
                else
                {
                    print("media - 1 audio is NOT playing");
                }
               
                Cue_Count = 0;

                print("2 play new audio ");
                print("2 Now_a_CUES  =  " + Now_a_CUES);

                GameObject BranchObj = this.transform.GetChild(B - 1).gameObject;
                GameObject SubObj_Setup = BranchObj.transform.GetChild(S - 1).gameObject;
                RawImage RawObj = SubObj_Setup.transform.GetComponent<RawImage>();

                GameObject _Audio = SubObj_Setup.transform.GetChild(1).gameObject; // ------------------------------------------ just the Audio
                RawImage Raw_Audio = _Audio.transform.GetComponent<RawImage>();

                GameObject[] AudioOutPutObjects = new GameObject[] { _Audio }; // CALL UP RAWIMAGE FOR Audio
                _mediaPlayer_Audio_One.RenderingObjects = AudioOutPutObjects; // SET RAWIMAGE TO RENDERING OBJECTS
                _mediaPlayer_Audio_One.Path = mPath + a_AUDIOFILE; // PATH TO VIDEO

                Audio_endPos = 0; // SET THE END POSSITION TO 0

                _mediaPlayer_Audio_One.Play(); // PLAY
                _mediaPlayer_Audio_One.Volume = 0.0f;
                _mediaPlayer_Audio_One.Position = 0.0f; // PLAY AT START
                AudioPaused = false;


                StartCoroutine(A_Fade_up(a_VOL, a_SECONDS));

                //StartCoroutine(Fade_Up_Audio(_Audio, a_VOL, a_SECONDS));
                Invoke("SetUpEndPos_Audio", 0.25f);
                //Invoke("SetUpEndPos", 0.25f);
            }
            else
            {
                a_On_Is_True = false;
                audio_Fading = false;
            }

            //print(_mediaPlayer_Audio_One.IsPlaying);

        }
        ///
        /// -------------------------------------------------------------------------------------======= ================= == v02.04
        /// -------------------------------------------------------------------------------------========================= == 695
        /// -------------------------------------  FlowJect . CALL_Media  ------------------- ---======= CALL_Media ======
        ///
       


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
        /// ------------------------------------------------------ fade video images v vol
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
        /// --------------------------------- ====  =   ===  ====   =   = = ===  ===   =
        /// --------------------------------- ===  ===  =  = ===     = =  = =  = ==   = =   - images - v_vol
        /// --------------------------------- =   =   = ===  ====     =   = ===  ===   =





        /// -----------  FlowJect . IE Fade_Image / SetUpEndPos / EndReached / IE Fade_Image_Up =========================
        /// ------------------------------------------------------------------------------------========================= == 700
        /// ------------------------------------------------------------------------------------========================= == 700
        /// ------------------------------------------------------------------------------------========================= == 700
        /// ------------------------------------------------------------------------------------======= ================= == v02.05
        /// ----1. FADE OUT IMAGE -
        /// ----2. DETERMAIN WHEN VIDEO WILL END
        /// ----3. WAIT FOR END REACHED
        /// ----4. FADE UP IMAGE -
        /// ----5. Fade_Image_VIDEO AUDIO
        /// 
        private int Now_a_CUES;
        private GameObject Sub_Image; // ------------------------------------------ just the _image
        private GameObject Sub_Audio;
        private float endPos;
        private float endPos_Audio;
        private float Audio_endPos;
        private float post = 0.1f;

        /// --------------------------------------------------------1. Fade_Image -----------------------------========================= == 709
        /// 
        private IEnumerator Fade_Image(GameObject _Image)
        {
            float startTime = Time.time;
            yield return new WaitForSeconds(1f); // --- to avoid the white flash, wait for the video to start

            Sub_Image = _Image; // ------------------------------------------ just the _image

            while (Sub_Image.GetComponent<CanvasGroup>().alpha > 0.01f)
            {
                Sub_Image.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(Sub_Image.GetComponent<CanvasGroup>().alpha, -1.0f, Time.deltaTime * 2);
                yield return null;

                if (Time.time - startTime > 2f) // timer to break Coroutine
                    break;
            }

            yield return new WaitForSeconds(0.01f);

            print("vol = " + _mediaPlayer_One.Volume); 
        }

  

        /// ---------------------------------------------------------2. SetUpEndPos ----------------------------========================= == 729

        public void SetUpEndPos()  //  <---- calculating the EndPos -----------
        {

            long theTime = _mediaPlayer_One.Time;
            long theLength = _mediaPlayer_One.Length;

            long theB = 1000;
            int x = (int)theB;
            int i = (int)theLength;
            float subt = i - x;
            endPos = subt / i;
            //print("--- SETUP END POS ------ num--------endPos ----> " + endPos);
        }

        /// ---------------------------------------------------------2A. SetUpEndPos_Audio ----------------------------========================= == 729
        
        public void SetUpEndPos_Audio()  //  <---- calculating the EndPos -----------
        {

            long theTime = _mediaPlayer_Audio_One.Time;
            long theLength = _mediaPlayer_Audio_One.Length;

            long theB = 1000;
            int x = (int)theB;
            int i = (int)theLength;
            float subt = i - x;
            endPos_Audio = subt / i;
            //print("--- SETUP END POS ------ num--------endPos ----> " + endPos);
        }

        /// --------------------------------------------------------------3. EndReached -----------------------========================= == 747

        public void EndReached()
        {
            //print("--- End Reached --- _mediaPlayer.Position  -------------> " + _mediaPlayer_One.Position);

            if ((_mediaPlayer_One.Position > post) && (_mediaPlayer_One.Position > endPos)) //  --  && (v_HOLD_p == true))
            {
                //print("--- End Reached --- message --- paused -------------> ");
                _mediaPlayer_One.Pause();
                StartCoroutine(Fade_Image_Up());
                return;
            }

        }

        private bool AudioPaused; 

        public void EndReached_Audio()
        {
            //print("--- End Reached --- _mediaPlayer.Position  -------------> " + _mediaPlayer_One.Position);

            if ((_mediaPlayer_Audio_One.Position > post) && (_mediaPlayer_Audio_One.Position > endPos_Audio)) //  --  && (v_HOLD_p == true))
            {
                //print("--- End Reached --- message --- paused -------------> ");
                _mediaPlayer_Audio_One.Pause();
                print(" Audio Paused --------------------------------  --------------------------------  ------------ Audio Paused");
                AudioPaused = true;
                _GoForward();
                return;
            }

        }


        public void Stop_MediaPlayer_One() // for when a button is press to go back to menu
        {
            _mediaPlayer_One.Stop();
        }

        public void AudioEndReached()
        {
            _mediaPlayer_Audio_One.Volume = 0.0f;
            _mediaPlayer_Audio_One.Stop();
            _GoForward();

        }


        /// --------------------------------------------------------------4. Fade_Image_Up -----------------------========================= == 747 
        /// 
        private IEnumerator Fade_Image_Up() // NOTE: BRING UP v_IMAGEFILE_END  <--
        {
            Video_Image_END(); // change END image

            float startTime = Time.time;
            //yield return new WaitForSeconds(1f);

            while (Sub_Image.GetComponent<CanvasGroup>().alpha < 0.97f)
            {
                Sub_Image.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(Sub_Image.GetComponent<CanvasGroup>().alpha, 3.0f, Time.deltaTime * 2);
                yield return null;

                if (Time.time - startTime > 2f)
                    break;

            }

            yield return new WaitForSeconds(0.01f);
            //print("finished");

            if(v_HOLD == false)
            {
                _GoForward(); 
            }

            //_GoForward(); // - NEED CONTROLER HERE

        }

        /// --------------------------------------------------------------5. Fade_Image_VIDEO AUDIO ------ NOT USING THIS -----------------========================= == 747 
        /// 

        private IEnumerator Fade_Up_Video_Audio( float v_VOL)
        {


            float startTime_Audio_One = Time.time;
            yield return new WaitForSeconds(0.1f); // --- to avoid the white flash, wait for the video to start

            Sub_Audio = _Audio; // ------------------------------------------ just the _image

            //print("volume is =  " + _mediaPlayer_Audio_One.Volume);
            //print(a_VOL * 10);

            while (_mediaPlayer_One.Volume < v_VOL * 10)
            {
                _mediaPlayer_One.Volume = Mathf.Lerp(_mediaPlayer_One.Volume, v_VOL * 10, Time.deltaTime * 4f);
                yield return null;
            }
            //print("volume is =  " + _mediaPlayer_Audio_One.Volume);

            yield return new WaitForSeconds(0.01f);
            print("v vol = " + _mediaPlayer_One.Volume);

        }



        ///
        /// -----------------------------------------------------------------------------------------======= ================= == v02.05
        /// -----------------------------------------------------------------------------------------========================= == 785
        /// --------------- FlowJect . IE Fade_Image / SetUpEndPos / EndReached / IE Fade_Image_Up --=========================
        /// 

        /////////////////////////// ====== ==   =  ====    =====   =
        /////////////////////////// ==     = =  =  =   =    
        /////////////////////////// ====   =  = =  =    =   image
        /////////////////////////// ==     =   ==  =   =
        /////////////////////////// ====== =    =  ====

        /// ------------------------ End Image updater -------------
        /// 

        public void Video_Image_END()
        {
            MPath();
            mPathF = "file://" + mPath + v_IMAGE_END + ".jpg";
            StartCoroutine(SetImage_END(mPathF, Raw_End_Image));
        }

        public void Video_Image_Start()  // reset START image
        {
            MPath();
            mPathF = "file://" + mPath + v_IMAGE + ".jpg";
            StartCoroutine(SetImage_END(mPathF, Raw_End_Image));
        }

        public IEnumerator SetImage_END(string mPathF, RawImage Raw_End_Image)
        {
            WWW www = new WWW(mPathF);
            yield return www;

            // RawObj.texture = www.texture;
            Raw_End_Image.texture = www.texture;
            www.Dispose();
            www = null;


        }   /// -------------------------------------------------------------------------------------====================

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
        /// ------------------------------------------------------ fade Audio
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
        /// --------------------------------- ====  =   ===  ====     =   =  = ===   =  == 
        /// --------------------------------- ===  ===  =  = ===     = =  =  = =  =  = =  =
        /// --------------------------------- =   =   = ===  ====   =   =  ==  ===   =  ==


        /// -----------  FlowJect . IE Fade_Up_Audio /  /  / IE Fade_Down_Audio =========================
        /// ------------------------------------------------------------------------------------========================= == 860
        /// ------------------------------------------------------------------------------------========================= == 860
        /// ------------------------------------------------------------------------------------========================= == 
        /// ------------------------------------------------------------------------------------======= ================= == v02.05
        /// ----1. FADE UP AUDIO -
        /// ----2. 
        /// ----3. WAIT FOR END REACHED
        /// ----4. FADE UP IMAGE -
        /// 

        private bool a_On_Is_True;



        /// --------------------------------------------------------1. Fade_Up_Audio -----------------------------========================= == 709
        /// 
        private bool audio_Fading;
        private bool allready_running = false;



        private IEnumerator A_Fade_up(float a_VOL, float a_SECONDS)
        {
            print("A fade up ---START--- volume is =  " + _mediaPlayer_Audio_One.Volume);
            while (_mediaPlayer_Audio_One.Volume < a_VOL * 10)
            {

                _mediaPlayer_Audio_One.Volume += 1f;        // fade up by 1s
                yield return new WaitForSeconds(0.01f);     // slow down the fade up but 0.01seconds each loop

                print("A fade up ---RISE--- volume is =  " + _mediaPlayer_Audio_One.Volume);

                yield return null;
            }

            print("A fade up ---END--- volume is =  " + _mediaPlayer_Audio_One.Volume);
        }


        /// --------------------------------------------------------1. Fade_Down_Audio -----------------------------========================= == 709


        private IEnumerator Fade_Down_Audio() // -- (GameObject _Audio, float a_VOL)
        {
            //print("fade_down_audio - a_SECONDS == " + a_SECONDS);
            print("fade down  --- volume is =  " + _mediaPlayer_Audio_One.Volume);
            
            Cue_Count++;
            print("3 FADE DOWN - Cue_Count = " + Cue_Count);

            if (Cue_Count == Now_a_CUES)
            {
                print("3 Cue_Count == Now_a_CUES == " + Cue_Count + "  --  " + Now_a_CUES);

                if (AudioPaused == false) // is the audio still playing
                {
                    while (_mediaPlayer_Audio_One.Volume >= 1)
                    {

                        _mediaPlayer_Audio_One.Volume -= 1f;                    // fade down by 1s
                        yield return new WaitForSeconds(a_SECONDS * 0.01f);     // slow down fade by a_seconds * 0.01 seconds each loop

                        print("A fade DOWN ---DROP--- volume is =  " + _mediaPlayer_Audio_One.Volume);

                        yield return null;

                    }
                }
                else
                {
                    _mediaPlayer_Audio_One.Volume = 0f;
                    print("A fade DOWN --- Audio is paused --- volume is =  " + _mediaPlayer_Audio_One.Volume);
                    _mediaPlayer_Audio_One.Stop();
                    audio_Fading = false;
                    //_GoForward();
                    yield return new WaitForSeconds(0.01f);
                }

            
                print("fade down after --- volume is =  " + _mediaPlayer_Audio_One.Volume);
                _mediaPlayer_Audio_One.Stop();
                audio_Fading = false;
                //Invoke("Content_Control", 0.1f);
            }
            else
            {
                //Invoke("Content_Control", 0.1f);
            }
            

            
        }

        public IEnumerator Fade_Down_Audio_Cut() // -- (GameObject _Audio, float a_VOL)
        {

                float startTime_Audio_One = Time.time;
                yield return new WaitForSeconds(0.1f); // --- to avoid the white flash, wait for the video to start

                Sub_Audio = _Audio; // ------------------------------------------ just the _image

                while (_mediaPlayer_Audio_One.Volume >= 1)
                {
                    _mediaPlayer_Audio_One.Volume -= 1f;                    // fade down by 1s
                    yield return new WaitForSeconds(a_SECONDS * 0.01f);     // slow down fade by a_seconds * 0.01 seconds each loop

                    yield return null;
                }

            print("4 turn off audio  =  " + Cue_Count + "  --  " + Now_a_CUES);

            _mediaPlayer_Audio_One.Stop();


        }






        // ----------------------------------=============== 04 ======== GO =======----------------------------------- //


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
        /// ------------------------------------------------------ GO
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
        /// ----------------------------------------------    ===             ====    --------------------------------
        /// ---------------------------------------------  =========        =========  -------------------------------
        /// -------------------------------------------  ====     ====   =====     ====  -----------------------------
        /// ------------------------------------------  ====             ====       ====  ---------------------------
        /// ------------------------------------------  ====    =======  ====        ====  ---------------------------
        /// -------------------------------------------  ====   =======   ====      ====  -----------------------------
        /// --------------------------------------------  ====     ===      ==========  ------------------------------
        /// ----------------------------------------------   =======          =====   --------------------------------
        ///   




            


        /// ---------------------  FlowJect . _GoClickedOn_Subleaf  --------------------======= _GoClickedOn_Subleaf ======
        /// --------------------------------------------------------------------------------====================
        /// --------------------------------------------------------------------------------======= ============ == v02.00
        /// ---- GET SUB CLICKED ON.
        /// 
        public GameObject SubLeafClicked;

        public void _GoClickedOn_Subleaf()
        {
            Stop_Media();
            camControl.Main_Menu = 0;
            B = SubLeafClicked.transform.parent.GetSiblingIndex() + 1;
            S = SubLeafClicked.transform.GetSiblingIndex() + 1;

            ReturnSubCount();
            Content_Control();
        }

        /// -------------------------------------  FlowJect . _GoForward  ------------------======= _GoForward ======
        /// --------------------------------------------------------------------------------====================
        /// --------------------------------------------------------------------------------======= ============ == v02.00
        /// ---- TRACKS WHAT BRANCH AND SUB ARE ACTIVE
        /// ---- WHAT THE SUBCOUNT IS FOR THE ACTIVE BRANCH
        /// ---- THEN SENDS THIS INFORMATION TO - CONTENT_CONTROL()
        /// 
        /// ---- ADDS A NUMBER TO B and or S then feeds it into Content_Control
        /// ---- If at end of Flow it will reset to 1's
        /// 

        private int Last_B;
        private int Last_S;

        public void _GoForward() 
        {
            print("GoFo  =  Cue_Count  --  Now_a_CUES  =  " + Cue_Count + "  --  " + Now_a_CUES);

            Stop_Media();
            Last_B = B; Last_S = S; // save Last position - need to turn media and ray off
            bool End = false;  // if end then something or somewhere else.

            if ((B == branchCount) && (S == subCount)) // -- end of flow
            {
                End = true;
                // main menu
                // slow down reset (kind of works)
                Back_to_0s();
                StartCoroutine(Fade_Down_Audio_Cut());
                return;
            }

            if ((B == 1) && (S == 1))   // -- start of flow
                ReturnSubCount();

            if (S < subCount) S++;      // -- not at last of subCount of the branch  
            else if (B < branchCount)   // -- not at last branch
            {
                B++;
                ReturnSubCount();
                S = 1;

                camControl.Main_Menu = 1; // at end of story -- go to main menu
                StartCoroutine(Fade_Down_Audio_Cut());
                return;
            }
           ///print("   now    " + B + " <- B  ---  S -> " + S);
           /// print("   then    " + Last_B + " <- Last_B  ---  Last_S -> " + Last_S);

            if (End == false)
            {
                if(1+1 == 2)
                {
                    StartCoroutine(Fade_Down_Audio()); // counts CUES
                   // return;
                }


                 if (Cue_Count == Now_a_CUES) // audio needs to fade out
                 {
                     Invoke("Content_Control", a_SECONDS);  // slow down the program to give the audio time to fade out
                 }
                 else
                 {
                     Invoke("Content_Control", 0.1f); // no audio fade so faster
                 }

                 return; // so we don't hit StartCoroutine(Fade_Down_Audio()) twice and jump the Cue ahead
                 

            }
                
            //StartCoroutine(Fade_Down_Audio_Cut());

        }

        /// --------------------------------------------------------------------------------=========== Back_to_0s ========= v02.01
        /// ---- reset to 1's
        public void Back_to_0s()
        {
            B = 1; S = 1; Flow_End();
            camControl.definedButton = camControl.Canvas;
            camControl.Main_Menu = 1;
        }



        /// -------------------------------------  FlowJect . _GoBack  ------------------======= _GoBack ======
        /// -----------------------------------------------------------------------------====================
        /// -----------------------------------------------------------------------------======= ============ == v02.00
        /// ---- go to Last

        public void _GoBack()

        {
                
            Stop_Media();
            Last_B = B; Last_S = S; // save Last position
            bool End = false;

            if (S > 1) S--;         // -- at not at first sub go back a sub
            else if (B > 1)         // -- if not at first branch 
            {
                B--;                // -- go back a branch
                ReturnSubCount();   // -- get new subcount
                S = subCount;
            }
            else
            {
                End = true;
                Back_to_0s();
                StartCoroutine(Fade_Down_Audio_Cut()); // counts CUES
                //camControl.Main_Menu = 1;
                //print("main menu");
                return;

            }
           
            print("   now    " + B + " <- B  ---  S -> " + S);
            print("   then    " + Last_B + " <- Last_B  ---  Last_S -> " + Last_S);
            if (End == false)
            {
                StartCoroutine(Fade_Down_Audio()); // counts CUES
                Content_Control();
                return;
            }

            //StartCoroutine(Fade_Down_Audio_Cut());
        }

        /// -------------------------------------  FlowJect . stop media  ------------------======= Stop_Media ======
        /// 
        private void Stop_Media()
        {
            if (_mediaPlayer_Audio_One.IsPlaying)
            {
                print(" GoFo AudioPlaying = Cue_Count  --  Now_a_CUES  =  " + Cue_Count + "  --  " + Now_a_CUES);

            }


            if (_mediaPlayer_One.IsPlaying)
            {
                //StartCoroutine(Fade_Image_Up());

                // print(" is playing ");
                _mediaPlayer_One.Stop();

                // print(" stopped ");
            }


        }


        /// 
        /// -----------------------------------------------------------------------------======= ============ == v02.00
        /// -----------------------------------------------------------------------------====================
        /// -------------------------------------  FlowJect . _GoBack  ------------------======= _GoBack ======





        /// ---------------------------------------------- go ------------------------------====================






        /// -------------------------------------  FlowJect . ReturnSubCount  ---------======= ReturnSubCount ======
        /// ---------------------------------------------------------------------------=============================
        /// ---------------------------------------------------------------------------======= ===================== == v02.00
        /// set's the SubCount varible to the SubCount of the Active Branch 
        /// -- needed for next and last fuctions
        /// 




        public void ReturnSubCount()
        {
            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            subCount = homeTree.branch[B - 1].subLeaf.Count;
            //print("-                                    -------------                                       -");
            //print("   ReturnSubCount   -- " + B + " <- B  ---  subCount -> " + subCount);

        }




        // ----------------------------------=============== 05 ===============----------------------------------- //


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
        /// ------------------------------------------------------ flow_end
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
        /// -------------------------------------------  ============  ====        ====  ======    --------------------------------
        /// -------------------------------------------  ============  ======      ====  =============    -------------------------------
        /// -------------------------------------------  ====          =======     ====  ====       ====    -----------------------------
        /// -------------------------------------------  =========     ========    ====  ====        ====   ---------------------------
        /// -------------------------------------------  =========     ====  ====  ====  ====        ====  ---------------------------
        /// -------------------------------------------  ====          ====   ==== ====  ====       ====  -----------------------------
        /// -------------------------------------------  ============  ====     =======  ==============  ------------------------------
        /// -------------------------------------------  ============  ====      ======  ==========    --------------------------------



        /// -------------------------------------  FlowJect . Flow_End  ------------------======= Flow_End ======
        /// -----------------------------------------------------------------------------====================
        /// -----------------------------------------------------------------------------======= ============ == v02.00
        /// ---- Reset alternative ----

        public void Flow_End()
        {
            LastFlowSaved lastFlowSaved = new LastFlowSaved();
            lastFlowSaved.lastFlowPreset = new List<string>();

            string filePath = Application.streamingAssetsPath + "/LastFlowSaved.json";
            string flowJson = File.ReadAllText(filePath);
            lastFlowSaved = JsonUtility.FromJson<LastFlowSaved>(flowJson);

            string FlowName = lastFlowSaved.lastFlowPreset[0];

            /// 001 -----------   creat list to readSave LastFlowSaved name into   ------------------- 001
            /// -----------   Read json file "/LastFlowSaved.json" and get first name in list  ----------------
            /// print("--- FLOWJET ---- LastFlowSaved ------------" + FlowName);

            filePath = Application.streamingAssetsPath + "/F_" + FlowName + ".json";

            HomeTree homeTree = new HomeTree();             // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            homeTree.branch = new List<Branch>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            Branch branch = new Branch();                   // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------
            branch.subLeaf = new List<SubLeaf>();           // SET LISTS <<<<<<<<<<<<<<<<<<<-----------------

            string jSonObjs = File.ReadAllText(filePath);
            homeTree = JsonUtility.FromJson<HomeTree>(jSonObjs);  // reading file if exists
            branch = JsonUtility.FromJson<Branch>(jSonObjs);

            /// 002 ------------ creat list to readSave the flow data into ------------------------- 002
            /// ------------ Read json file "FlowName" from above  ---------
            ///print(" --- CheckFlow ----- json read all vars---------->> " + filePath + "\n" + jSonObjs);

            int branch_index = 0;
            branchCount = homeTree.branch.Count;

            /// 003 -=--- counts branch

            for (branch_index = 0; branch_index < branchCount; branch_index++) // <--- loop Branch -------------------------- 1
            {
                subCount = homeTree.branch[branch_index].subLeaf.Count;

                string obOrder = homeTree.branch[branch_index].objOrder.ToString();
                string obName = homeTree.branch[branch_index].ObjName;

                for (int sub_index = 0; sub_index < subCount; sub_index++) // < --- loop subleaf ------------------------- 2
                {
                   /// string _name = homeTree.branch[branch_index].subLeaf[sub_index].JName;
                   /// string _order = homeTree.branch[branch_index].subLeaf[sub_index].JOrder.ToString();
                    string v_IMAGE = homeTree.branch[branch_index].subLeaf[sub_index].v_IMAGEFILE;
                    string i_IMAGE = homeTree.branch[branch_index].subLeaf[sub_index].i_IMAGEFILE;

                    /// bool v_ON = homeTree.branch[branch_index].subLeaf[sub_index].v_ON;
                    /// bool v_CLOSE = homeTree.branch[branch_index].subLeaf[sub_index].v_CLOSE;
                    /// bool v_HOLD = homeTree.branch[branch_index].subLeaf[sub_index].v_HOLD;
                    /// bool v_LOOP = homeTree.branch[branch_index].subLeaf[sub_index].v_LOOP;
                    /// float v_VOL = homeTree.branch[branch_index].subLeaf[sub_index].v_VOL;

                    /// bool i_ON = homeTree.branch[branch_index].subLeaf[sub_index].i_ON;
                    /// bool i_HOLD = homeTree.branch[branch_index].subLeaf[sub_index].i_HOLD;
                    /// float i_HOLD_TIME = homeTree.branch[branch_index].subLeaf[sub_index].i_HOLD_TIME;

                    /// bool a_ON = homeTree.branch[branch_index].subLeaf[sub_index].a_ON;
                    /// bool a_OVER = homeTree.branch[branch_index].subLeaf[sub_index].a_OVER;
                    /// bool a_AFTER = homeTree.branch[branch_index].subLeaf[sub_index].a_AFTER;
                    ///bool a_LOOP = homeTree.branch[count].subLeaf[x].a_LOOP; // <--> LATER
                    /// string a_AUDIOFILE = homeTree.branch[branch_index].subLeaf[sub_index].a_AUDIOFILE;
                    /// float a_VOL = homeTree.branch[branch_index].subLeaf[sub_index].a_VOL;

                    GameObject BranchObj = this.transform.GetChild(branch_index).gameObject;
                    GameObject SubObj_Setup = BranchObj.transform.GetChild(sub_index).gameObject;
                    RawImage RawObj = SubObj_Setup.transform.GetComponent<RawImage>();

                    GameObject _Image = SubObj_Setup.transform.GetChild(0).gameObject; // just the _image
                    RawImage Raw_Image = _Image.transform.GetComponent<RawImage>();


                    /// --- > Get RawImage to apply Image to.
                    //print("   " + branch_index + " <- branch_index  ---  sub_index -> " + sub_index);
                        /// print("  content_management - 1s - now    " + B + " <- B  ---  S -> " + S);

                        SetContent(i_IMAGE, RawObj, Raw_Image);
                        SubObj_Setup.GetComponent<CanvasGroup>().alpha = 1f;

                        if ((branch_index == 0) && (sub_index == 0))
                            camControl.definedButton = SubObj_Setup;

                        if (sub_index != 0)
                        {
                            SubObj_Setup.GetComponent<CanvasGroup>().alpha = 0f;
                            RawObj.raycastTarget = false;
                            //print(" - made false - ");
                        }   /// --- > Turn off all image but the 1's




                } // s loop
            } // b loop

            SubObj = null;

        }






        public void TestCarryOverOfLists(string jSonObjs)
        {
            print(" --- TestCarryOverOfLists ----- json all vars---------->> " + jSonObjs);

        }











        // ------------------------------------- FLOW JECT ---------------------------======= DATAT PATHS ======
        // ---------------------------------------------------------------------------==========================
        // ---------------------------------------------------------------------------======= =============== ==
        // ---- PATH
        //
        public void DataPaths() 
        {
            dir = Application.dataPath;
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName;

            dataPath = dir + "/flowmedia/";
            dataPath = dataPath.Replace('\\', '/');
            mPath = dataPath;


            mainDataPath = dir + "/flowmedia/data/";
            mainDataPath = mainDataPath.Replace('\\', '/');
            //DataPath_LS = mainDataPath;

            DataPath_LS = Application.streamingAssetsPath + "/data/";

            //print("-----------paths------------");
            //print("path media --- " + mPath);
            //print("path data --- " + DataPath_LS);

        }


        // ------------------------------------- Flow Ject ---------------------------======== PATH ========
        // ---------------------------------------------------------------------------======================
        // ---------------------------------------------------------------------------======================

        public void MPath() //---------------- path to movies
        {
            dir = Application.dataPath;
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName;

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
}

