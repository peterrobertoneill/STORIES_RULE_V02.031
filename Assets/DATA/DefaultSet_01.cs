using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSet_01 : MonoBehaviour
{
    public List<PresetData> presetDataList = new List<PresetData>();



    public void SetDefault(List<GameObject> editMode)
    {
        // load data

        editMode = new List<GameObject>();

        //--------Clean up
        if (editMode.Count > 0)
        {
            foreach (GameObject editM in editMode)
            {
                Destroy(editM.gameObject);
            }
            editMode.Clear();




        }
    }
}

