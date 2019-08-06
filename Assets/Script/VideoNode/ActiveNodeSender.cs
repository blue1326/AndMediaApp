using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActiveNodeSender : MonoBehaviour
{
    [SerializeField]
    VideoPlayer targetVp = null;

    public VideoPlayer TargetVp { get => targetVp;}

    public void SetTargetVideoPlayer(VideoPlayer _vp)
    {
        targetVp = _vp;
    }

    public void ClearVideoPlayer()
    {
        targetVp = null;
    }
}
