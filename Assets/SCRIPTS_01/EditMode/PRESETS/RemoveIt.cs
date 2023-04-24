using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveIt : MonoBehaviour 
{
    public AddRemoveControl addRemoveControl;
    public JsonScript jsonScript;


    //public string preName;
    public Text preName;
    

    public void RemoveThis() // script is on the 'x' button
    {

        int removeThis = this.transform.parent.GetSiblingIndex();  //-------- get it's parent's(the button's) Index
        preName = this.transform.parent.GetComponentInChildren<Text>(); //-------- get the name of the button
        jsonScript.preName = preName.text; // send it to initData
        jsonScript.removeThis = removeThis; // set the index number

        //print("07---preName - remove------->> " + preName.text);
        //print("08---preName - index ------->> " + removeThis);

        jsonScript.whichButton = "remove"; // tell initData that 'x' was pressed
        jsonScript.AddRemoveList(); // run inData ButtonAction
        
    }
}
