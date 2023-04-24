using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HOLDER_CONTENT : MonoBehaviour
{
    private Scrollbar theScroll;
    private int scrollSteps;
    public GameObject SHELF_prefab;

    private void Start() // when this appears run these scripts
    {
        //tempSHELVES();
       // NumOfSteps_scroll();
    }

    public void NumOfSteps_scroll() // sets up scrollSteps based on the children of CONTENT --- could make a snap or scroll
    {
        theScroll = this.transform.GetChild(1).gameObject.transform.GetComponent<Scrollbar>(); // ----  the ScrollBar
        scrollSteps = this.transform.GetChild(0).gameObject.transform.childCount; // -----------------  CONTENT

        //print(scrollSteps);
        theScroll.numberOfSteps = scrollSteps; // -- might want a way to set this to 0
    }

    public void tempSHELVES() // --- temp - script - to Instantiate a random number of stories on an OBJ
    {
        int y = Random.Range(1, 8);
        print("random stories = " + y);

        for (int i = 0; i < y; i++)
        {
            GameObject shelfPrefab = Instantiate(SHELF_prefab) as GameObject; // -- prefab RAWIMAGE_STORY is used.
            shelfPrefab.SetActive(true);
            shelfPrefab.transform.SetParent(this.transform.GetChild(0), false);
        }
    }

    public void Add_Shelf()
    {
        GameObject shelfPrefab = Instantiate(SHELF_prefab) as GameObject;
        shelfPrefab.SetActive(true);
        shelfPrefab.transform.SetParent(this.transform.GetChild(0), false);
        shelfPrefab.transform.SetSiblingIndex(0);

    }
}
