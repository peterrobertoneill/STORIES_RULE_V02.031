using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone_Media_files : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Drag_Media_file d = eventData.pointerDrag.GetComponent<Drag_Media_file>(); // call drag script
        if (d != null) // if does exist
        {
            d.placeHold_Parent_SHELF = this.transform;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Drag_Media_file d = eventData.pointerDrag.GetComponent<Drag_Media_file>(); // call drag script
        if (d != null && d.placeHold_Parent_SHELF == this.transform) // if does exist
        {
            d.placeHold_Parent_SHELF = d.par_ToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag_Media_file d = eventData.pointerDrag.GetComponent<Drag_Media_file>(); // call drag script
        if (d != null) // if does exist
        {
            d.par_ToReturnTo = this.transform; // switch parent to this
        }
        /// this changes the parent from the one the object came from to the one it's dropped on

    }
}
