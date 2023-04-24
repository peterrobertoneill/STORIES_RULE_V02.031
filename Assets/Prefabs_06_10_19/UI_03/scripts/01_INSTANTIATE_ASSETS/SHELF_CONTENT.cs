using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class SHELF_CONTENT : MonoBehaviour
{
    private Scrollbar theScroll;
    private int scrollSteps;
    public GameObject OBJ_prefab;

    private void Start() // when this appears run these scripts
    {
        //tempOBJs();
        //NumOfSteps_scroll();
    }

    public void NumOfSteps_scroll() // sets up scrollSteps based on the children of CONTENT --- could make a snap or scroll
    {
        theScroll = this.transform.GetChild(1).gameObject.transform.GetComponent<Scrollbar>(); // ----  the ScrollBar
        scrollSteps = this.transform.GetChild(0).gameObject.transform.childCount; // -----------------  CONTENT
        //print(scrollSteps);
        theScroll.numberOfSteps = scrollSteps; // -- might want a way to set this to 0
    }

    public void tempOBJs() // --- temp - script - to Instantiate a random number of stories on an OBJ
    {
        int y = Random.Range(1, 8);
        print("random stories = " + y);

        for (int i = 0; i < y; i++)
        {
            GameObject objPrefab = Instantiate(OBJ_prefab) as GameObject; // -- prefab RAWIMAGE_STORY is used.
            objPrefab.SetActive(true);
            objPrefab.transform.SetParent(this.transform.GetChild(0), false);
        }
    }

    public void Add_OBJ()
    {
        GameObject objPrefab = Instantiate(OBJ_prefab) as GameObject; // -- prefab RAWIMAGE_STORY is used.
        objPrefab.SetActive(true);
        objPrefab.transform.SetParent(this.transform.GetChild(0), false);
    }

}
