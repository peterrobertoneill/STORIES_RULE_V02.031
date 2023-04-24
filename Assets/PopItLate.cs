using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItLate : MonoBehaviour
{

    public GameObject theBox;
    public GameObject theParent;




    void Start()
    {
        for (int x = 0; x < 7; x++)
        {
            GameObject boxit = Instantiate(theBox) as GameObject;
            boxit.SetActive(true);
            boxit.transform.SetParent(theParent.transform, false);
            //boxit.transform.SetParent(theBox.transform.parent, false);


        }
    }


}

