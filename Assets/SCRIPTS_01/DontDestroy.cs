using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public GameObject EditMode;
    public GameObject ButtonName;
    public ObjControl objControl;


    // Start is called before the first frame update
    void Start()
    {
        //objControl.BuildObjList();
        //objControl.LoadPresets();
        //DontDestroyOnLoad(gameObject);

    }

    public void LoadRunner1()
    {
        EditMode.SetActive(false);
        SceneManager.LoadScene("Runner_1r");
    }

    public void LoadRunner2()
    {
        EditMode.SetActive(false);
        SceneManager.LoadScene("Runner_3c");
    }

    public void LoadRunner3()
    {
        EditMode.SetActive(false);
        SceneManager.LoadScene("Runner_6c");
    }

   


    // Update is called once per frame

}
