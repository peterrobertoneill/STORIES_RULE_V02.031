using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_Layout : MonoBehaviour
{
    public Transform EDIT;
    public Transform Cross_Bar;
    public Transform Shelf_Box;

    public GameObject OBJ_List;
    public GameObject POST_Bar;
    public GameObject Media_Settings;

    public Transform OBJ_ScrollBar;
    public Transform Media_Set_ScrollBar;

    public Transform OBJ_icons;
    public Transform Obj_Title_save;
    public Transform media_menu;

    public GameObject Edit_Edit;
    //public Transfrom Edit


    public void Layout_One()
    {
        print("one");
        Shelf_Box.SetSiblingIndex(0);
        Cross_Bar.SetSiblingIndex(1);
        EDIT.SetSiblingIndex(2);

        OBJ_List.transform.SetSiblingIndex(0);
        POST_Bar.transform.SetSiblingIndex(1);
        Media_Settings.transform.SetSiblingIndex(2);

        OBJ_ScrollBar.SetSiblingIndex(0);
        Media_Set_ScrollBar.SetSiblingIndex(1);

        OBJ_icons.SetSiblingIndex(2);
        Obj_Title_save.SetSiblingIndex(0);
        media_menu.SetSiblingIndex(1);

        //Canvas.ForceUpdateCanvases();
    }

    public void Layout_Two()
    {
        print("two");
        Shelf_Box.SetSiblingIndex(0);
        Cross_Bar.SetSiblingIndex(1);
        EDIT.SetSiblingIndex(2);

        OBJ_List.transform.SetSiblingIndex(2);
        POST_Bar.transform.SetSiblingIndex(1);
        Media_Settings.transform.SetSiblingIndex(0);

        OBJ_ScrollBar.SetSiblingIndex(1);
        Media_Set_ScrollBar.SetSiblingIndex(0);

        OBJ_icons.SetSiblingIndex(2);
        Obj_Title_save.SetSiblingIndex(0);
        media_menu.SetSiblingIndex(1);

    }

    public void Layout_Three()
    {
        print("three");
        Shelf_Box.SetSiblingIndex(2);
        Cross_Bar.SetSiblingIndex(1);
        EDIT.SetSiblingIndex(0);

        OBJ_List.transform.SetSiblingIndex(0);
        POST_Bar.transform.SetSiblingIndex(1);
        Media_Settings.transform.SetSiblingIndex(2);

        OBJ_ScrollBar.SetSiblingIndex(0);
        Media_Set_ScrollBar.SetSiblingIndex(1);

        OBJ_icons.SetSiblingIndex(0);
        Obj_Title_save.SetSiblingIndex(2);
        media_menu.SetSiblingIndex(0);

        //Canvas.ForceUpdateCanvases();
        //Edit_Edit.transform.GetComponent<VerticalLayoutGroup>().enabled = false;
        //Edit_Edit.transform.GetComponent<VerticalLayoutGroup>().enabled = true;
        //EDIT.GetComponent<HorizontalLayoutGroup>().enabled = false;
        //EDIT.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }

    public void Layout_Four()
    {
        print("four");
        Shelf_Box.SetSiblingIndex(2);
        Cross_Bar.SetSiblingIndex(1);
        EDIT.SetSiblingIndex(0);

        OBJ_List.transform.SetSiblingIndex(2);
        POST_Bar.transform.SetSiblingIndex(1);
        Media_Settings.transform.SetSiblingIndex(0);

        OBJ_ScrollBar.SetSiblingIndex(1);
        Media_Set_ScrollBar.SetSiblingIndex(0);

        OBJ_icons.SetSiblingIndex(0);
        Obj_Title_save.SetSiblingIndex(2);
        media_menu.SetSiblingIndex(0);

    }


}
