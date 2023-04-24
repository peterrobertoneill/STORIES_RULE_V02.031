using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPressed : MonoBehaviour
{
    public AddRemoveControl addRemoveControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReturnWasPressed()
    {
        addRemoveControl.whichButton = "add"; // tell iniData 'adding' was pressed
        addRemoveControl.AddRemoveList(); // run initData.ButtonAction
        print(" return was hit ");
    }

}
