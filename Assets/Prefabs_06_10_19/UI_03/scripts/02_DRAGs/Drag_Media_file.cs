using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Media_file : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform origin_par_ToReturnTo = null; // set
    public Transform OtherPar_Shelf;
    public Transform par_ToReturnTo = null; // set
    public Transform placeHold_Parent_SHELF = null;
    public GameObject placeHold_SHELF = null;
    public GameObject holdPlace;
    public Transform Canvas;

    private float w;
    private float y0;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Canvas = this.transform.parent.parent.parent;
        placeHold_SHELF = Instantiate(holdPlace) as GameObject;
        placeHold_SHELF.GetComponent<CanvasGroup>().alpha = 0.25f;


        //print("OnBeginDrag");
        par_ToReturnTo = this.transform.parent; // does not need this for the main drag... but to jump back from edit
        //placeHold_Parent_SHELF = par_ToReturnTo;
        origin_par_ToReturnTo = this.transform.parent; // does not need this for the main drag... but to jump back from edit
        this.transform.SetParent(this.transform.parent.parent.parent); //Note: turned off

        placeHold_SHELF.transform.SetParent(this.transform.parent, false); //not world space
        LayoutElement le = placeHold_SHELF.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHold_SHELF.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        par_ToReturnTo = this.transform.parent;
        placeHold_Parent_SHELF = par_ToReturnTo;
        this.transform.SetParent(this.transform.parent.parent.parent);  //Note: turned off

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //offSetIt = this.transform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if (placeHold_SHELF.transform.parent != placeHold_Parent_SHELF)
            placeHold_SHELF.transform.SetParent(placeHold_Parent_SHELF);
        /// making sure the placeholder is == to placeholder
        /// else the opening will not happen when dragging up to a dropzone

        int newSiblingIndex = placeHold_Parent_SHELF.childCount;// -- assumes we want to end up on the right most
        for (int i = 0; i < placeHold_Parent_SHELF.childCount; i++)
        {
            if (this.transform.position.y > placeHold_Parent_SHELF.GetChild(i).position.y)
            {
                newSiblingIndex = i;
                if (placeHold_SHELF.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;
                break;
            }
        }
        placeHold_SHELF.transform.SetSiblingIndex(newSiblingIndex);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("OnEndDrag");
        this.transform.SetParent(par_ToReturnTo);

        /// on endDrag - returns the object to saved Parent
        if (this.transform.parent != Canvas)
            this.transform.SetSiblingIndex(placeHold_SHELF.transform.GetSiblingIndex());
        else
        {
            this.transform.SetParent(origin_par_ToReturnTo);
            this.transform.SetSiblingIndex(placeHold_SHELF.transform.GetSiblingIndex());
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true; //
        Destroy(placeHold_SHELF);

    }


}
