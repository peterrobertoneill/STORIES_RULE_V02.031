using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDot : MonoBehaviour
{
    public GameObject theDot;


    public void POpen()
    {
        // PanelClosed.SetActive(false);
        theDot.SetActive(true);
    }
    public void PClosed()
    {
        // PanelClosed.SetActive(false);
        theDot.SetActive(false);
    }
}
