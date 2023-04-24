using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMenu_OpenClose : MonoBehaviour
{

    public GameObject Open_State;
    public Transform Shelf_Box;
    public Transform CONTENT_holder;
    public int Edit_Shelf_index_return;
    public Transform Edit_Shelf;
    public Transform CONTENT_obj_list;

    private void Start()
    {
        //Hide Edit Edit
        this.transform.GetChild(1).gameObject.SetActive(false);

    }

    public void POpen()
    {
        // PanelClosed.SetActive(false);
        Open_State.SetActive(true);
       // closedState.SetActive(false);
    }

    public void PClose()
    {
        // PanelClosed.SetActive(false);
        print("Shelf_Box = " + Shelf_Box); // working
        Edit_Shelf = Shelf_Box.GetChild(0);
        Edit_Shelf.SetParent(CONTENT_holder);
        Edit_Shelf.SetSiblingIndex(Edit_Shelf_index_return);

        Open_State.SetActive(false);
        // closedState.SetActive(false);
        


    }

}
