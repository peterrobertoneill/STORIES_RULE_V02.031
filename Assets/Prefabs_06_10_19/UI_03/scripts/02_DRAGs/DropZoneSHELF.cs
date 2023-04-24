using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneSHELF : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        DragShelf d = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
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

        DragShelf d = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
        if (d != null && d.placeHold_Parent_SHELF == this.transform) // if does exist
        {
            d.placeHold_Parent_SHELF = d.par_ToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragShelf d = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
        if (d != null) // if does exist
        {
            d.par_ToReturnTo = this.transform; // switch parent to this
        }
        /// this changes the parent from the one the object came from to the one it's dropped on

    }

}
