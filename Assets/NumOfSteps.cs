using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumOfSteps : MonoBehaviour
{
    private Scrollbar theScroll;
    private int scrollSteps;
    public GameObject RAWIMAGE_STORY_prefab;

    private void Start()
    {
        tempStories();
        NumOfSteps_scroll();
    }

    public void NumOfSteps_scroll()
    {
        theScroll = this.transform.GetChild(1).gameObject.transform.GetComponent<Scrollbar>();
        scrollSteps = this.transform.GetChild(0).gameObject.transform.childCount;
        //print(scrollSteps);
        theScroll.numberOfSteps = scrollSteps;

    }


    public void tempStories()
    {
        int y = Random.Range(1, 15);
        print("random stories = " + y);

        for (int i = 0; i < y; i++)
        {
            GameObject rawimageStoryPrefab = Instantiate(RAWIMAGE_STORY_prefab) as GameObject;
            rawimageStoryPrefab.SetActive(true);
            rawimageStoryPrefab.transform.SetParent(this.transform.GetChild(0), false);
        }


    }

}
