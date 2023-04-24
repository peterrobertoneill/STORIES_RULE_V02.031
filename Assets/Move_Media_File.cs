using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Media_File : MonoBehaviour
{

    public GameObject Shelf_Box;

    public void MoveThis()
    {
        this.transform.SetSiblingIndex(0);
        Shelf_Box.transform.SetSiblingIndex(0);
    }


}
