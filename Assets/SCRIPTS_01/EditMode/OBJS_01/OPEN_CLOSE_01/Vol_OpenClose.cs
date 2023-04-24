using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vol_OpenClose : MonoBehaviour
{
    public GameObject volInterface;
    public GameObject volBtn;


    public void POpen()
    {
        // PanelClosed.SetActive(false);
        volInterface.SetActive(true);
        volBtn.SetActive(false);
       // DownBtn.SetActive(true);
    }

    public void PClose()
    {
        // PanelClosed.SetActive(true);
        //PanelOpen.SetActive(false);
        volInterface.SetActive(false);
        volBtn.SetActive(true);
    }



}
