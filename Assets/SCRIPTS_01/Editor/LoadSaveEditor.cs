using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class LoadSaveEditor : EditorWindow
{
    public DefaultData defaultData;
    public S00_presets s00_presets;

    string dir;
    string mainDataPath;
    private string dataFileName = "default.json";
    Vector2 scrollPos;

    //-------------SetUp GUI Editor-------------
    [MenuItem("Window/Main Data Editor")]
    static void Init()
    {
        LoadSaveEditor window = (LoadSaveEditor)EditorWindow.GetWindow(typeof(LoadSaveEditor));
        window.Show();
    }
    private void OnGUI()
    {   //-----------scrollbar
        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);

        //-----save data or load data
        if (s00_presets != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("s00_presets");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties(); //update with any changes made

            if (GUILayout.Button("save"))
            {
                SaveObjData();
            }

        }
        if (GUILayout.Button ("load"))
        {
            LoadObjData();
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();

    }

    //---------------------load----------------------
    private void LoadObjData()
    {
        MainDataPath();  //== set path

        string filePath = mainDataPath + dataFileName;
        if(File.Exists (filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            s00_presets = JsonUtility.FromJson<S00_presets>(dataAsJson);

            Debug.Log("loaded data file - " + dataFileName);
        }
        else
        {
            s00_presets = new S00_presets(); //---creat new Data
        }
    }


    //---------------------save----------------------
    private void SaveObjData()
    {
        MainDataPath();  //-- set path method

        string dataAsJson = JsonUtility.ToJson(s00_presets);
        string filePath = mainDataPath + dataFileName;
        File.WriteAllText(filePath, dataAsJson);
        Debug.Log("Saved data file as - " + dataFileName);
    }


    //----------------------set path-----------------
    public void MainDataPath()
    {
        dir = Application.dataPath;
        dir = Directory.GetParent(dir).FullName;
        dir = Directory.GetParent(dir).FullName;
        mainDataPath = dir + "/media/data/";
        mainDataPath = mainDataPath.Replace('\\', '/');
    }
}
