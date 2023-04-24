using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //-------other scripts---------------
    public ObjControl objControl;
    public Transform parentToReturnTo = null;
    public Transform placeHolderParent = null;
    public GameObject placeholder = null;
    public GameObject holdPlace;
    public int objOrder;
    public Text objOrderText;
    public UpDateObjs indexOrder;
    public List<int> newOrder;
    public List<GameObject> objs;


    //------------------------------OnBegin Drag-----------------------------

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("OnBeginDrag");

        placeholder = Instantiate(holdPlace) as GameObject;
        //CanvasGroup cg = placeholder.AddComponent<CanvasGroup>();
        //cg.alpha = 0.25f;
        placeholder.GetComponent<CanvasGroup>().alpha = 0.25f;
        placeholder.transform.SetParent(this.transform.parent, false); // set parent to the parent of drag Object - don't forget the false!

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex()); // sets position of placeholder to THIS


        parentToReturnTo = this.transform.parent; // 01 saves old parent as parenttoReturnTo
        placeHolderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent); //re parents to our parent's OUT parent 

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //------------------------------On Drag-----------------------------
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");
        this.transform.position = eventData.position; // moves to mouse position

        if (placeholder.transform.parent != placeHolderParent)
            placeholder.transform.SetParent(placeHolderParent);

        int newSiblingIndex = placeHolderParent.childCount;

        for (int i = 0; i < placeHolderParent.childCount; i++) //-----childcount of parent (how many children attached to parent)
        {
            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x) // if dragged is left of i item
            {
                newSiblingIndex = i;
                //print(placeHolderParent.FindChild)
                //print(placeHolderParent.GetChild(i).name);
                objOrderText.text = (i+1).ToString();

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;
            
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }
    //------------------------------OnEnd Drag-----------------------------

    public void OnEndDrag(PointerEventData eventData)
    {
       // Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
       // LoopSiblingIndex(); // a test to change order number
        Destroy(placeholder);
        if (this.transform.parent.name == "Remove_Media_MenuO")
        {
            Destroy(this.gameObject);
        }
        
    }


    public void LoopSiblingIndex()
    {
        newOrder = new List<int>();

        for (int i = 0; i < placeHolderParent.childCount;  i++)
        {
            print(i);
            //placeHolderParent.GetChild(i).objOrderText.text = (i + 1).ToString();
            //placeholder.GetComponentInParent;

            print("parent - " + parentToReturnTo.GetChild(i).name);

            print("placeH - " + placeHolderParent.GetChild(i).name);


            this.objOrderText.text = i.ToString();

            newOrder.Add(i);
        }
       // UpDateObjs.UpDateOrder();




    }

}