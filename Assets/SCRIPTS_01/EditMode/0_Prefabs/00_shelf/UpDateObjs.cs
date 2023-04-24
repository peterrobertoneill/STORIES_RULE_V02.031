using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDateObjs : MonoBehaviour
{
    public List<ObjData> objDataList = new List<ObjData>();
    public int indexOrder;
    public Text orderText;
    public List<int> newOrder;



    public void UpDateOrder()
    {
        foreach (int theOrder in newOrder)
        {
            print(theOrder);


        }






    }



}
