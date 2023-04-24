using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Content_to_Edit : MonoBehaviour
{
    private Transform CONTENT_obj_list;
    public GameObject Media_file;

    public void AddMedia()
    {
        // random color
        Color MediaColor = new Color(

                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );

        CONTENT_obj_list = this.transform.GetChild(0);

        // Instantiate media_file
        GameObject media_file = Instantiate(Media_file) as GameObject;
        media_file.SetActive(true);
        media_file.transform.SetParent(CONTENT_obj_list, false);

        // apply colore from OBJ to Media_files
        RawImage Media_Reader = media_file.transform.GetChild(0).GetComponent<RawImage>();
        Media_Reader.color = MediaColor;


    }







}
