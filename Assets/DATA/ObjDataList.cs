using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjDataList
{
    public enum objType {video, still, audio};
    public int objOrder;
    public string objName;
    public string objTexture;
    public float objVol;
}
