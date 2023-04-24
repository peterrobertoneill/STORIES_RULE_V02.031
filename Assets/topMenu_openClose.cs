using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topMenu_openClose : MonoBehaviour
{
    public GameObject Open_State;

    public void POpen()
    {
        if(Open_State.activeSelf == false)
            Open_State.SetActive(true);
        else
            Open_State.SetActive(false);

    }


}
