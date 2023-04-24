using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MediaPath : MonoBehaviour
{
    //-----**----other scripts ---------------
   // public LoadSave loadSave;
    //public PresetSaveLoad presetSaveLoad;
    //public PopTest popTest;
    public StreamVideo streamVideo;
    public ObjControl objControl;

    public string pop;
    public string dir;
    public string dataPath;
    public string DataPath_LS;
    private string mainDataPath;
    public string imgDataPath;
    public string contentPath;


    //--------------------path to images------------
    public void ImgDataPath() // path to movies
    {
        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;
        //---just check a read on paths
        print("or " + dir);
        print("dirName = " + Path.GetDirectoryName(dir));

        dataPath = dir + "/flowmedia/";
        dataPath = dataPath.Replace('\\', '/');
        //dataPathF = "file://" + dataPath;
        Debug.Log("path = " + dataPath);
        // showFiles();
        //makeTestList.dataPath2 = dataPath;
        //instTestList.dataPath3 = dataPath;
       //- popTest.imgDataPath = dataPath;
    }
    //--------------------path to externals------------
    public void ContentPath() // path to movies
    {
        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;
        dataPath = dir + "/flowmedia/";
        dataPath = dataPath.Replace('\\', '/');
        //dataPathF = "file://" + dataPath;
        Debug.Log("path = " + dataPath);
       //- popTest.contentPath = dataPath;
        streamVideo.mPath = dataPath;
        print(streamVideo.mPath);
        streamVideo.aNumber = 1 + 2;
        //makeTestList.dataPath2 = dataPath;
        //instTestList.dataPath3 = dataPath;
        //objListControl.dataPath4 = dataPath;
    }
    //-------------------path to data--------------------
    public void MainDataPath() // path to movies
    {
        //popTest = popTest.GetComponent<PopTest>();

        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;
        mainDataPath = dir + "/flowmedia/data/";
        mainDataPath = mainDataPath.Replace('\\', '/');
        //dataPathF = "file://" + dataPath;
        Debug.Log("path = " + mainDataPath);
        // showFiles();
        //presetSaveLoad.DataPath_LS = mainDataPath;
        objControl.DataPath_LS = mainDataPath;
        //instTestList.dataPath3 = dataPath;
        //objListControl.dataPath4 = dataPath;
    }


}
