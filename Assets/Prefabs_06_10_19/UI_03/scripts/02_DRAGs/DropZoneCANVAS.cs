using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneCANVAS : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        DragOBJs o = eventData.pointerDrag.GetComponent<DragOBJs>(); // call drag script
        if (o != null) // if does exist
        {
            o.placeHold_Parent_OBJ = o.origin_par_ToReturnTo;
        }

        DragShelf s = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
        if (s != null) // if does exist
        {
            s.placeHold_Parent_SHELF = s.origin_par_ToReturnTo;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        DragOBJs o = eventData.pointerDrag.GetComponent<DragOBJs>(); // call drag
        if (o != null && o.placeHold_Parent_OBJ == this.transform)
        {
            o.placeHold_Parent_OBJ = o.origin_par_ToReturnTo; // switch parent to this
        }

        DragShelf s = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
        if (s != null && s.placeHold_Parent_SHELF == this.transform) // if does exist
        {
            s.placeHold_Parent_SHELF = s.origin_par_ToReturnTo;
        }

        //print("--- out ---");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //print(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        DragOBJs o = eventData.pointerDrag.GetComponent<DragOBJs>(); // call Draggable Call on dragged object
        if (o != null) // if does exist
        {
            o.par_ToReturnTo = o.origin_par_ToReturnTo; // switch parent to this
        }

        DragShelf s = eventData.pointerDrag.GetComponent<DragShelf>(); // call drag script
        if (s != null) // if does exist
        {
            s.par_ToReturnTo = s.origin_par_ToReturnTo; // switch parent to this
        }

        /// this changes the parent from the one the object came from to the one it's dropped on

    }

}
