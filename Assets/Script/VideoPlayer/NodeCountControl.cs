using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCountControl : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //GameObject NodeOrigin = null;


    //[SerializeField]
    //Transform Parent = null;
    [SerializeField]
    VideoPlayerController Controller = null;

    private void Start()
    {
        Controller = FindObjectOfType<VideoPlayerController>();
    }


    public void ActivateNode()
    {
        Controller.ActiveOne();
    }
}
