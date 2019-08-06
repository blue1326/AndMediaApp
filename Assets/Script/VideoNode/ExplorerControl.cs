using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerControl : MonoBehaviour
{
    [SerializeField]
    ActiveNodeSender sender = null;
    private void Start()
    {
        sender = FindObjectOfType<ActiveNodeSender>();
    }


    public void SetPath()
    {
        string filename = this.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        string dirname = this.GetComponent<PathData>().path;
        sender.TargetVp.url = dirname+filename;
    }

    public void Clear()
    {
        sender.ClearVideoPlayer();
    }

    public void ReternPage()
    {
        FindObjectOfType<ContentPanelSwaper>().BackToPrevPage();
    }

}
