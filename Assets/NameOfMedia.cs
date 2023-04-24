using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameOfMedia : MonoBehaviour
{
    public UMP.UmpScript umpScript;
    public InputField NewNameInput;
    private string MediaNameIs;

    public void GetNameOfMedia()
    {
        MediaNameIs = NewNameInput.text;
        umpScript.MediaNumberBtn(MediaNameIs);

    }


}
