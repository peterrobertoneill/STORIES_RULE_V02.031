using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using UMP.Services;
using UMP.Services.Youtube;
using UnityEngine.Networking;



namespace UMP
{
    public class VideoOn : MonoBehaviour
    {
        public RawImage rawImage;
        //public VideoPlayer videoPlayer;
        public string imgPathF;
        public GameObject playBtn;
        public GameObject pauseBtn;

        public string pop;
        public string dir;
        public string dataPathF;
        public string dataPath;
        public string mPathF;
        public string mPath; //set from MediaPath

        public string obName;
        public string obOrder;
        public Text title_name;
        public Text flowOrder;
        public InputField newNameInput;
        public int aNumber;



        public void PlayIt()
        {
            /*
            mPathF = "file://" + mPath;

            videoPlayer.url = mPathF + title_name.text + ".mp4";
            print("video url = " + videoPlayer.url);

            StartCoroutine(PlayVideo());
        }
        //file:///C:/Users/peter/Downloads/thsi/NESA.mp4
        //file:///C:/Users/peter/Downloads/thsi/c003.mp4
        /// <summary>
        /// KennaKong.mp4
        /// Entert.mp4
        /// 51946
        /// </summary>
        /// <returns></returns>

        IEnumerator PlayVideo()
        {

            videoPlayer.Prepare();
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            while (!videoPlayer.isPrepared)
            {
                yield return waitForSeconds;
                break;
            }
            RawTexture();
            //print(title_name.text);
        }

        void RawTexture()
        {
            rawImage.texture = videoPlayer.texture;
            videoPlayer.Play();
            playBtn.SetActive(false);

        }
        //------------------pause video -------------------
        public void PauseIt()
        {
            videoPlayer.Pause();
            playBtn.SetActive(true);
            */
        }




















        public void MPath() // path to movies
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


















