using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Video;
using UnityEngine.Events;

namespace UMP
{
    // ------------------------------------- SET MEDIA ---------------------------====== VARS ======
    // ---------------------------------------------------------------------------==================
    // ---------------------------------------------------------------------------==================

    public class SetMedia : MonoBehaviour //, IPlayerEndReachedListener
    {
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer = null;
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer_audio = null;
        public string dir;
        public string dataPathF;
        public string dataPath;
        public string mPathF;
        public string mPath; //set from MediaPath

        public RawImage rawImage;
        public GameObject definedButton2;
        public UnityEvent OnClick = new UnityEvent();
        public Camera theMainCamera;
        public VideoPlayer videoPlayer;

        //private WorldSpaceVideo worldSpaceVideo;
        //[SerializeField]
        private CamControl camControl;
        private BackAndForth backAndForth;
        public GameObject theCube;
        public int videoCtrl;
        private int spaceV; // spacebar pause or play
        public Text theName;
        public string storyName;
        public GameObject vidSlider;
        public Slider VidSlider;
        public long theTime;
        public long theLength;
        private float endPos;
        public bool Holding;  // ===================    HOLDING

        public int goBack;  //  --- var
        public int SomethingElse;

        public Text now_text; // for passing var to a global state
        public Text next_text;
        public Text Reset_VideoCtrl;
        public Text Reset_vid; // on the RAW

        //new v02.01
        public GameObject ContentContent;
        //public FlowJect flowJect;


        // ------------------------------------- SET MEDIA ---------------------------====== AWAKE / UPDATE ======
        // ---------------------------------------------------------------------------============================
        // ---------------------------------------------------------------------------============================

        private void Awake()
        {
            camControl = theMainCamera.GetComponent<CamControl>();
            //flowJect = TheContent.GetComponent<FlowJect>();
            videoCtrl = 0;  // if 1 then vp is playing
            spaceV = 0; // set up if var for keydown spacebar vp playing
            Holding = false;

        }

        void Update()
        {
            //BtnAction();
            //SetDirectAudioVolume(); //-- keydowns to control audio
                                    // if(camControl.Main_Menu == 0)
                                    //  {
                                    //      keyAction();
                                    // }


        }


        // ------------------------------------- SET MEDIA ---------------------------====== AUDIO CONTROLS =======
        // ---------------------------------------------------------------------------=============================
        // ---------------------------------------------------------------------------=============================

        public void SetDirectAudioVolume()  //audio controls
        {
            if (Input.GetKeyDown("1"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.05f);
                _mediaPlayer.Volume = 10;
                _mediaPlayer_audio.Volume = 10;
            }
            else if (Input.GetKeyDown("2"))
            {
                // videoPlayer.SetDirectAudioVolume(0, 0.1f);
                _mediaPlayer.Volume = 20;
                _mediaPlayer_audio.Volume = 20;
            }
            else if (Input.GetKeyDown("3"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.3f);
                _mediaPlayer.Volume = 30;
                _mediaPlayer_audio.Volume = 30;
            }
            else if (Input.GetKeyDown("4"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.4f);
                _mediaPlayer.Volume = 40;
                _mediaPlayer_audio.Volume = 40;
            }
            else if (Input.GetKeyDown("5"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.5f);
                _mediaPlayer.Volume = 50;
                _mediaPlayer_audio.Volume = 50;
            }
            else if (Input.GetKeyDown("6"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.6f);
                _mediaPlayer.Volume = 60;
                _mediaPlayer_audio.Volume = 60;
            }
            else if (Input.GetKeyDown("7"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.7f);
                _mediaPlayer.Volume = 70;
                _mediaPlayer_audio.Volume = 70;
            }
            else if (Input.GetKeyDown("8"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.8f);
                _mediaPlayer.Volume = 80;
                _mediaPlayer_audio.Volume = 80;
            }
            else if (Input.GetKeyDown("9"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 1.0f);
                _mediaPlayer.Volume = 90;
                _mediaPlayer_audio.Volume = 90;
            }
            else if (Input.GetKeyDown("0"))
            {
                //videoPlayer.SetDirectAudioVolume(0, 0.0f);
                _mediaPlayer.Volume = 100;
                _mediaPlayer_audio.Volume = 100;
            }
        }




        // ------------------------------------- SET MEDIA ---------------------------====== PlayIt_Button ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================

        public void PlayIt_Button()
        {
            //flowJect = ContentContent.GetComponent<FlowJect>();

            if (camControl.Main_Menu == 1)
            {
                definedButton2 = this.gameObject; //defined Button Pressed
                camControl.definedButton = definedButton2; //define Button Pressed in CamControl
                flowJect.SubLeafClicked = definedButton2;
                flowJect._GoClickedOn_Subleaf(); //subObject pressed
                camControl.Main_Menu = 0;
                flowJect.Content_Control();
                //flowJect._GoForward();
                //camControl.playingPaused = 1;
                //camControl.Play_Now();
            }
            else
            {
                //_mediaPlayer.Pause();
                //_mediaPlayer_audio.Pause();
                //Fade_Down_Audio_Cut

                camControl = theMainCamera.GetComponent<CamControl>();

                StartCoroutine(camControl.Go_Forward_Slowly());

                ///NOTE: trying to make the forward button work with the mouse... so 
                /// I disappled the below lines...
                //StartCoroutine(flowJect.Fade_Down_Audio_Cut());
                //flowJect.Stop_MediaPlayer_One();
                //camControl.Main_Menu = 1;
                //flowJect.Content_Import();



                return;
            }
        }


        public void SetUpEndPos()  //  <---- calculating the EndPos -----------
        {

            theTime = _mediaPlayer.Time;
            theLength = _mediaPlayer.Length;

            print("--- SETUP END POS ------ Length ----> " + theLength);

            long theB = 1000;
            int x = (int)theB;
            int i = (int)theLength;
            float subt = i - x;
            endPos = subt / i;

            print("--- SETUP END POS ------ num--------endPos ----> " + endPos);

        }


        public void EvokePause() // force images to stay in pause state
        {
            _mediaPlayer.Pause();
        }

        // ------------------------------------- SET MEDIA ---------------------------====== Pause Play videos ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        public void VideoPause()
        {
            _mediaPlayer.Pause();

            /*
            if (Video_Is_Playing == false)
            {
                VideoPlay();
            }
            else
            {
                _mediaPlayer.Pause();
                Video_Is_Playing = false;
            }
            */

        }

        public void AV_PlayPause(bool v_ON, bool a_ON)
        {
            if (v_ON == true)
            {
                if (_mediaPlayer.IsPlaying == true)
                {
                    _mediaPlayer.Pause();
                }
                else
                {
                    _mediaPlayer.Play();
                }
            }
            if (a_ON == true)
            {

                if (_mediaPlayer_audio.IsPlaying == true)
                {
                    _mediaPlayer_audio.Pause();
                }
                else
                {
                    _mediaPlayer_audio.Play();
                }
            }

        }

        public void VideoPlay()
        {
            _mediaPlayer.Play();
            //Video_Is_Playing = true;
        }

        public void HardVideoPause()
        {
            _mediaPlayer.Pause();
            //Video_Is_Playing = false;
        }

        // ------------------------------------- SET MEDIA ---------------------------====== Pause Play Audio ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        public void AudioPause()
        {

            _mediaPlayer_audio.Pause();
            /*
            if (Audio_Is_Playing == false)
            {
                AudioPlay();
            }
            else
            {
                _mediaPlayer_audio.Pause();
                Audio_Is_Playing = false;
            }
            */

        }

        public void AudioPlay()

        {

            _mediaPlayer_audio.Play();
            //Audio_Is_Playing = true;
        }

        public void HardAudioPause()
        {
            _mediaPlayer_audio.Pause();
            //Audio_Is_Playing = false;
        }


        // ------------------------------------- SET MEDIA ---------------------------====== Stop videos ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        public void VideoStop()
        {
            _mediaPlayer.Stop();
        }

        // ------------------------------------- SET MEDIA ---------------------------====== Stop audio ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================
        public void AudioStop()
        {
            _mediaPlayer_audio.Stop();
        }

        // ------------------------------------- SET MEDIA ---------------------------====== EndREached ======
        // ---------------------------------------------------------------------------===========================================  new  ===============
        // ---------------------------------------------------------------------------========================

        private float post = 0.1f;

        public void EndReached()
        {
            /*
            ///print("--- End Reached --- message --- entered -------------> ");
            ///print("--- End Reached --- _mediaPlayer.Position  -------------> " + _mediaPlayer.Position);
            ///print("--- End Reached --- endPos  -------------> " + endPos);
            ///print("--- End Reached --- v_HOLD  -------------> " + v_HOLD);

            if ((_mediaPlayer.Position > post) && (_mediaPlayer.Position > endPos) && (v_HOLD_p == true))
            {
                print("--- End Reached --- message --- paused -------------> ");
                _mediaPlayer.Pause();

                Holding = true; // the video is in hold mode
               // v_HOLD = false; // done holding. set hold to false

            }
            */

        }



        public FlowJect flowJect;
        public SubMediaPowers subMediaPowers;




    }



}


