using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyNumer : MonoBehaviour
{

    void Start()
    {
        SetStoryNumber();
    }

    public void SetStoryNumber()
    {
        int theNumberIs = this.transform.GetSiblingIndex();
        //print(this.transform.GetSiblingIndex());
        //print(theNumberIs);

        GameObject Num = this.transform.GetChild(1).gameObject;
        Text NumText = Num.transform.GetComponent<Text>();
        NumText.text = (theNumberIs + 1) .ToString();

        Color object_Color = new Color(

                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );

        this.transform.GetComponent<RawImage>().color = object_Color;


    }
}




