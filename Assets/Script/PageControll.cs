using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageControll : MonoBehaviour
{
    [SerializeField]
    string PageKey = null;

    [SerializeField]
    int[] pageFlag = null;

    [SerializeField]
    PageMgr pageMgr = null;


    private void Awake()
    {
        pageMgr = FindObjectOfType<PageMgr>();
        if(PageKey == null)
        {
            Debug.LogError("insert pageKey");
        }
        if(pageFlag == null)
        {
            Debug.LogError("insert pageFlag Infomations");
        }
        pageMgr.SetPageControll(this, PageKey);
    }

    public void CallSwitchPage(int _idx)
    {
        if (pageMgr)
            pageMgr.SwitchPage(pageFlag[_idx]);
    }
    public void BackToPrevPage()
    {
        if (pageMgr)
            pageMgr.SwitchPrevPage();
    }
    public void BackToHomePage()
    {
        if (pageMgr)
            pageMgr.SwitchHomePage();
    }
}
