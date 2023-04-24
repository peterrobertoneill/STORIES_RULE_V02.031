using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class lock_locked : MonoBehaviour
{
    public GameObject Lock;
    public GameObject Locked;

    public void Locked_Obj()
    {
        Color32 DisabledColor = new Color32(111, 111, 111, 255);  // new color  - DisabledColor

        Transform OBJ = this.transform.parent.parent;   // parent of unLocked button
        Transform OBJ_MENU = OBJ.GetChild(1).transform;
        GameObject BT_EDIT = OBJ_MENU.GetChild(2).gameObject; // Edit button
        Text Edit_TEXT = BT_EDIT.GetComponentInChildren<Text>(); // "EDIT" TEXT

        if (Locked.activeSelf == false)
        {
            Locked.SetActive(true);
            Lock.SetActive(false);

            // unlock obj - and edit
           /// Transform OBJ = this.transform.parent.parent;   // parent of unLocked button
           /// Transform OBJ_MENU = OBJ.GetChild(1).transform;
           /// GameObject BT_EDIT = OBJ_MENU.GetChild(2).gameObject; // Edit button
            ///Text Edit_TEXT = BT_EDIT.GetComponentInChildren<Text>(); // "EDIT" TEXT

            BT_EDIT.GetComponent<Button>().interactable = (false); // MAKE INTERACTABLE false
            Edit_TEXT.GetComponent<Text>().color = DisabledColor;  // "EDIT" TEXT COLOR
        }
            
        else
        {
            Locked.SetActive(false);
            Lock.SetActive(true);



            // unlock shelf - and edit
            Transform SHELF = this.transform.parent.parent.parent.parent.parent; // SHELF
            Transform BT_MENU = SHELF.GetChild(3).transform;
            GameObject BT_edit_self = BT_MENU.GetChild(5).gameObject;

            BT_edit_self.GetComponent<Button>().interactable = (true); // MAKE INTERACTABLE - ON SHELF - true
            Text Edit_TEXT_SHELF = BT_edit_self.GetComponentInChildren<Text>(); // "EDIT" TEXT COLOR
            Edit_TEXT_SHELF.GetComponent<Text>().color = Color.white;  // "EDIT" TEXT COLOR

            GameObject Locked_Shelf = BT_MENU.GetChild(0).gameObject;
            GameObject Lock_Shelf = BT_MENU.GetChild(1).gameObject;
            Locked_Shelf.SetActive(false);
            Lock_Shelf.SetActive(true);

            // unlock obj - and edit
            ///Transform OBJ = this.transform.parent.parent;   // parent of unLocked button
           /// Transform OBJ_MENU = OBJ.GetChild(1).transform;
           /// GameObject BT_EDIT = OBJ_MENU.GetChild(2).gameObject; // Edit button
            ///Text Edit_TEXT = BT_EDIT.GetComponentInChildren<Text>(); // "EDIT" TEXT

            BT_EDIT.GetComponent<Button>().interactable = (true); // MAKE INTERACTABLE false
            Edit_TEXT.GetComponent<Text>().color = Color.white;  // "EDIT" TEXT COLOR


        }
            

    }

}
