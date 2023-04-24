using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.IO;


//namespace UMP
//{
    public class StreamVideo : MonoBehaviour
    {
        //public MediaPath mediaPath;
        //--------------------------on OBJ-----------------

        

        public RawImage rawImage;
        public VideoPlayer videoPlayer;
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
    public Toggle object_updated;

        public string VideoImageName = "default.jpg";

        //--------------------------on OBJ-----------------


        void Start()  // add image
        {
            setDefaultImage();
        }








    public void PlayIt()
    {
        mPathF = "file://" + mPath;
        videoPlayer.url = mPathF + title_name.text + ".mp4";
        print("video url = " + videoPlayer.url);

        StartCoroutine(PlayVideo());
    }


    public void setDefaultImage()
    {
        MPath();

        if (videoPlayer.isPlaying) //--- check video playing
        {
            videoPlayer.Pause();
            playBtn.SetActive(true);
        }

        mPathF = "file:///" + mPath + "default.jpg";

        StartCoroutine(SetImage(mPathF));
    }


    //------------------prepare video -------------------
    public void GoBackToImage()
    {
       // print("-----------" + VideoImageName);
        MPath();
        // print("------------------------------>> " + mPath);

        if (VideoImageName != "")
        {
            mPathF = "file://" + mPath + VideoImageName;
           // print("Image path... VideoImageName " + VideoImageName);
        }
        else
        {
            mPathF = "file://" + mPath + title_name.text + ".jpg";
           // print("Image path... title_name " + title_name.text);

        }

      //  print("Image path... GoBackToImage() " + mPathF);

        SetFlowImg(mPathF);

    }

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


    //------------------set image 1 -------------------
    public IEnumerator SetImage(string url) //url is the texture sent by void start "plus.jpg"
    {

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

        rawImage.texture = www.texture;
        www.Dispose();
        www = null;

    }

    //------------------set image 2 -------------------
    public void SetFlowImg(string mPathF) // imgPathF is the texture sent by Data
    {
        if (videoPlayer.isPlaying) //--- check video playing
        {
            videoPlayer.Pause();
            playBtn.SetActive(true);
        }
        //print("Image path...  " + imgPathF);

        StartCoroutine(SetImage(mPathF)); ///WWW URL(imgPathF) imports texture

        //print(imgPathF);
    }

    //=================================================================================
    //----------------- setUP NAME - ORDER -- NOTE: CHANGE HOW ORDER WORKS -------------



    public void SetFlowName(string obName)
    {
        title_name.text = obName;
    }

    public void SetFlowOrder(string obOrder)
    {
        flowOrder.text = obOrder;
    }

    public void SetObjectUpdate()
    {
        object_updated.isOn = true;
    }


    public void NewNamedObj()
    {

        title_name.text = newNameInput.text;
        string sName = newNameInput.text;

        if (newNameInput.text == "")
        {
            sName = "default";
        }

        MPath();
        mPathF = "file://" + mPath + sName + ".jpg";
        //print("Media path name  - NewNameObj() -- " + mPathF);

        //theName.text = sName;
        SetFlowImg(mPathF);

    }

    //------------------Naming OBJ ---------------------
    public void SetMedia()
    {
        MPath();
        print("------------------------------>> " + mPath);

        mPathF = "file://" + mPath;
        print("path ---   " + mPathF);

        videoPlayer.url = mPathF + title_name.text + ".mp4";
        print("video url = " + videoPlayer.url);
        StartCoroutine(PlayVideo());

    }

    public void SetImageFirst(string sName)
    {

        MPath();

        if (VideoImageName == null)
        {
            mPathF = "file://" + mPath + title_name.text + ".jpg";
        }
        else
        {
            mPathF = "file://" + mPath + VideoImageName;
        }
        print("Image path... SetImageFirst() " + imgPathF);

        SetFlowImg(mPathF);
    }

    //=================================================================================


    //------------------play video -------------------

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
    }


    public void SavedNamedObj(string sName)
    {
       // title_name.text = sName;
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
//}


