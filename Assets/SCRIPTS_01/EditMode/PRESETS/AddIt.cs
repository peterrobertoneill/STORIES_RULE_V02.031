using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIt : MonoBehaviour
{

    public AddRemoveControl addRemoveControl;
    public JsonScript jsonScript;

    public void AddThis() // is on the "adding"
    {
        jsonScript.whichButton = "add"; // tell iniData 'adding' was pressed
        jsonScript.AddRemoveList(); // run initData.ButtonAction
        //print(" save was hit ");
    }



}
