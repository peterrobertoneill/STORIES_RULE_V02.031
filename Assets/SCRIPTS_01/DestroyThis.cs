using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyThis : MonoBehaviour // removes button but list needs to refresh
{
    public GameObject RefreshOne;
    public GameObject RefreshTwo;
    public JsonScript jsonScript;

    public void DestroyParent()
        
    {
        int ButtonIndex = this.gameObject.transform.parent.GetSiblingIndex();
        print(ButtonIndex);


        if (ButtonIndex != 1 )
        {
            Destroy(this.transform.parent.gameObject);

            Canvas.ForceUpdateCanvases();
            RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
            RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;

            RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
            RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;


            int objectCount = this.transform.parent.parent.childCount;
            for (int i = 1; i < objectCount; i++) // refresh numbers
            {
                GameObject NContent = this.transform.parent.parent.gameObject;
                GameObject NFeild_parent = NContent.transform.GetChild(i).gameObject;
                GameObject buts = NFeild_parent.transform.GetChild(1).gameObject;
                GameObject media_Num_btn = buts.transform.GetChild(0).gameObject;
                media_Num_btn.transform.GetComponentInChildren<Text>().text = i.ToString();
            }

        }

        //-------------------------- // refresh numbers ----------------------------------> 003

        

    }










    public void triggerRESAVE() //trigger save off all objects on a shelf------------000
    {

        GameObject shelf = this.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject;
        GameObject PresetPanel_Closed_v04 = shelf.transform.GetChild(3).gameObject;
        GameObject reload_resave = PresetPanel_Closed_v04.transform.GetChild(2).gameObject;
        GameObject resave = reload_resave.transform.GetChild(1).gameObject;
        Button resaveit = resave.GetComponent<Button>();
        print(resaveit);
        resaveit.onClick.Invoke();


    }











    public void WriteRead()
    {
        print("writeREad");
        //Invoke("jsonScript.JsObjListWrite", 1f);
        jsonScript.JsObjListWrite();
        //Invoke(" jsonScript.ReadObjListUtility", 1f);
        jsonScript.ReadObjListUtility();
    }










    public void MoveItUp()
    {
        int objectCount = this.transform.parent.parent.childCount;

        print(this.transform.parent.parent.gameObject.name);

        //-------------------------- get Media Num----------------------------------> 001

        GameObject NFeild_P = this.transform.parent.gameObject;
        print(NFeild_P.name);
        GameObject buts = NFeild_P.transform.GetChild(1).gameObject;
        GameObject media_Num_btn = buts.transform.GetChild(0).gameObject;
        string Media_Num = media_Num_btn.transform.GetComponentInChildren<Text>().text;

        //-------------------------- turn Media Num into int ----------------------------------> 002
        int MedNum = int.Parse(Media_Num);

        if(MedNum > 1)
        {
            NFeild_P.transform.SetSiblingIndex(MedNum - 1);
        }

        //-------------------------- // refresh numbers ----------------------------------> 003

        for (int i = 1; i < objectCount; i ++) // refresh numbers
        {
            GameObject NContent = this.transform.parent.parent.gameObject;
            GameObject NFeild_parent = NContent.transform.GetChild(i).gameObject;
            buts = NFeild_parent.transform.GetChild(1).gameObject;
            media_Num_btn = buts.transform.GetChild(0).gameObject;
            media_Num_btn.transform.GetComponentInChildren<Text>().text = i.ToString();
        }

        //-------------------------- //

    }











    public void MoveItDown()
    {
        int objectCount = this.transform.parent.parent.childCount;

        print(objectCount);

        GameObject NFeild_P = this.transform.parent.gameObject;
        print(NFeild_P.name);
        GameObject buts = NFeild_P.transform.GetChild(1).gameObject;
        GameObject media_Num_btn = buts.transform.GetChild(0).gameObject;
        string Media_Num = media_Num_btn.transform.GetComponentInChildren<Text>().text;

        int MedNum = int.Parse(Media_Num);

        if (MedNum < objectCount)
        {
            NFeild_P.transform.SetSiblingIndex(MedNum + 1);
        }

        for (int i = 1; i < objectCount; i++) // refresh numbers
        {
            GameObject NContent = this.transform.parent.parent.gameObject;
            GameObject NFeild_parent = NContent.transform.GetChild(i).gameObject;
            buts = NFeild_parent.transform.GetChild(1).gameObject;
            media_Num_btn = buts.transform.GetChild(0).gameObject;
            media_Num_btn.transform.GetComponentInChildren<Text>().text = i.ToString();
        }

    }





}



