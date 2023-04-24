using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OBJ_CONTENT : MonoBehaviour
{
    /// <summary>
    ///  ---------------- on - OBJ - MASK_obj
    /// </summary>
    private Scrollbar theScroll;
    private int scrollSteps;
    public GameObject RAWIMAGE_STORY_prefab;

    private void Start() // when this appears run these scripts
    {
        tempStories();
        NumOfSteps_scroll();
    }

    public void NumOfSteps_scroll() // sets up scrollSteps based on the children of CONTENT --- could make a snap or scroll
    {
        theScroll = this.transform.GetChild(1).gameObject.transform.GetComponent<Scrollbar>(); // -- the ScrollBar
        scrollSteps = this.transform.GetChild(0).gameObject.transform.childCount; // -- CONTENT
        //print(scrollSteps);
        theScroll.numberOfSteps = scrollSteps; // -- might want a way to set this to 0
    }

    public void tempStories() // --- temp - script - to Instantiate a random number of stories on an OBJ
    {
        int y = Random.Range(1, 5);
        print("random stories = " + y);

        for (int i = 0; i < y; i++)
        {
            GameObject rawimageStoryPrefab = Instantiate(RAWIMAGE_STORY_prefab) as GameObject; // -- prefab RAWIMAGE_STORY is used.
            rawimageStoryPrefab.SetActive(true);
            rawimageStoryPrefab.transform.SetParent(this.transform.GetChild(0), false);
        }
    }
}
