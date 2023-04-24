using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempObjSetUp : MonoBehaviour
{

    public GameObject OBJ_prefab; // -- set up random OBJECTS on SHELF  ... for testing

    void Start()
    {
        int y = Random.Range(1, 4); // -- random range
        print("random objs = " + y);

        for (int i = 0; i < y; i++) // -- loop through random number
        {
            GameObject objPrefab = Instantiate(OBJ_prefab) as GameObject;
            objPrefab.SetActive(true);
            objPrefab.transform.SetParent(this.transform, false);  // -- Instantiate the prefab OBJ(ObjTemp_it)
        }

    }

}
