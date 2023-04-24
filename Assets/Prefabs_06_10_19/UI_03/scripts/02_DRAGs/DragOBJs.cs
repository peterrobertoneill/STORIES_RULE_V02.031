using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragOBJs : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform origin_par_ToReturnTo = null; // set
    public Transform par_ToReturnTo = null; // set
    public Transform placeHold_Parent_OBJ = null;
    public GameObject placeHold_OBJ = null;
    public GameObject holdPlace;
    private Transform ParentParentParent = null;



    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHold_OBJ = Instantiate(holdPlace) as GameObject;
        placeHold_OBJ.GetComponent<CanvasGroup>().alpha = 0.25f;


        //print("OnBeginDrag");
        
        origin_par_ToReturnTo = this.transform.parent; // back home
        par_ToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent.parent);
        ParentParentParent = this.transform.parent;
        print("parent is = " + this.transform.parent);


        placeHold_OBJ.transform.SetParent(this.transform.parent, false);
        LayoutElement le = placeHold_OBJ.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHold_OBJ.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        par_ToReturnTo = this.transform.parent; // saves to old parent
        placeHold_Parent_OBJ = par_ToReturnTo;
        this.transform.SetParent(this.transform.parent.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        // turn of button's raycast

       // print("----------------------------- in ---");



    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;

        if (placeHold_OBJ.transform.parent != placeHold_Parent_OBJ)
            placeHold_OBJ.transform.SetParent(placeHold_Parent_OBJ);
        /// making sure the placeholder is == to placeholder
        /// else the opening will not happen when dragging up to a dropzone

        int newSiblingIndex = placeHold_Parent_OBJ.childCount;// -- assumes we want to end up on the right most
        for(int i = 0; i < placeHold_Parent_OBJ.childCount; i++)
        {
            if(this.transform.position.x < placeHold_Parent_OBJ.GetChild(i).position.x) //NOTE: HORIZONTAL
            {
                newSiblingIndex = i;
                if (placeHold_OBJ.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;
                break;
            }
        }
        placeHold_OBJ.transform.SetSiblingIndex(newSiblingIndex);

       // print(par_ToReturnTo.name);




    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("OnEndDrag");
        this.transform.SetParent(par_ToReturnTo);

        print("parent is = " + par_ToReturnTo);


        if (par_ToReturnTo == ParentParentParent)
            this.transform.SetParent(origin_par_ToReturnTo);

        //print(par_ToReturnTo.name);
        /// on endDrag - returns the object to the saved Parent
        this.transform.SetSiblingIndex(placeHold_OBJ.transform.GetSiblingIndex()); // puts this object where the placeholder was


        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeHold_OBJ);
    }

}
