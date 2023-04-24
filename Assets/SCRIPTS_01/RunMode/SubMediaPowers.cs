using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace UMP
{
    public class SubMediaPowers : MonoBehaviour
    {
        public SetMedia setMedia;
        public CamControl camControl;
        //---------data paths--------
        private string imgPathF;
        public FlowTwo flowTwo;
        public ObjTwo objTwo;
        public List<ObjTwo> ObjT;

        // these are both the RawMedia(1) gameObject
        public RawImage rawImage;
        public GameObject SubObjects;
        public GameObject SetMediaObject;
        public RawImage SuperBut_C;
        public RawImage SuperBut_O;
        public RawImage rec;
        public string ReturnImage;

        //

        // Start is called before the first frame update
        void Start()
        {
            //SuperPowers();
        }

        // -- information about SUPERPOWERS 
        // reads lastFlowSaved.json
        // sets variables into text holder -  perhaps we need a text holder for each stage?
        // sets image of first objects at stage 1
        // maybe it should determine ReturnImage for stage 1 ?



        //----------------------------- Path to Flowmedia
        public string dir;
        public string dataPath;
        public string mPath;

        public void MPath() // path to movies
        {
            dir = Application.dataPath;
            dir = System.IO.Directory.GetParent(dir).FullName;
            dir = System.IO.Directory.GetParent(dir).FullName;

            dataPath = dir + "/flowmedia/";
            dataPath = dataPath.Replace('\\', '/');
            //Debug.Log("path = " + dataPath);

            mPath = dataPath;
            //print(mPath);

            //makeTestList.dataPath2 = dataPath;
            //instTestList.dataPath3 = dataPath;
            //objListControl.dataPath4 = dataPath;


        }
    }
}

