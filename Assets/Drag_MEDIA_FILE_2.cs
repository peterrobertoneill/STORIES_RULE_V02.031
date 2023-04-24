using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_MEDIA_FILE_2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Media_File_Placeholders;
    public GameObject media_file_placeholders;
    public Transform Main_Parent = null;
    public Transform Temp_Parent = null;


    // ---------------------------------------------------------------- 01a - Begin
    public void OnBeginDrag(PointerEventData eventData)
    {
        media_file_placeholders = Instantiate(Media_File_Placeholders) as GameObject;
        media_file_placeholders.GetComponent<CanvasGroup>().alpha = 0.25f;

        media_file_placeholders.transform.SetParent(this.transform.parent, false); // set to objects old parent // world space or not?

        LayoutElement LE = media_file_placeholders.AddComponent<LayoutElement>();
        LE.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight; // make it the same size as "this"
        LE.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        LE.flexibleWidth = 0;
        LE.flexibleHeight = 0;

        media_file_placeholders.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        Main_Parent = this.transform.parent;
        Temp_Parent = Main_Parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    // ---------------------------------------------------------------- 01b - Begin

    // ---------------------------------------------------------------- 02a - Drag
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = Temp_Parent.childCount;
        for (int i = 0; i < Temp_Parent.childCount; i++)
        {
            if (this.transform.position.y > Temp_Parent.GetChild(i).position.y)
            {
                newSiblingIndex = i;
                if (media_file_placeholders.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        media_file_placeholders.transform.SetSiblingIndex(newSiblingIndex); //  this is the carrot
    }
    // ---------------------------------------------------------------- 02b - Drag

    // ---------------------------------------------------------------- 03a - End
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(Main_Parent);
        this.transform.SetSiblingIndex(media_file_placeholders.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true; // turn back on
        Destroy(media_file_placeholders);
    }
    // ---------------------------------------------------------------- 03a - End

}

