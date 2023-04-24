using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyObjData
{
    public enum objType { video, still, audio };
    public int objOrder;
    public string objName;
    public float objVol;
    //public int shelfIndex;

    public MyObjData(int obOrder, string obName, float obVol)
    {
        objOrder = obOrder;
        objName = obName;
        objVol = obVol;
    }


}
