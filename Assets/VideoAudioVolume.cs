using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace UMP
{
    public class VideoAudioVolume : MonoBehaviour
    {
        public UniversalMediaPlayer _mediaPlayer = null;
        public RawImage rawImage;

        public Slider sliderInstance;
        public Slider sliderPosition;
        public Text VideoVol;
        public Text set_VideoVol;
        public Text Video_Pos_num;

        public string mPath = "";

        public InputField VideoName;



        public void PlayVideoSettings()
        {
            MPath();
            string mPathF = mPath + VideoName.text; // TO DO <--> compare to determine file type

            _mediaPlayer.Path = mPathF;

            _mediaPlayer.Play();


        }


        void Start()
        {
            //videoPlayer = gameObject.GetComponent<VideoPlayer>();

            sliderInstance.minValue = 0;
            sliderInstance.maxValue = 110;
            sliderInstance.wholeNumbers = true;
            sliderInstance.value = 80;

            sliderPosition.minValue = 0f;
            sliderPosition.maxValue = 1f;
            sliderPosition.value = 0f;

        }

        public void OnValueChanged(float value)
        {
            // Debug.Log("New Value " + value/10);
            VideoVol.text = (value / 10).ToString();
            // playButton = 
            //videoPlayer.SetDirectAudioVolume(0, value / 100);

            _mediaPlayer.Volume = value / 1;

            // print(_mediaPlayer.Volume);
        }

        public void Set_VideoVol()
        {
            set_VideoVol.text = VideoVol.text;

        }

        public void OnPosValueChanged(float value)
        {
            // Debug.Log("New Value " + value/10);
            Video_Pos_num.text = (value).ToString();
            // playButton = 
            //videoPlayer.SetDirectAudioVolume(0, value / 100);

            _mediaPlayer.Position = value;

            // print(_mediaPlayer.Volume);
        }




        //----------------------------- Path to Flowmedia
        public string dir;
        public string dataPath;
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

