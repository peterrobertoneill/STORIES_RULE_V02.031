using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;




namespace UMP
{
    public class TstInput : MonoBehaviour
    {
        [SerializeField]
        private UniversalMediaPlayer _mediaPlayer = null;
        public string dir;
        public string dataPathF;
        public string dataPath;
        public string mPathF;
        public string mPath; //set from MediaPath
        public RawImage rawImage;
        public string NameIt;
        public InputField NameItField;
        public Text message;
        public Text message2;
        public GameObject playButton;
        public GameObject pauseButton;


        // Start is called before the first frame update
        void Start()
        {
            pauseButton.SetActive(false);
            playButton.SetActive(false);

            message.text = "type the word one into the input field below - press enter button";
        }

        // Update is called once per frame
        void Update()
        {


        }

        public void UpdateName()
        {
            NameIt = NameItField.text;
            SetImage();
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }


        public void SetImage()
        {

            MPath();
            mPathF = "file://" + mPath + NameIt + ".jpg";
            print("--- SET IMAGE ----- path -------> Media path -- " + mPathF);

            StartCoroutine(SetImage2(mPathF));

        }

        public IEnumerator SetImage2(string mPathF)
        {
            WWW www = new WWW(mPathF);
            yield return www;

            //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

            rawImage.texture = www.texture;
            www.Dispose();
            www = null;
            message2.text = "Now click on the play button";

        }



        public void PlayIt()
        {
            MPath();
            _mediaPlayer.Path = mPath + NameIt + ".mp4";
            _mediaPlayer.Play();
            pauseButton.SetActive(true);


        }

        public void PauseIt()
        {
            _mediaPlayer.Pause();
        }



        public void MPath() //---------------- path to movies
        {
            dir = Application.dataPath;
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName;

            dataPath = dir + "/flowmedia/";
            dataPath = dataPath.Replace('\\', '/');
            //Debug.Log("path = " + dataPath);

            mPath = dataPath;
            print(mPath);

            //makeTestList.dataPath2 = dataPath;
            //instTestList.dataPath3 = dataPath;
            //objListControl.dataPath4 = dataPath;


        }

    }

}

