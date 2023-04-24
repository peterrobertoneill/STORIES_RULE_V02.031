
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VmenuOpenClose : MonoBehaviour
{

    public GameObject PanelOpen;
   // public GameObject PanelClosed;
    public GameObject UpBtn;
    public GameObject DownBtn;
    public GameObject MediaSettingName;




    public void POpen()
    {
       // PanelClosed.SetActive(false);
        PanelOpen.SetActive(true);
        UpBtn.SetActive(false);
        DownBtn.SetActive(true);
        MediaSettingName.SetActive(false);
    }

    public void PClose()
    {
       // PanelClosed.SetActive(true);
        PanelOpen.SetActive(false);
        DownBtn.SetActive(false);
        UpBtn.SetActive(true);
        MediaSettingName.SetActive(true);
    }


}
