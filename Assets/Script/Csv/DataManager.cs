using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class DataManager : MonoBehaviour
{

    public class CsvReader
    {
        public CsvReader(string _filepath)
        {
            FilePath = _filepath;
            //_txtFile = 
            //byte[] data =  System.IO.File.ReadAllBytes(_filepath);
            FileStream fs = new FileStream(_filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            strData = sr.ReadToEnd();

            Debug.Log(strData);
            sr.Close();
            fs.Close();
            Parse();
        }
        string FilePath = string.Empty;
        string strData = string.Empty;
        string[] parseData;
        
        private void Parse()
        {
            if (strData == string.Empty)
                return;
            MatchCollection matches = Regex.Matches(strData, "\n");

            parseData = strData.Split('\n');
            
            for(int i =0; i<parseData.Length;i++)
            {
                Debug.Log(parseData[i]);
            }

            

            
            
        }
    }



    // Start is called before the first frame update
    private readonly string DataPath = "/Data/";
    private bool isDataExist = false;
    private void Awake()
    {
        //Debug.Log(Application.persistentDataPath+"/Data");
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + DataPath);
        if (di.Exists == false)
        {
            di.Create();
            Debug.Log("foldercreated");
        }
        Debug.Log(Application.persistentDataPath + DataPath);
        string fullpath = Application.persistentDataPath + DataPath;
        string Filename = "trackdata.csv";
        FileInfo fi = new FileInfo(fullpath + Filename);
        isDataExist = fi.Exists;
        Debug.Log(isDataExist);
        if(isDataExist)
        {
            Debug.Log("dataexist");
            CsvReader tmp = new CsvReader(fullpath + Filename);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
