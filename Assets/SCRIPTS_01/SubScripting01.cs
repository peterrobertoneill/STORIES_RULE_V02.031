using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;


public class SubScripting01 : MonoBehaviour
{
   // public List<Objthree> objthree;
    public List<string> JName;
    //public Objthree obj3;

    public JsonScript jsonScript;
    public ObjControl objControl;
    public string DataPath_LS;
    string filePath;

    public GameObject NContent;
    public GameObject NContent_parent;

    //public InputField NewNameInput;

    public void NewMediaInput()
    {

        print("-----------New Media Input List write ------------");


        print(" 00 -----this Object is --->>  " + this.transform.name);


        int NewMediaIndex = NContent.transform.childCount;
        ///---------------------

        print(" 00 -----New Media Index--->>  " + NewMediaIndex);

        for (int i = 0; i < NewMediaIndex; i++)
        {

            GameObject NFeild_Parent = NContent.transform.GetChild(i).gameObject;
            string NewNameText = NFeild_Parent.transform.GetChild(0).GetComponentInChildren<InputField>().text; //spelunk to input feild / might not need this line

           // string NewNameText = NFeild_Parent.transform.GetChild(0).GetComponent<InputField>().text; // text from a list of InputFields
            print(" 01 -----New Name Text--->>  " + NewNameText);


        }


    }




    

}
