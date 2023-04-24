using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ObjTwo
{
    public int JOrder { get; set; }
    public string JName { get; set; }
    public float JVol { get; set; }

}

[System.Serializable]
public class FlowPreset
{
    public string FlowPresetName; // { get; set; }
}

[System.Serializable]
public class LastPreset
{
    public string LastPresetName; // { get; set; }
}



[System.Serializable]
public class PresetList
{
    public List<Presets> shPre { get; set; }

}

// -----------------------------------------
// -----------------------------------------

[System.Serializable]
public class Presets
{
    public List<string> shelfPresets; 
}



[System.Serializable]
public class LastSaved
{
    public List<string> lastPreset; 

}

[System.Serializable]
public class LastFlowSaved
{
    public List<string> lastFlowPreset; // <-- I think we are using this one

}



[System.Serializable]
public class FlowTwo
{
    public List<ObjTwo> ObjT { get; set; }
}


// -----------------------------------------
// -----------------------------------------

[System.Serializable]
public class HomeTree
{
    //public string fName;
    public List<Branch> branch;// { get; set;}

}

[System.Serializable]
public class Branch
{
    //public string fName;
    public string ObjName;
    public int objOrder;
    public List<SubLeaf> subLeaf;// { get; set;}
    

}

[System.Serializable]
public class SubLeaf
{
    //public enum enMediaType {mp4, mpg, mp3, aif};
    public int RunOrder; //
    public int JOrder;
    public string JName;
    public float JVol; //

    // video
    public bool v_ON;
    public bool v_CLOSE;
    public bool v_HOLD;
    public bool v_LOOP;
    public string v_IMAGEFILE;
    public string v_IMAGEFILE_END;
    public float v_VOL; //
    public float v_FADE_IN; // <---
    public float v_FADE_OUT; // <---

    // image
    public bool i_ON;
    public bool i_HOLD;
    public float i_HOLD_TIME; //
    public string i_IMAGEFILE;

    // audio
    public bool a_ON;
    public bool a_OVER;
    public bool a_AFTER;
    public float a_FADE_IN; //
    public float a_FADE_OUT; //
    public string a_AUDIOFILE;
    public float a_VOL;
    public float A_FADE_IN_TIME;
    public float A_FADE_OUT_TIME;

    public int a_CUES;
    public float a_SECONDS;

    //public float v_FADE_IN_TIME;
    //public float v_FADE_OUT_TIME;
    //public float A_FADE_IN_TIME;
    //public float A_FADE_OUT_TIME;
    //public float i_HOLD_TIME;


}
// -----------------------------------------
// -----------------------------------------