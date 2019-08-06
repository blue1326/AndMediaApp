using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class FileFinder : MonoBehaviour
{
    string DataPath = null;
    [SerializeField]
    string FolderPath = null;

    DirectoryInfo di = null;
    FileInfo[] fileinfo = null;
    DirectoryInfo[] directoryInfo = null;
    [SerializeField]
    GameObject ContentHolder = null;
    [SerializeField]
    GameObject ContentBtn = null;
    

    List<GameObject> instantContents = null;
    private void Awake()
    {
        instantContents = new List<GameObject>();
        DataPath = Application.persistentDataPath;
        CheckLastSlash(ref DataPath);
        CheckLastSlash(ref FolderPath);
        
        DirectoryCheck(DataPath + FolderPath);
    }

    private void CheckLastSlash(ref string _str)
    {
        if (string.IsNullOrEmpty(_str) == false)
        {
            if (_str.Substring(_str.Length) != "/")
            {
                _str += "/";
            }
        }
    }

    private void DirectoryCheck(string _path)
    {
        if (Directory.Exists(_path))
        {
            di = new DirectoryInfo(DataPath + FolderPath);
        }
        else
        {
            
            di = new DirectoryInfo(DataPath + FolderPath);
            di.Create();
        }
    }


    private void OnEnable()
    {
        di.Refresh();
        directoryInfo = di.GetDirectories();
        fileinfo = di.GetFiles();
        Debug.Log(directoryInfo);
        Debug.Log(fileinfo[0].Name);
        //Debug.Log(DataPath + FolderPath);
        if (ContentBtn == null)
            return;
        if (ContentHolder == null)
        {
            GameObject obj = null;
            int i = 0;
            for (i = 0; i < directoryInfo.Length; i++)
            {
                obj = GameObject.Instantiate(ContentBtn);
                obj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = directoryInfo[i].Name;
                obj.AddComponent<PathData>().path = DataPath + FolderPath;
                instantContents.Add(obj);
            }
            for (i = 0; i < fileinfo.Length; i++)
            {
                obj = GameObject.Instantiate(ContentBtn);
                obj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = fileinfo[i].Name;
                obj.AddComponent<PathData>().path = DataPath + FolderPath;
                instantContents.Add(obj);
            }
        }
        else
        {
            GameObject obj = null;
            int i = 0;
            for (i = 0; i < directoryInfo.Length; i++)
            {            
                obj = GameObject.Instantiate(ContentBtn, ContentHolder.transform);
                obj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = directoryInfo[i].Name;
                obj.AddComponent<PathData>().path = DataPath + FolderPath;
                instantContents.Add(obj);
            }
            for (i = 0; i < fileinfo.Length; i++)
            {
                obj = GameObject.Instantiate(ContentBtn, ContentHolder.transform);
                obj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = fileinfo[i].Name;
                obj.AddComponent<PathData>().path = DataPath + FolderPath;
                instantContents.Add(obj);
            }
            
        }
        //ContentBtn
    }
    private void OnDisable()
    {
        for( int i =0; i<instantContents.Count;i++)
        {
            GameObject.Destroy(instantContents[i]);
        }
    }
}
