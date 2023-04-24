using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SetMedia : MonoBehaviour
{
    public string dir;
    public string dataPathF;
    public string dataPath;
    public string mPathF;
    public string mPath; //set from MediaPath

    public RawImage rawImage;


    void Start()
    {
       

    }

    void Update()
    {
        
    }
    //------------------set image -------------------
    public void SetImage(string sName)
    {
        MPath();
        mPathF = "file://" + mPath + sName + ".jpg";
        print("Media path name -- " + mPathF);

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

    }
    //----------------------------------------------

    public void MPath() // path to movies
    {
        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;

        dataPath = dir + "/flowmedia/";
        dataPath = dataPath.Replace('\\', '/');
        Debug.Log("path = " + dataPath);

        mPath = dataPath;
        print(mPath);

        //makeTestList.dataPath2 = dataPath;
        //instTestList.dataPath3 = dataPath;
        //objListControl.dataPath4 = dataPath;


    }

}
