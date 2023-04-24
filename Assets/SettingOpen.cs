using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingOpen : MonoBehaviour
{

    public ObjControl objControl;
    public string mPath;

    public GameObject vSetting;
    public GameObject iSetting;
    public GameObject aSetting;

    public GameObject v_Btn;
    public GameObject i_Btn;
    public GameObject a_Btn;

    //video <------------------------------ vars
    public InputField Input_VideoImageName;
    public RawImage VideoImagePlane;
    public InputField Input_VideoImageName_END;
    public RawImage VideoImagePlane_END;
    public string VideoImageName;
    public StreamVideo streamVideo;

    //image <------------------------------  VARS
    public InputField Input_ImageName;
    public RawImage ImagePlane;
    public string ImageName;
   

    //audio <----------------------------- Audio
    public InputField Input_AudioName;
    //public Toggle a_mp3;
    //public Toggle a_aif;
    //public Toggle a_wav;
    //public string audioType;
    Color32 ColYellow = new Color32(255, 174, 0, 255);
    Color32 ColWhite = new Color32(255, 255, 255, 255);
    Color32 warmGrey = new Color32(60, 66, 68, 255);


    void Start()
    {
        vSetting.SetActive(false);
        iSetting.SetActive(true);
        v_Btn.GetComponent<Image>().color = warmGrey;
        i_Btn.GetComponent<Image>().color = Color.black;
        a_Btn.GetComponent<Image>().color = warmGrey;
        v_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
        i_Btn.transform.GetComponentInChildren<Text>().color = ColYellow;
        a_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
    }




    public void vOpen()
    {
        vSetting.SetActive(true);
        iSetting.SetActive(false);
        aSetting.SetActive(false);
        v_Btn.GetComponent<Image>().color = Color.black;
        i_Btn.GetComponent<Image>().color = warmGrey;
        a_Btn.GetComponent<Image>().color = warmGrey;
        v_Btn.transform.GetComponentInChildren<Text>().color = ColYellow;
        i_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
        a_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;

    }

    public void iOpen()
    {
        vSetting.SetActive(false);
        iSetting.SetActive(true);
        aSetting.SetActive(false);
        v_Btn.GetComponent<Image>().color = warmGrey;
        i_Btn.GetComponent<Image>().color = Color.black;
        a_Btn.GetComponent<Image>().color = warmGrey;
        v_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
        i_Btn.transform.GetComponentInChildren<Text>().color = ColYellow;
        a_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
    }

    public void aOpen()
    {
        vSetting.SetActive(false);
        iSetting.SetActive(false);
        aSetting.SetActive(true);
        v_Btn.GetComponent<Image>().color = warmGrey;                          
        i_Btn.GetComponent<Image>().color = warmGrey;
        a_Btn.GetComponent<Image>().color = Color.black;
        v_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
        i_Btn.transform.GetComponentInChildren<Text>().color = Color.grey;
        a_Btn.transform.GetComponentInChildren<Text>().color = ColYellow;
    }



    //Check active toggle
   /* public void ActiveToggle()
    {
        if (a_mp3.isOn)
        {
            audioType = "mp3";
        }
        else if (a_aif.isOn)
        {
            audioType = "aif";
        }
        else if (a_wav.isOn)
        {
            audioType = "wav";
        }
    }*/

    //import audio
    public void Importer()
    {
       // ActiveToggle();
       // string AudioName = Input_AudioName.text + "." + audioType;
        //print(AudioName);
    }

   

    //import image
    public void ImportImage()
    {
        ImageName = Input_ImageName.text + ".jpg";

        MPath();
        string mPathF = "file://" + mPath + ImageName;   //file:// to display on mac
       // print(mPathF);

        StartCoroutine(SetImage(mPathF));
    }


    public IEnumerator SetImage(string url) //url is the texture sent by void start "plus.jpg"
    {

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

        ImagePlane.texture = www.texture;
        www.Dispose();
        www = null;

    }

   

    //import image as video button

    public void ImportVideoImageButton()
    {
        VideoImageName = Input_VideoImageName.text + ".jpg";
        streamVideo.VideoImageName = VideoImageName;
        //objControl.DataPaths();
        MPath();

       // print("mPath--> " + mPath);
        string mPathF = mPath + VideoImageName;
       //print(mPathF);

        StartCoroutine(SetVideoImage(mPathF)); // set button image
        streamVideo.GoBackToImage(); // change video image
    }
    public IEnumerator SetVideoImage(string url) //url is the texture sent by void start "plus.jpg"
    {

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

        VideoImagePlane.texture = www.texture;
        www.Dispose();
        www = null;

    }

    public void ImportVideoImageEnd()
    {
        VideoImageName = Input_VideoImageName_END.text + ".jpg";
        //streamVideo.VideoImageName = VideoImageName;
        //objControl.DataPaths();
        MPath();

        // print("mPath--> " + mPath);
        string mPathF = mPath + VideoImageName;
        //print(mPathF);

        StartCoroutine(SetVideoImage_END(mPathF)); // set button image
        //streamVideo.GoBackToImage(); // change video image
    }
    public IEnumerator SetVideoImage_END(string url) //url is the texture sent by void start "plus.jpg"
    {

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log("--- DEFAULT - TEXTURE = " + imgPathF);

        VideoImagePlane_END.texture = www.texture;
        www.Dispose();
        www = null;

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
