using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaList_MS : MonoBehaviour
{
    public GameObject NewMediaInput;
    public JsonScript jsonScript;




    public void NewMedia() // new object on + button
    {

        GameObject NewObj = Instantiate(NewMediaInput) as GameObject;  // CLONE Obj
        NewObj.SetActive(true);
        NewObj.transform.SetParent(NewMediaInput.transform.parent, false); // position

        //print(NewObj.transform.parent);

        int ObjIndex = NewObj.transform.GetSiblingIndex(); // obj index
       // print(ObjIndex);

        GameObject NewInviewer = this.transform.GetChild(1).gameObject;
        GameObject NContent = NewInviewer.transform.GetChild(0).gameObject;
       // print(NContent.name);
        int objectCount = NContent.transform.childCount;
       // print(objectCount);

        for (int i = 1; i < objectCount; i++) // refresh numbers
        {

            GameObject NFeild_parent = NContent.transform.GetChild(i).gameObject;
            GameObject buts = NFeild_parent.transform.GetChild(1).gameObject;
            GameObject media_Num_btn = buts.transform.GetChild(0).gameObject;
            media_Num_btn.transform.GetComponentInChildren<Text>().text = i.ToString();

        }





    }

   



}
