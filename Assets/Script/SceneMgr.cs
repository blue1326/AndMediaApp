using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : KeepScript
{
    public static GameObject SceneMgrInst = null;
    public override void Awake()
    {
        base.Awake();
        SceneMgrInst = this.gameObject;
    }

    private void Start()
    {
        
    }



    public void LoadScene(int _SceneNo)
    {
        SceneManager.LoadScene(_SceneNo);
    }




    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
