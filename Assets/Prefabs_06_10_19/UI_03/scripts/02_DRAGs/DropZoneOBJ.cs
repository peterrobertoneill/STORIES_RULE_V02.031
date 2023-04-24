using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZoneOBJ : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler

{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        DragOBJs d = eventData.pointerDrag.GetComponent<DragOBJs>(); // call drag script
        if (d != null) // if does exist
        {
            d.placeHold_Parent_OBJ = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        DragOBJs d = eventData.pointerDrag.GetComponent<DragOBJs>(); // call drag
        if (d != null && d.placeHold_Parent_OBJ == this.transform)
        {
            d.placeHold_Parent_OBJ = d.par_ToReturnTo; // switch parent to this
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //print(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        DragOBJs d = eventData.pointerDrag.GetComponent<DragOBJs>(); // call Draggable Call on dragged object
        if (d != null) // if does exist
        {
            d.par_ToReturnTo = this.transform; // switch parent to this
        }
        /// this changes the parent from the one the object came from to the one it's dropped on

    }

}
