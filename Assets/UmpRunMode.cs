using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace UMP
{
    public class UmpRunMode : MonoBehaviour
    {
        public UniversalMediaPlayer _mediaPlayer = null;
        //public StreamVideo streamVideo;
        //public ObjControl objControl;
        public RawImage rawImage;
        // public string mPath = "";
        public Text title_name;
        public string MediaName;
       // public GameObject PlayBtn;
        //public GameObject PauseBtn;
        public GameObject[] VideoOutputObjects;








        public void PlayUmp_01()
        {

            MPath();
            string mPathF = mPath + title_name.text + ".mp4";
            print("    video path-===============-->" + mPathF);

            _mediaPlayer.Path = mPathF;

            _mediaPlayer.Play();

            long length = _mediaPlayer.Length;
            print(length);

            print("I'm trying.");

           // PlayBtn.SetActive(false);
            print(_mediaPlayer.Position);

            print(_mediaPlayer.GetFormattedLength(true));

        }









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
