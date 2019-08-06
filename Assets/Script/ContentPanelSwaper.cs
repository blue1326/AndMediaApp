using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPanelSwaper : MonoBehaviour
{
    [SerializeField]
    GameObject[] contentPanels = null;

    [SerializeField]
    int DefaultPanelIdx = 0;
    int ActivePanelIdx = 0;


    [SerializeField]
    PageControll pagecontrol = null;

    


    //bool BackBtnState = false;

    private void Awake()
    {
        if(contentPanels.Length !=0)
        {
            for(int i =0; i<contentPanels.Length;i++)
            {
                if (i == DefaultPanelIdx)
                {
                    contentPanels[i].SetActive(true);
                    ActivePanelIdx = i;
                }
                else
                    contentPanels[i].SetActive(false);
            }
        }
    }

    private void Start()
    {
        //if (pagecontrol != null)
        //{
        //    BackBtnState = true;
        //}
    }


    public void ChangeActivePage(int _idx)
    {
        contentPanels[ActivePanelIdx].SetActive(false);
        contentPanels[_idx].SetActive(true);
        ActivePanelIdx = _idx;
    }

    public void BackToPrevPage()
    {
        if (pagecontrol == null)
            return;
        if(ActivePanelIdx == DefaultPanelIdx)
        {
            pagecontrol.BackToPrevPage();
        }
        else
        {
            contentPanels[ActivePanelIdx].SetActive(false);
            contentPanels[DefaultPanelIdx].SetActive(true);
            ActivePanelIdx = DefaultPanelIdx;
        }
           
    }






    public void SwapActivePanel(int _idx)
    {

    }
}
