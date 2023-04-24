
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class PopTest : MonoBehaviour
{
    //---**------other scripts ---------------
    public MediaPath mediaPath;
    public LoadSave loadSave;

    public string imgDataPath;
    public string imgPathF;
    public string contentPath;
    public string contentPathF; // --------- F is when the file is added to the path string

    public List<ObjData> objDataList = new List<ObjData>();

    public GameObject theShelf;
    public GameObject tChild;

    

    public void DoIt()
    {
        //PopulateTest(objs);
        PopulateTest2();

    }

    public void PopulateTest2()
    {
        mediaPath.ImgDataPath(); //----path for textures
        mediaPath.ContentPath();
        loadSave.LoadObjData();  //----load data
        ///print(DataPath_LS);
        ///print(objDataList[2].objName);

        //-----------------------collect data & distribute--------------------
        int counter = 0;
        //-----------------NOTE: data can't exceed number of objs on shelf -- check
        objDataList.Sort((story1, story2) => story1.objOrder.CompareTo(story2.objOrder)); //-------sort
        foreach (ObjData theDat in objDataList)  // <------------ using the sorted list
        {
            string obName = objDataList[counter].objName.ToString();
            //string obTexture = objDataList[counter].objTexture.ToString();
            string obOrder = objDataList[counter].objOrder.ToString();
            //print(obTexture);
            //----------------NOTE: need to add a path to folders
            //imgPathF = "file://" + imgDataPath + obTexture;// set path for image
            contentPathF = "file://" + contentPath + obName;// set path for image

            tChild = theShelf.transform.GetChild(counter).gameObject; //--- get each child
            ///--- must get the transform of the parent to get it's child at count -- returns Rec Transform
            ///--- .gameObject - to get the gameObject of the child
            tChild.GetComponent<StreamVideo>().SetFlowImg(imgPathF); //---- pass imgPathF on to child's script
            tChild.GetComponent<StreamVideo>().SetFlowName(obName); //---- pass on to child's script
            tChild.GetComponent<StreamVideo>().SetFlowOrder((counter + 1).ToString()); //---- pass on to child's script
            counter++;
        }

    }



}
