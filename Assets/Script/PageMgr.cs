using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SceneLoader))]
public class PageMgr : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Objects;

    public GameObject[] objects { get => Objects; set => Objects = value; }

    Dictionary<string, PageControll> controldic;

    private void Awake()
    {
        controldic = new Dictionary<string, PageControll>();
    }

    private bool isSetup = false;
    public bool IsSetup { set => isSetup = value; }


    Stack<GameObject> prevPages = null;
    //private GameObject prevPage = null;

    private GameObject activePage = null;
    public void InitPageCondition()
    {
        if(isSetup)
        {
            activePage = Objects[0];
            for(int i =1; i<Objects.Length;i++)
            {
                objects[i].SetActive(false);
            }
        }
    }

    public void SwitchPage(int _idx)
    {
        activePage.SetActive(false);

        if (prevPages == null)
            prevPages = new Stack<GameObject>();

        prevPages.Push(activePage);
        activePage = Objects[_idx];
        activePage.SetActive(true);
    }


    public void SwitchPrevPage()
    {
        if (prevPages == null || prevPages.Count == 0)
            return;
        activePage.SetActive(false);
        activePage = prevPages.Pop();
        activePage.SetActive(true);
    }

    public void SwitchHomePage()
    {
        activePage.SetActive(false);
        activePage = Objects[0];
        activePage.SetActive(true);
        prevPages.Clear();
    }

    public void SetPageControll(PageControll _controll,string _key)
    {
        if(!controldic.ContainsKey(_key))
            controldic.Add(_key, _controll);
    }



}
