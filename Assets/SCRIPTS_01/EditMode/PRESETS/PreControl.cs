using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;



public class PreControl : MonoBehaviour
{

    public List<string> shelfPresets = new List<string>();
    public ObjControl objControl;
    public string DataPath_LS;
    string filePath;
    private List<GameObject> buttons;
    public GameObject NewPreButton;
    public Text ReadOut;
    public Text ShelfNum;


    private void Awake()
    {
        //LoadPresets();
    }


    void Start()
    {

        buttons = new List<GameObject>();
        //LastSaved();

    }

    public void LastSaved()
    {
        print("00-shelf's parent---------->> " + this.transform.parent.name);

    }


    public void DisplayPresetList()
    {

       // objControl.LoadPresets();

        print("-----------display Preset lists------------");

        if (buttons.Count > 0)  //clean up
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }              
            buttons.Clear();
        }
        print("05----list------->> " + shelfPresets.Count);

        for (int i = 0; i < shelfPresets.Count; i++)
        {
            GameObject NewPre = Instantiate(NewPreButton) as GameObject;
            NewPre.SetActive(true);
            NewPre.transform.SetParent(NewPreButton.transform.parent, false);
            NewPre.GetComponentInChildren<Text>().text = shelfPresets[i];

            buttons.Add(NewPre.gameObject);

            //ReadOut.text = shelfIndex.ToString() + " - " + shelfName;

            print("06----firstName------->> " + shelfPresets[0]);

        }

        ///
        /// ABOVE IS THE BASIC STRUCTURE
        /// FOR DEALING WITH THE PRESET DATA AND THE LIST
        /// - I SUSPECT THIS CAN WORK FOR THE MAIN OBJECTS AS WELL - 


    }
















}
