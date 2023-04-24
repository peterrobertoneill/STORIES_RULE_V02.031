using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_Call_Self : MonoBehaviour
{
    public GameObject TheCanvas;
    public Transform Shelf_Box;
    public Transform Edit_Shelf;
    public int Edit_Shelf_index_return;

    public void OpenMenu()
    {
        TheCanvas = this.transform.parent.parent.parent.gameObject; // find the canvas so we can use the script
        print("TheCanvas = " + TheCanvas.name); // working

        EditMenu_OpenClose C = TheCanvas.GetComponent<EditMenu_OpenClose>(); // access the script

        Shelf_Box = C.Shelf_Box;

        
        Edit_Shelf = this.transform;

        if (Edit_Shelf.transform.parent != Shelf_Box) // not already in edit mode
        {
            C.POpen();
            Edit_Shelf_index_return = Edit_Shelf.GetSiblingIndex(); // get index to return to
            C.Edit_Shelf_index_return = Edit_Shelf_index_return; // send index to Canvas
            C.Edit_Shelf = Edit_Shelf;
            Edit_Shelf.SetParent(Shelf_Box);
        }

    }
}
