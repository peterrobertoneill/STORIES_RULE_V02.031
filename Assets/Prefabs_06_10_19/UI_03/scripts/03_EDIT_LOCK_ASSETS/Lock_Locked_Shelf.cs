using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock_Locked_Shelf : MonoBehaviour
{
    public GameObject Lock_Shelf;
    public GameObject Locked_Shelf;

    public void Locked_theShelf()
    {
        Color32 DisabledColor = new Color32(111, 111, 111, 255);  // new color  - DisabledColor

        Transform SHELF = this.transform.parent.parent; // find all OBJs on SHELF
        Transform MASK_self = SHELF.GetChild(0).transform;
        Transform CONTENT_self = MASK_self.GetChild(0).transform; // parent of OBJs
                                                                  //print(" ---  child count = " + CONTENT_self.childCount);

        Transform BT_MENU = SHELF.GetChild(3).transform; // MAKE INTERACTABLE false
        GameObject BT_edit_shelf = BT_MENU.GetChild(5).gameObject; // edit button
        
        Text Edit_TEXT_SHELF = BT_edit_shelf.GetComponentInChildren<Text>(); // "EDIT" TEXT COLOR
         


        if (Locked_Shelf.activeSelf == false)
        {
            BT_edit_shelf.GetComponent<Button>().interactable = (false); // MAKE INTERACTABLE false
            Edit_TEXT_SHELF.GetComponent<Text>().color = DisabledColor;  // "EDIT" TEXT COLOR

            Locked_Shelf.SetActive(true);
            Lock_Shelf.SetActive(false);


            for (int i = 0; i < CONTENT_self.childCount; i++) // lock - all OBJs - on SHELF
            {
                Transform OBJ = CONTENT_self.GetChild(i).transform;
                Transform OBJ_MENU = OBJ.GetChild(1).transform;
                GameObject Locked = OBJ_MENU.GetChild(0).gameObject;
                GameObject Lock = OBJ_MENU.GetChild(1).gameObject;
                Locked.SetActive(true);
                Lock.SetActive(false);

                GameObject BT_edit = OBJ_MENU.GetChild(2).gameObject;
                print(" BT_edit 5 = " + BT_edit.name);

                Text Edit = BT_edit.GetComponentInChildren<Text>(); // "EDIT" TEXT COLOR - on OBJs -
                Edit.GetComponent<Text>().color = DisabledColor; 

                BT_edit.GetComponent<Button>().interactable = (false); // MAKE edit - on OBJs - INTERACTABLE false

            }
             


        }
        else
        {
            BT_edit_shelf.GetComponent<Button>().interactable = (true); // MAKE INTERACTABLE true
            Edit_TEXT_SHELF.GetComponent<Text>().color = Color.white;  // "EDIT" TEXT COLOR
            Locked_Shelf.SetActive(false);
            Lock_Shelf.SetActive(true);


     

        }


    }
}
