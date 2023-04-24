using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EditSettings : MonoBehaviour //open and close Settings
{

    public GameObject _SettingOpen;
    public GameObject _addMedia;
    public GameObject _enter;
    public GameObject RefreshOne;
    public GameObject RefreshTwo;
    public GameObject DeletButton;




    public void OpenSettings()
    {
        DeletButton.SetActive(false);
        _SettingOpen.SetActive(true);
       // _addMedia.SetActive(false);
       // _enter.SetActive(false);

        Canvas.ForceUpdateCanvases(); // refresh UI
        RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
        RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;

        RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
        RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;
    }

    public void CloseSettings()
    {
        DeletButton.SetActive(true);
        _SettingOpen.SetActive(false);
        //_addMedia.SetActive(true);
        //_enter.SetActive(true);

        Canvas.ForceUpdateCanvases();// refresh UI
        RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
        RefreshOne.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;

        RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false;
        RefreshTwo.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;


    }


}
