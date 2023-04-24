using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusOpenClose : MonoBehaviour
{
    public GameObject openState;
    public GameObject closedState;
    private int open_close;


  /*  public void Update()
    {
        Keyed();
    }
    public void Keyed()
    {
      
        if (Input.GetKey(KeyCode.F3)) // timeline bar on
        {
            POpen();
        }

        if (Input.GetKey(KeyCode.F4))  //  off
        {
            PClosed();
        }

    }*/

    public void POpen()
    {
        // PanelClosed.SetActive(false);
        openState.SetActive(true);
        closedState.SetActive(false);
    }
    public void PClosed()
    {
        // PanelClosed.SetActive(false);
        openState.SetActive(false);
        closedState.SetActive(true);
    }

}
