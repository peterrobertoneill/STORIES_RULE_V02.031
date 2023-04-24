using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MediaList : MonoBehaviour
{
    public string dir;
    public string dataPath;
    public string DataPath_LS;
    private string mainDataPath;
    private string mPath;
    private string mPathData;
    private List<string> fileNames;
    public InputField fileNamesList;


    public void MediaListAll()
    {
        DataPaths();

        mPath = @"" + mPath;
        string result = "";
        fileNames = new List<string>(Directory.GetFiles(mPath));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
            //print(fileNames[i]);
            result += fileNames[i] + "\n";

        }
        fileNamesList.text = result;
    }


    public void MediaListMp4()
    {
        DataPaths();

        string result2 = "";
        fileNames = new List<string>(Directory.GetFiles(mPath, "*.mp4"));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
            //print(fileNames[i]);
            result2 += fileNames[i] + "\n";

        }
        fileNamesList.text = result2;
    }

    public void MediaListJpg()
    {
        DataPaths();

        string result2 = "";
        fileNames = new List<string>(Directory.GetFiles(mPath, "*.jpg"));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
            //print(fileNames[i]);
            result2 += fileNames[i] + "\n";

        }
        fileNamesList.text = result2;
    }

    public void MediaListMp3()
    {
        DataPaths();

        string result2 = "";
        fileNames = new List<string>(Directory.GetFiles(mPath, "*.mp3"));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
           // print(fileNames[i]);
            result2 += fileNames[i] + "\n";

        }
        fileNamesList.text = result2;
    }

    public void MediaListAif()
    {
        DataPaths();

        string result2 = "";
        fileNames = new List<string>(Directory.GetFiles(mPath, "*.aif"));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
            //print(fileNames[i]);
            result2 += fileNames[i] + "\n";

        }
        fileNamesList.text = result2;
    }

    public void MediaListPresets()
    {
        DataPaths();
        mPathData = @"" + mPathData;
        string PresetPath = Application.streamingAssetsPath;
        string result2 = "";
        fileNames = new List<string>(Directory.GetFiles(PresetPath));
        for (int i = 0; i < fileNames.Count; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
            //print(fileNames[i]);
            result2 += fileNames[i] + "\n";

        }
        fileNamesList.text = result2;
    }



    public void DataPaths() //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    {
        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;

        dataPath = dir + "/flowmedia/";
        dataPath = dataPath.Replace('\\', '/');
        mPath = dataPath;
        mPathData = dataPath + "data/";
        /*
        mainDataPath = dir + "/flowmedia/data/";
        mainDataPath = mainDataPath.Replace('\\', '/');
        DataPath_LS = mainDataPath;
        preControl.DataPath_LS = mainDataPath;
        addRemoveControl.DataPath_LS = mainDataPath;
        subScripting01.DataPath_LS = mainDataPath;
        */
        // print("-----------paths------------");
        // print("path media --- " + mPath);
        // print("path data --- " + DataPath_LS);

    }

}
