using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;



namespace UMP
{
    public class CamControl : MonoBehaviour
    {
        public GameObject definedButton;

        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer = null;


        private Vector3 camLocation;// sets up for target focus
        public Vector3 offset = new Vector3(0f, 0f, -2f);
        public Vector3 homeCam2 = new Vector3(0f, 0f, -16f);
        public Vector3 upArrow = new Vector3(0f, -100f, 0f);
        public Vector3 downArrow = new Vector3(0f, 0f, 0f);
        public Vector3 leftArrow = new Vector3(0f, 0f, 0f);
        public Vector3 rightArrow = new Vector3(100f, 0f, 0f);
        public Vector3 CubeStart = new Vector3(-100f, -100f, 0f);
        public GameObject theCube;
        public GameObject TheContent;
        public GameObject Canvas;

        public float camSpeed = 3f;
        public Text now_text; // for passing var to a global state
        public Text next_text;
        public Text Reset_vid; // on the RAW
        public int Main_Menu;

        // is the video playing?
        public VideoPlayer videoPlayer;

        //other script 
        //private WorldSpaceVideo worldSpaceVideo;
        // [SerializeField]
        public SubMediaPowers subMediaPowers;
        public SetMedia setMedia;
        public FlowJect flowJect;
        public int playingPaused; // if = 1, the movie is playing
                                  // public SetMedia setMedia;

        // ------------------------------------- CAM CONTROL -------------------------======== START ======
        // ---------------------------------------------------------------------------=====================
        // ---------------------------------------------------------------------------=====================
        public GameObject Raw_Media_SubObject;
        private void Awake()
        {

            flowJect = TheContent.GetComponent<FlowJect>();
            setMedia = Raw_Media_SubObject.GetComponent<SetMedia>();
        }

        void Start()
        {
            definedButton = Canvas;
            //theCube.transform.position = Canvas.transform.position + CubeStart;
            //videoPlayer = GetComponent<VideoPlayer>();
            //  setMedia = GetComponent<UMP.SetMedia>();


        }

        // ------------------------------------- CAM CONTROL -------------------------======= UPDATE ======
        // ---------------------------------------------------------------------------=====================
        // ---------------------------------------------------------------------------=====================

        public void Update()
        {

            //theCube.transform.position = Vector3.Lerp(theCube.transform.position, definedButton.transform.position + upArrow + rightArrow, Time.deltaTime * 2);
            theCube.transform.position = definedButton.transform.position + upArrow + rightArrow;
            Quaternion OriginalRot = transform.rotation;
            this.transform.LookAt(theCube.transform); // camera looks at
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, camSpeed * Time.deltaTime / 2);
            camLocation = transform.position;

            if (Main_Menu == 0) // zoom in?
            {
                //Main_Menu = 0;
                // print(" -----------  click on this  -----  " + definedButton.name  + " - " + (definedButton.transform.GetSiblingIndex()-1));//**has the button pressed been read?

                transform.position = Vector3.Lerp(camLocation, definedButton.transform.position + offset, camSpeed * Time.deltaTime);
                theCube.transform.position = definedButton.transform.position;
                upArrow = new Vector3(0f, 0f, 0f);
                rightArrow = new Vector3(0f, 0f, 0f);
                //print(" -----------  click on this  -----  " + definedButton.name + " - " + (definedButton.transform.GetSiblingIndex() - 1));
                Keys_Content_Change();
            }
            else if(Main_Menu != 0) //if (Main_Menu == 1);// pull out?
            {

                transform.position = Vector3.Lerp(camLocation, definedButton.transform.position + homeCam2 + upArrow + rightArrow, camSpeed * Time.deltaTime/2);
                // Note: turn off box collider on Cube so it doesn't get in the way of the btn down scrip
                arrowKeys();
            }
        }
        // ------------------------------------- CAM CONTROL -------------------------======= ARROW KEYS ======
        // ---------------------------------------------------------------------------================================= new =============
        // ---------------------------------------------------------------------------======= PULL OUT ========

        public void arrowKeys()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                upArrow += new Vector3(0f, 0.2f, 0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                upArrow += new Vector3(0f, -0.2f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rightArrow += new Vector3(0.2f, 0.0f, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rightArrow += new Vector3(-0.2f, 0f, 0f);
            }



            
            if (Input.GetKeyDown(KeyCode.Return))  //---------- <- ------- foward ">"
            {
                // setMedia = playNow.GetComponent<SetMedia>(); // get script from setMedia
                // setMedia.HardVideoPause(); // run script to pause video
                // setMedia.HardAudioPause(); // run script to pause audio 
                //Play_Next();
                if (Main_Menu == 0)
                    return;
                Main_Menu = 0;
                //print("strill reading arrowKeys  -- Main_Menu = " + Main_Menu);

                flowJect.Content_Control();

                //flowJect._GoForward();
            }
            

        }

        public int theJOrder; // - var

        // ------------------------------------- CAM CONTROL -------------------------======= KEYS USED ======
        // ---------------------------------------------------------------------------=================================== new ===========
        // ---------------------------------------------------------------------------======= ZOOM IN ========

        

        public void Keys_Content_Change() //video controls when full screen --------------------space bar
        {

            if (Input.GetKeyDown(KeyCode.Tab)) //---------- <- ------- foward ">"
            {
                Main_Menu = 1;

            }



            /// ------------------------------------- key -- RightArrow -- _GoForward -----------------------
            /// 
            
            if (Input.GetKeyDown(KeyCode.RightArrow)) //---------- <- ------- foward ">"
            {
                if (canPlayerFire)
                {
                    StartCoroutine(Go_Forward_Slowly());
                }
            }


            ///
            /// ------------------------------------- key -- RightArrow -- _GoForward -----------------------



            /// ------------------------------------- key -- RightArrow -- _GoBack -----------------------
            /// 
            if (Input.GetKeyDown(KeyCode.LeftArrow)) //---------- <- ------- back "<"
            {
                if (canPlayerFire)
                {
                    StartCoroutine(Go_Back_Slowly());
                }
            }
            ///
            /// ------------------------------------- key -- RightArrow -- _GoBack -----------------------





            if (Input.GetKeyDown(KeyCode.Space)) //---------- <- ------- foward ">"
            {
                //flowJect = TheContent.GetComponent<FlowJect>();
                flowJect._GoForward();
            }

          /*  if (Input.GetKeyDown(KeyCode.UpArrow)) //---------- <- ------- back "<"
            {
                setMedia = playNow.GetComponent<SetMedia>(); // get script from setMedia
                setMedia.AV_PlayPause(v_ON, a_ON); // run script to pause/play AV  
                Main_Menu = 1;

            }*/


        }
        /// ------------------------ Coroutine -- RightArrow -- _GoForward -----------------------
        /// 
        bool canPlayerFire = true;

        public IEnumerator Go_Forward_Slowly()
        {
            //flowJect = TheContent.GetComponent<FlowJect>(); // just to read the script
            flowJect._GoForward();

            canPlayerFire = false;

            yield return new WaitForSeconds(1.0f);

            canPlayerFire = true;
        }
        ///
        /// ------------------------ Coroutine -- RightArrow -- _GoForward -----------------------



        /// ------------------------ Coroutine -- RightArrow -- _GoBack -----------------------
        /// 

        IEnumerator Go_Back_Slowly()
        {
            //flowJect = TheContent.GetComponent<FlowJect>(); // just to read the script
            flowJect._GoBack();

            canPlayerFire = false;

            yield return new WaitForSeconds(1.5f);

            canPlayerFire = true;
        }
        ///
        /// ------------------------ Coroutine -- RightArrow -- _GoBack -----------------------
        /// 


        public GameObject playNow;
        public GameObject playNowAudio;
        public GameObject BranchPar;
        public int Branch_index;

        // ------------------------------------- CAM CONTROL -------------------------====== Play_Now ========
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        // ---- when story is clicked on
        // 
        public void Play_Now() // --- NOTE: index of 1st sub is 2 -- but -- JOrder is 1
        {
           // print("now");
            

            playNow = definedButton; // what is to be played
            PlayNow_Vars(); // what are it's vars
            print("--- PLAY NOW --- NOW INDEX -- > " + playNow.transform.GetSiblingIndex());

            BranchPar = definedButton.transform.parent.gameObject; // what branch is this in
            Branch_index = BranchPar.transform.GetSiblingIndex(); // what is the index of this branch

            print("--- PLAY NOW --- Branch -- jOrder -- JName -------------------------- > " + Branch_index + " / " + JOrder + " / " + JName);
            print("--- PLAY NOW ----------------------- v_ON -------------------------- > " + v_ON);
            print("--- PLAY NOW ----------------------- a_OVER -------------------------- > " + a_OVER);
            print("--- PLAY NOW ----------------------- a_AUDIO -------------------------- > " + a_AUDIOFILE);



            if (v_ON == true) // if video active is ture
            {
                //0 -- setup visiblesdchg


                //v - to use
                /// playNowScreen.raycastTarget = true;
                /// playNow.GetComponent<CanvasGroup>().interactable = true;
                /// playNow.GetComponent<CanvasGroup>().alpha = 1;

                //v - to do
                ///0 -- setup visibles
                ///
                /// 
                ///1 -- what video ?  / find video / fade out Image / fade up video / play
                ///2 -- vol ?         / set vol
                ///

                ///3 -- if(a_ON == true)   / set vol
                ///4 -- if(a_OVER == true) / find audio / fade up audio / play
                ///
                ///5 -- if(v_HOLD == true) / pause at end
                ///6 -- if(a_after == true) / find audio / fade up audio / play
                ///7 -- on CLICK -- / fade video to black / fade out audio // --> Play_Next();
                

                Video_ImageSetUp_ToPlay_01(); // turn on objects

                setMedia = playNow.GetComponent<SetMedia>(); // get direction to script from SetMedia
                //setMedia.PlayMedia(JName, v_HOLD, v_VOL);  // -- send to Play media script

                Video_ImageSetUp_ToPlay_02(); // make it interactive
            }



            print("--- PLAY NOW ----------------------- i_ON -------------------------- > " + i_ON);


            if ((i_ON == true) && (v_ON == false)) // if image active is true && video active is false
            {

                ///1 -- what image ? / find new / fade out Image / fade up video / play
                ///2 -- if(i_IMAGEFILE == ImageNow)  / do nothing
                ///3 -- else / find new / fade out Image / fade up video / play
                ///
                ///4 -- if(a_ON == true)   / set vol
                ///5 -- if(a_OVER == true) / find audio / fade up audio / play
                ///
                ///6 -- if(i_HOLD_TIME == 0) do nothing
                ///7 -- else / wait for onClick / wait for i_HOLD_TIME / 
                ///8 -- on CLICK -- / fade still to black / fade out audio // Play_Next();
                ///

                Video_ImageSetUp_ToPlay_01(); // turn on objects

                // ------------Note: Edit mode only sets the first image to play... run mode needs to determain the name of sub story for image
              //  setMedia = playNow.GetComponent<SetMedia>(); // get direction to script from SetMedia 
               // if (i_IMAGEFILE != "default")
                    //setMedia.PlayImage(i_IMAGEFILE); // -- send to PlayImage script
               // else
                    //setMedia.PlayImage(JName); // -- send to PlayImage script


                Video_ImageSetUp_ToPlay_02(); // make it interactive

            }


            if (a_ON == true)
            {
                if (a_OVER == true)
                {
                    print("--- PLAY NOW ----------------------- a_OVER -------------------------- > " + a_OVER);
                    print("--- PLAY NOW ----------------------- a_AUDIO -------------------------- > " + a_AUDIOFILE);

                    print("--- PLAY NOW ----------------------- a_AUDIO -------------------------- > " + playNowAudio);
                    print("--- PLAY NOW ----------------------- a_VOL -------------------------- > " + a_VOL);

                  //  setMedia.PlayAudio2(a_AUDIOFILE, a_VOL);

                }
            }


            // what needs to play

        } // ----------- end


        // ----------------- CAM CONTROL -------------------------====== Video_ImageSetUp_ToPlay_01 / Video_ImageSetUp_ToPlay_02 ========
        // -------------------------------------------------------======================  new  ==========================================
        // -------------------------------------------------------=======================================================================

        private void Video_ImageSetUp_ToPlay_01() // turn on objects
        {
            playNow.GetComponent<CanvasGroup>().alpha = 0;
            playNow.SetActive(true);
            playNow.GetComponent<CanvasGroup>().alpha = 1;
        }
        // ---------------------------------------------------------===========================================  new  ===================
        private void Video_ImageSetUp_ToPlay_02() // make object interactive
        {
            RawImage playNowScreen = playNow.transform.GetComponent<RawImage>(); // get screen of PlayNow
            playNowScreen.raycastTarget = true; // make it interactive

        } // ----------- end


        public GameObject playNext;
        private int Count;
        private int BranchCount;
        // ------------------------------------- CAM CONTROL -------------------------====== Play_Next =======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        /// ---- when story has finished
        /// ---- when "forward" is hit
        ///

        public void Play_Next() // --- NOTE: index of 1st sub is 2 -- but -- JOrder is 1
        {

           // print(definedButton);

            if (definedButton == Canvas) // --- if nothing has been selected yet
            {
                GameObject definedButton_Branch = TheContent.transform.GetChild(1).gameObject; // set to 1s 
                definedButton = definedButton_Branch.transform.GetChild(2).gameObject; // define what will be next to play and make it playnow
                Play_Now(); // definedButton has been defined -- go play now
                Main_Menu = 0; // zoom in
                return; // -- leave now - don't come back
            }

            // VVV-- something is selected --VVV

            Count = playNow.transform.parent.childCount; // how many children in branch
            BranchCount = playNow.transform.parent.parent.childCount; // how many branches

            //print("--- PLAY NEXT --- Branch -- BranchCount -- Count -- jOrder -- JName ----- > " + BranchCount + " / " + + Branch_index + " / " + Count + " / " + JOrder + " / " + JName);

            if (Count > JOrder + 2) // we are NOT at the last story on the branch
            {
                playNext = playNow.transform.parent.GetChild(playNow.transform.GetSiblingIndex() + 1).gameObject; // get playNext object
                playNow.GetComponent<CanvasGroup>().alpha = 0;  // ---- turn down playNow
                playNow.SetActive(false);                       // ---- turn off playNow
                definedButton = playNext; // set it to define the new playnow
                Play_Now(); // go play now
            }
            else // we ARE at the last story on the branch
            {
                if(BranchCount > Branch_index + 1) // we are NOT at at the last Branch
                {
                    // gets the 1st Story on the Next Branch
                    playNext = playNow.transform.parent.parent.GetChild(playNow.transform.parent.GetSiblingIndex() + 1).gameObject.transform.GetChild(2).gameObject;
                    setMedia = playNow.GetComponent<SetMedia>(); // get script from setMedia
                    setMedia.VideoStop(); // run script to pause video
                    setMedia.AudioStop(); // run script to pause audio 

                    ResetBranch(); // reset branch

                    definedButton = playNext;
                    Play_Now();
                }
                else 
                /// we are at the end of the branch
                /// -- turn this video off
                /// -- set this branch back to 1s
                /// -- 
                {
                    setMedia = playNow.GetComponent<SetMedia>();
                    setMedia.VideoStop(); // run script to pause video ??
                    setMedia.AudioStop(); // run script to pause audio ??

                    ResetBranch(); // reset branch

                    definedButton = Canvas;                    
                    Main_Menu = 1;
                }
                
            }
           
        } // ----------- end

        private GameObject thisSub; //  vars
        private RawImage thisSubScreen;
        // ------------------------------------- CAM CONTROL -------------------------====== ResetBranch =======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        public void ResetBranch() // --- NOTE: index of 1st sub is 2 -- but -- JOrder is 1
        {
            print("---------------- ResetBranch ------==----- > ");

            for (int x = 2; x < Count; x++)  // Count is - how many children in branch
            {
                thisSub = playNow.transform.parent.GetChild(x).gameObject;
                RawImage thisSubScreen = thisSub.transform.GetComponent<RawImage>();

                if (x == 2)
                {
                    thisSub.SetActive(true);
                    thisSubScreen.raycastTarget = true;

                    // reset image

                    ResetImageVars();

                    print("--- ResetBranch -------- JName --------- > " + JName );
                    print("--- ResetBranch -------- JOrder --------- > " + JOrder);
                    print("--- ResetBranch -------- v_IMAGEFILE --------- > " + v_IMAGEFILE);
                    print("--- ResetBranch -------- v_IMAGEFILE --------- > " + i_IMAGEFILE);

                    if (v_ON == true)
                    {
                        if (v_IMAGEFILE != "default'")
                        {
                           // thisSub.GetComponent<SetMedia>().SetImage(v_IMAGEFILE);
                            //thisSub.SetActive(true);
                            //thisSubScreen.raycastTarget = true;
                            thisSub.GetComponent<CanvasGroup>().alpha = 1;
                        }
                        else
                        {
                           // thisSub.GetComponent<SetMedia>().SetImage(JName);
                            thisSub.GetComponent<CanvasGroup>().alpha = 1;
                        }
                    }
                    else // it's an image
                    {
                       // thisSub.GetComponent<SetMedia>().SetImage(i_IMAGEFILE);
                        thisSub.GetComponent<CanvasGroup>().alpha = 1;
                    }

                }
                else
                {
                    thisSub.SetActive(false);
                    thisSubScreen.raycastTarget = false;
                }
            }

        }// ----------- end

        public void ResetImage()
        {

            if (v_ON == true)
            {
               // if (v_IMAGEFILE != "default'")
                  //  thisSub.GetComponent<SetMedia>().SetImage(v_IMAGEFILE);
               // else
                  //  thisSub.GetComponent<SetMedia>().SetImage(JName);
            }
           // else // it's an image
              //  thisSub.GetComponent<SetMedia>().SetImage(i_IMAGEFILE);

        }


        public void ResetImageVars()
        {
            //print(" --- ResetImageVars --- obj name ---- index --> " + playNow.transform.name + " index " + playNow.transform.GetSiblingIndex());

            GameObject SubObject = thisSub.transform.gameObject;

            GameObject superPowers = SubObject.transform.GetChild(5).gameObject;
            GameObject rec_t = superPowers.transform.GetChild(0).gameObject;
            GameObject mask = rec_t.transform.GetChild(0).gameObject;
            GameObject content = mask.transform.GetChild(0).gameObject;

            JName = content.transform.GetChild(0).GetComponentInChildren<Text>().text;
            JOrder = int.Parse(content.transform.GetChild(1).GetComponentInChildren<Text>().text);

            v_ON = content.transform.GetChild(2).GetComponentInChildren<Toggle>().isOn;
            v_CLOSE = content.transform.GetChild(3).GetComponentInChildren<Toggle>().isOn;
            v_HOLD = content.transform.GetChild(4).GetComponentInChildren<Toggle>().isOn;
            v_LOOP = content.transform.GetChild(5).GetComponentInChildren<Toggle>().isOn;
            v_VOL = float.Parse(content.transform.GetChild(20).GetComponentInChildren<InputField>().text);

            i_ON = content.transform.GetChild(6).GetComponentInChildren<Toggle>().isOn;
            i_HOLD = content.transform.GetChild(7).GetComponentInChildren<Toggle>().isOn;
            i_HOLD_TIME = float.Parse(content.transform.GetChild(19).GetComponentInChildren<InputField>().text);

            a_ON = content.transform.GetChild(8).GetComponentInChildren<Toggle>().isOn;
            a_OVER = content.transform.GetChild(9).GetComponentInChildren<Toggle>().isOn;
            a_AFTER = content.transform.GetChild(10).GetComponentInChildren<Toggle>().isOn;
            //content.transform.GetChild(11).GetComponentInChildren<Toggle>().isOn = homeTree.branch[count].subLeaf[x].a_LOOP; // <--> LATER

            v_IMAGEFILE = content.transform.GetChild(12).GetComponentInChildren<Text>().text;
            //================= content.transform.GetChild(13).GetComponentInChildren<Text>().text = homeTree.branch[count].subLeaf[x].JName;
            i_IMAGEFILE = content.transform.GetChild(14).GetComponentInChildren<Text>().text;
            a_AUDIOFILE = content.transform.GetChild(15).GetComponentInChildren<Text>().text;
            a_VOL = float.Parse(content.transform.GetChild(16).GetComponentInChildren<Text>().text); //int MedNum = int.Parse(Media_Num);

            subCount = int.Parse(content.transform.GetChild(17).GetComponentInChildren<Text>().text); //  subCount.ToString();

            if (2 + 2 == subRunDebugOff)
            {
                print("---- ResetImageVars ---- ResetImage variable list ###########################-> " + "\n" +
                "JOrder --> " + JOrder + "        / " +
                "JName --> " + JName + "\n" +
                "v_imageFile    --> " + v_IMAGEFILE + "\n" +
                "i_imageFile    --> " + i_IMAGEFILE + "\n" 
                );
            }

        }


        public GameObject playLast;
        // ------------------------------------- CAM CONTROL -------------------------====== Play_Last =======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        /// ---- when "back " is hit
        ///

        public void Play_Last() // --- NOTE: index of 1st sub is 2 -- but -- JOrder is 1
        {
            Count = playNow.transform.parent.childCount;
            BranchCount = playNow.transform.parent.parent.childCount; // -- NOTE:   BranchCount is 1 + number of branches ( first is 0 and inactive ) 

            if (JOrder > 1)
            {
                playLast = playNow.transform.parent.GetChild(playNow.transform.GetSiblingIndex() - 1).gameObject;

                definedButton = playLast;

                playNow.GetComponent<CanvasGroup>().alpha = 0;  // ---- turn down playNow
                playNow.SetActive(false);                       // ---- turn off playNow

                Play_Now();
            }
            else
            {
                if (Branch_index > 1)
                {
                    print("last branch");

                    GameObject LastBranch = playNow.transform.parent.parent.GetChild(playNow.transform.parent.GetSiblingIndex() - 1).gameObject;
                    playLast = LastBranch.transform.GetChild(LastBranch.transform.childCount -1).gameObject;

                    print("--- PLAY Last --- last Branch index + last sub index --  " + LastBranch.transform.GetSiblingIndex() + " / " + playLast.transform.GetSiblingIndex());
                    setMedia = playNow.GetComponent<SetMedia>();
                    setMedia.VideoPause(); // run script to pause video
                    setMedia.AudioPause(); // run script to pause audio 

                    ResetBranch();

                    definedButton = playLast;
                    Play_Now();


                }
                else
                {
                    definedButton = Canvas;
                    Main_Menu = 1; // go to main menu
                    setMedia = playNow.GetComponent<SetMedia>();
                    setMedia.VideoPause(); // run script to pause video
                    setMedia.AudioPause(); // run script to pause audio 

                    ResetBranch();

                }
                
            }

        } // ----------- end

          //--- SUB ---
        public string JName;
        public int JOrder;
        public bool v_ON;
        public bool v_CLOSE;
        public bool v_HOLD;
        public bool v_LOOP;
        public float v_VOL;

        public bool i_ON;
        public bool i_HOLD;
        public float i_HOLD_TIME;

        public bool a_ON;
        public bool a_OVER;
        public bool a_AFTER;
        public bool a_LOOP;

        public string v_IMAGEFILE;
        public string i_IMAGEFILE;
        public string a_AUDIOFILE;
        public float a_VOL;

        public int subCount;
        public int subRunDebugOff;


        public void PlayNow_Vars()
        {
            print(" --- SUB & NEXT --- obj name ---- index --> " + playNow.transform.name + " index " + playNow.transform.GetSiblingIndex());

            GameObject SubObject = playNow.transform.gameObject;
            
            GameObject superPowers = SubObject.transform.GetChild(5).gameObject;
            GameObject rec_t = superPowers.transform.GetChild(0).gameObject;
            GameObject mask = rec_t.transform.GetChild(0).gameObject;
            GameObject content = mask.transform.GetChild(0).gameObject;

            JName = content.transform.GetChild(0).GetComponentInChildren<Text>().text;
            JOrder = int.Parse(content.transform.GetChild(1).GetComponentInChildren<Text>().text);

            v_ON = content.transform.GetChild(2).GetComponentInChildren<Toggle>().isOn;
            v_CLOSE = content.transform.GetChild(3).GetComponentInChildren<Toggle>().isOn;
            v_HOLD = content.transform.GetChild(4).GetComponentInChildren<Toggle>().isOn;
            v_LOOP = content.transform.GetChild(5).GetComponentInChildren<Toggle>().isOn;
            v_VOL = float.Parse(content.transform.GetChild(20).GetComponentInChildren<InputField>().text);

            i_ON = content.transform.GetChild(6).GetComponentInChildren<Toggle>().isOn;
            i_HOLD = content.transform.GetChild(7).GetComponentInChildren<Toggle>().isOn;
            i_HOLD_TIME = float.Parse(content.transform.GetChild(19).GetComponentInChildren<InputField>().text);

            a_ON = content.transform.GetChild(8).GetComponentInChildren<Toggle>().isOn;
            a_OVER = content.transform.GetChild(9).GetComponentInChildren<Toggle>().isOn;
            a_AFTER = content.transform.GetChild(10).GetComponentInChildren<Toggle>().isOn;
            //content.transform.GetChild(11).GetComponentInChildren<Toggle>().isOn = homeTree.branch[count].subLeaf[x].a_LOOP; // <--> LATER

            v_IMAGEFILE = content.transform.GetChild(12).GetComponentInChildren<Text>().text;
            //================= content.transform.GetChild(13).GetComponentInChildren<Text>().text = homeTree.branch[count].subLeaf[x].JName;
            i_IMAGEFILE = content.transform.GetChild(14).GetComponentInChildren<Text>().text;
            a_AUDIOFILE = content.transform.GetChild(15).GetComponentInChildren<Text>().text;
            a_VOL = float.Parse(content.transform.GetChild(16).GetComponentInChildren<Text>().text); //int MedNum = int.Parse(Media_Num);

            subCount = int.Parse(content.transform.GetChild(17).GetComponentInChildren<Text>().text); //  subCount.ToString();

            if (2 + 2 == subRunDebugOff)
            {
                print("---- SUB & NEXT ---- NOW variable list ###########################-> " + "\n" +
                "JOrder --> " + JOrder + "        / " +
                "JName --> " + JName + "\n" +

                "v_ON           --> " + v_ON + "\n" +
                "v_close        --> " + v_CLOSE + "\n" +
                "v_hold         --> " + v_HOLD + "\n" +
                "v_loop         --> " + v_LOOP + "\n" +
                "v_vol         --> " + v_VOL + "\n" +
                "v_imageFile    --> " + v_IMAGEFILE + "\n" +

                "i_on           --> " + i_ON + "\n" +
                "i_hold         --> " + i_HOLD + "\n" +
                "i_hold_time    --> " + i_HOLD_TIME + "\n" +
                "i_imageFile    --> " + i_IMAGEFILE + "\n" +

                "a_on           --> " + a_ON + "\n" +
                "a_over         --> " + a_OVER + "\n" +
                "a_after        --> " + a_AFTER + "\n" +
                "a_AudioFile    --> " + a_AUDIOFILE + "\n" +
                "a_Vol          --> " + a_VOL + "\n" +
                "subCount       --> " + subCount + " \n "
                );
            }

        }


      




        private GameObject theObject; // - var
        private GameObject NowNextObject;

        // ------------------------------------- CAM CONTROL -------------------------====== JUMP AHEAD ======
        // ---------------------------------------------------------------------------========================
        // ---------------------------------------------------------------------------========================

        public void JumpAhead()
        {
            print("-- AHEAD --- order -------------------------------++ " + theJOrder);

            if (1 + 1 == 2)
            {

                NowNextObject = theObject.transform.parent.GetChild(theJOrder + 2).gameObject; // <-- the NEXT gameobject
                print("-- AHEAD --- index ------------> " + NowNextObject.transform.GetSiblingIndex());
                setMedia.Reset_VideoCtrl.text = "off";
                setMedia.videoCtrl = 1;
                theObject.SetActive(false);
            }
            // NOTE NOTE::  NEED TO TURN OFF THE ONE PLAYING...

            // next media up
            if (NowNextObject != null)                                                                                                     //
            {
                //print("------------------------------------------------  auto jump to next ");                                        //
                RawImage NextScreen = NowNextObject.transform.GetComponent<RawImage>();    // <-- Get RawImage of NextObject (NextScreen)  //
                NextScreen.raycastTarget = true;                                        // <-- turn on it's raycastTarget               //
                NowNextObject.GetComponent<CanvasGroup>().interactable = true;             // <-- turn on interaction of NextObject        //
                NowNextObject.GetComponent<CanvasGroup>().alpha = 1;                       // <-- turn on alpha of NextObject              //
                Button nextSubClick = NowNextObject.transform.GetComponent<Button>();      // <-- Get NextObject Button      
                nextSubClick.onClick.Invoke();                                          // <-- and click it   
                
                
                setMedia.Reset_VideoCtrl.text = "off";
                setMedia.videoCtrl = 0;

                theObject.GetComponent<CanvasGroup>().interactable = false;
                theObject.GetComponent<CanvasGroup>().alpha = 0;
                RawImage ThisObject = theObject.transform.GetComponent<RawImage>();
                ThisObject.raycastTarget = false;
                //
                return; // <-- done, get out                                                                                            //
            }



        }
        // public ObjControl that;
        // ------------------------------------- CAM CONTROL -------------------------====== JUMP BACK =======
        // ---------------------------------------------------------------------------======================== old
        // ---------------------------------------------------------------------------========================

        public Text back_forth; // <--- var

        public void JumpBack()
        {

            print("-- BACK --- order ---------------------------++ " + theJOrder);

            if (1 + 1 == 2)
            {

                NowNextObject = theObject.transform.parent.GetChild(theJOrder + 0).gameObject; // <-- the NEXT gameobject
                NowNextObject.SetActive(true);
                print("-- BACK --- index -------------> " + NowNextObject.transform.GetSiblingIndex());
                //theObject.SetActive(false);
                RawImage OneForwardScreen = theObject.transform.GetComponent<RawImage>();
                OneForwardScreen.raycastTarget = false;
                OneForwardScreen.GetComponent<CanvasGroup>().interactable = false;
                OneForwardScreen.GetComponent<CanvasGroup>().alpha = 0;

            }
            // NOTE NOTE::  NEED TO TURN OFF THE ONE PLAYING...

            // next media up
            if (NowNextObject != null)                                                                                                     //
            {
                //print("------------------------------------------------  auto jump to next ");                                        //
                RawImage NextScreen = NowNextObject.transform.GetComponent<RawImage>();    // <-- Get RawImage of NextObject (NextScreen)  //
                NextScreen.raycastTarget = true;                                        // <-- turn on it's raycastTarget               //
                NowNextObject.GetComponent<CanvasGroup>().interactable = true;             // <-- turn on interaction of NextObject        //
                NowNextObject.GetComponent<CanvasGroup>().alpha = 1;                       // <-- turn on alpha of NextObject              //
                Button nextSubClick = NowNextObject.transform.GetComponent<Button>();      // <-- Get NextObject Button      
                                                                                           //setMedia.goBack = playingPaused;
                back_forth.text = "1"; // text object as variable to pass over

                nextSubClick.onClick.Invoke();                                          // <-- and click it                             //


                theObject.GetComponent<CanvasGroup>().interactable = false;
                theObject.GetComponent<CanvasGroup>().alpha = 0;

                //
                return; // <-- done, get out                                                                                            //
            }
            else
            {
                print("-- message -------------> no object");
            }


        }

        private string dir;
        private string dataPath;
        private string mPath;


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

    /// it's possible that the sending of the vars from here to UMP did work, 
    /// but that many files were opening at once




}

