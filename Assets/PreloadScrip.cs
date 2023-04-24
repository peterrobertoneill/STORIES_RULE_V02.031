using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreloadScrip : MonoBehaviour
{
    public GameObject PreLoadScreen;

    public void RunIt()
    {
          
        SceneManager.LoadScene("EditMode");

    }


    public void Poneill()
    {
        Application.OpenURL("https://poneill.co/thelab/");
    }


    public void Manual()
    {
        Application.OpenURL("https://paper.dropbox.com/doc/Flowject-Manual-V02.09--ArstGuDcopoHNTvfvAMb1KBIAg-C8qFy6qnfFsfKTIlLUvjM");
    }

}
