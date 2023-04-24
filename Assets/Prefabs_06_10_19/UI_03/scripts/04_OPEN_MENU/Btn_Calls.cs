using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Calls : MonoBehaviour
{
    /// <summary>
    /// this script is on - OBJ -
    /// </summary>
    public GameObject TheCanvas;  //  - the Canvas where the Edit Menu_Open Close (Script) is
    public Transform Shelf_Box;  //  - the Edit menu Box that will hold the Edit_Shelf
    public Transform Edit_Shelf;  //  - the Shelf to Edit
    public int Edit_Shelf_index_return;  //  - the index to return to
    //private EditMenu_OpenClose C; 
    public Transform CONTENT_obj; // - where the CONTENT is on the OBJ
    public int OBJ_StoryCount;  // - How many stories in an OBJ ( not used )
    public GameObject Media_file; // - the object Instantiated into the OBJ list in Edit

    ///------------------------------------------------------------------------
    public void OpenMenu() // this is call by Button - BT_EDIT 2 - IN OBJ - 
    {
        TheCanvas = this.transform.parent.parent.parent.parent.parent.parent.gameObject; // find the canvas so we can use the script
        print("TheCanvas = " + TheCanvas.name); // working

        EditMenu_OpenClose C = TheCanvas.GetComponent<EditMenu_OpenClose>(); // use the script from the canvas

        Shelf_Box = C.Shelf_Box;
        print("Shelf_Box = " + Shelf_Box); // working

        Transform CONTENT_obj_list = C.CONTENT_obj_list;

        Edit_Shelf = this.transform.parent.parent.parent; // get the Shelf to Edit

        // if Edit Menu is not open - open it
        if (Edit_Shelf.transform.parent != Shelf_Box) // Edit_Shelf is not being edited -  open EDIT MENU
        {
            C.POpen();
            Edit_Shelf_index_return = Edit_Shelf.GetSiblingIndex(); // get the edit shelf index to return it to.

            C.Edit_Shelf_index_return = Edit_Shelf_index_return; // send the index number to TheCanvas script
            C.Edit_Shelf = Edit_Shelf; // send the Edit Shelf to TheCanvas script
            Edit_Shelf.SetParent(Shelf_Box); // set the parent of Edit_Shelf to the Shelf_Box
            Edit_Shelf.SetSiblingIndex(0);

        }

        
        /// remove last items being edited
        if(CONTENT_obj_list.childCount != 0)
        {
            for (int i = 0; i < CONTENT_obj_list.childCount; i++)
            {
                Destroy(CONTENT_obj_list.GetChild(i).gameObject);
            }
        }

        /// read content from OBJ --- assign to media_files
        OBJ_StoryCount = CONTENT_obj.childCount;
        //Transform CONTENT_obj_list = TheCanvas

        for (int i = 0; i < OBJ_StoryCount; i++)
        {
            // get the color from OBJs Media
            Color MediaColor = CONTENT_obj.GetChild(i).GetComponent<RawImage>().color;

            // Instantiate media_files
            GameObject media_file = Instantiate(Media_file) as GameObject;
            media_file.SetActive(true);
            media_file.transform.SetParent(CONTENT_obj_list, false);

            // apply colore from OBJ to Media_files
            RawImage Media_Reader = media_file.transform.GetChild(0).GetComponent<RawImage>();
            Media_Reader.color = MediaColor;

            // put a number somewhere



        }



    }
        

    
}
