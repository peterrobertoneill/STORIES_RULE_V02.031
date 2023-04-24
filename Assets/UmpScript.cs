using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;




namespace UMP
{
    public class UmpScript : MonoBehaviour
    {

        public UniversalMediaPlayer _mediaPlayer = null;
        //public StreamVideo streamVideo;
        //public ObjControl objControl;
        public RawImage ButtonImage;
        public RawImage video_image_audio;
        
        public Text title_name;
        public string MediaName;

        public GameObject PlayBtn;
        public GameObject PauseBtn;
        public GameObject[] VideoOutputObjects;




        //========================================================================
        //                                UMP
        //========================================================================
        public void MediaNumberBtn(string MediaNameIs)
        {
            title_name.text = MediaNameIs;
            PlayUmp_01();

        }

        public void CloseVideo() // if video is not playing then alpha 0 it
        {
            if (_mediaPlayer.IsPlaying)
                return;
            else
            {
                Color32 color = new Color32(255, 255, 255, 0);
                video_image_audio.color = color;
            }

        }

        public void ButtonImageOne(string mPathFButton)
        {
            //string mPathF = mPath + title_name.text + ".mp4";
           // print("    video path-===============-->" + mPathFButton);

            _mediaPlayer.Path = mPathFButton;
            _mediaPlayer.Play();

        }


        public void PlayUmp_01()
        {

            MPath();

            string mPathF = mPath + title_name.text + ".mp4";
           // print("    video path-===============-->" + mPathF);

            if (File.Exists(mPathF))
            {
               // Vector3.Lerp(camLocation, definedButton.transform.position + offset, camSpeed * Time.deltaTime);
                

                _mediaPlayer.Path = mPathF;

                _mediaPlayer.Play();

                Color32 color = new Color32(255, 255, 255, 255); // change color to white ??
                video_image_audio.color = color;

                long length = _mediaPlayer.Length;
              //  print(length);

              //  print("I'm trying.");

                PlayBtn.SetActive(false);
               // print(_mediaPlayer.Position);

               // print(_mediaPlayer.GetFormattedLength(true));



            }
            

        }



        public void JumpToFront()
        {
            _mediaPlayer.Position = .00f;
            _mediaPlayer.Pause();
            PlayBtn.SetActive(true);

            //streamVideo.NewNamedObj();
            //streamVideo.GoBackToImage();


        }
        public void JumpToEnd()
        {
            _mediaPlayer.Position = .99f;
            _mediaPlayer.Play();
           // print("jump to end");
            PlayBtn.SetActive(true);
            Invoke("Pause", 0.2f);

        }

        public void PauseUmp_01()
        {
            print(_mediaPlayer.Position);
            _mediaPlayer.Pause();
           // print("pause");
            PlayBtn.SetActive(true);

            //_mediaPlayer.
        }

        public void FastBack()
        {
            print(_mediaPlayer.Position);
            print(_mediaPlayer.Time);
            if (_mediaPlayer.Position > .05)
            {
                _mediaPlayer.Position -= 0.1f;
            }
            _mediaPlayer.Play();
            PlayBtn.SetActive(false);

           // print("fast back");
        }

        public void FastAhead()
        {
            print(_mediaPlayer.Position);
            print(_mediaPlayer.Time);
            if (_mediaPlayer.Position < .9)
            {
                _mediaPlayer.Position += 0.1f;
            }
            _mediaPlayer.Play();
            PlayBtn.SetActive(false);
           // print("fast ahead");
        }



        public void OnPosValueChanged(float value)
        {
            // Debug.Log("New Value " + value/10);
            //pos_num.text = (value).ToString();
            // playButton = 
            //videoPlayer.SetDirectAudioVolume(0, value / 100);

            _mediaPlayer.Position = value;

            // print(_mediaPlayer.Volume);
        }


        public Slider sliderInstance;
        public Text vol;
        public Text v_vol_text;


        void Start()
        {
            //videoPlayer = gameObject.GetComponent<VideoPlayer>();

            sliderInstance.minValue = 0;
            sliderInstance.maxValue = 110;
            sliderInstance.wholeNumbers = true;
            sliderInstance.value = 80;

        }

        public void OnValueChanged(float value)
        {
            // Debug.Log("New Value " + value/10);
            vol.text = (value / 10).ToString();
            v_vol_text.text = (value / 10).ToString();
            // playButton = 
            //videoPlayer.SetDirectAudioVolume(0, value / 100);

            _mediaPlayer.Volume = value / 1;

           // print(_mediaPlayer.Volume);
        }

        //========================================================================









        //----------------------------- Path to Flowmedia
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
}

