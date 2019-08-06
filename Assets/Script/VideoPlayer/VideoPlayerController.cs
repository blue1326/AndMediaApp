using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayerController : MonoBehaviour
{
    List<VideoPlayerNode> PlayNodes = null;

    List<VideoPlayerNode> ActivePlayNodes = null;

    private void Awake()
    {
        PlayNodes = new List<VideoPlayerNode>();
        ActivePlayNodes = new List<VideoPlayerNode>();
    }

    public void Enqueue(VideoPlayerNode _node)
    {
        PlayNodes.Add(_node);
    }

    public void ActiveOne()
    {
        VideoPlayerNode node = FindDeactiveNode();
        if(node != null)
        {
            ActivePlayNodes.Add(node);
            node.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("all nodes actived");
        }
    }

    public void DeactiveNode(VideoPlayerNode _node)
    {
        VideoPlayerNode node = null;
        node = ActivePlayNodes.Find(e => e.GetInstanceID() == _node.GetInstanceID());
        node.gameObject.SetActive(false);
        ActivePlayNodes.Remove(_node);
        
    }


    private VideoPlayerNode FindDeactiveNode()
    {
        VideoPlayerNode node = null;
        if (ActivePlayNodes.Count == PlayNodes.Count)
            return null;
        for(int i =0; i< PlayNodes.Count;i++)
        {
            node = ActivePlayNodes.Find(e => e.GetInstanceID() == PlayNodes[i].GetInstanceID());
            if (node == null)
            {
                node = PlayNodes[i];
                break;
            }
        }
        return node;
    }

    
    public void Dequeue(VideoPlayerNode _node)
    {
        VideoPlayerNode tmpnode = null;
        tmpnode =FindNode(_node);
        if (tmpnode != null) 
            PlayNodes.Remove(_node);


    }

    private bool FindNodeAsBool(VideoPlayerNode _node)
    {
        VideoPlayerNode tmpnode = null;
        tmpnode = FindNode(_node);
        if (tmpnode == null)
            return false;
        else
            return true;
    }

    private VideoPlayerNode FindNode(VideoPlayerNode _node)
    {
        //for( int i =0; i<PlayNodes.Count;i++)
        //{
        //    if (PlayNodes[i].GetInstanceID() == _node.GetInstanceID())
        //        return PlayNodes[i];

        //    PlayNodes[i].get
        //}
        //return null;
        return PlayNodes.Find(e => e.gameObject.GetInstanceID() == _node.gameObject.GetInstanceID());
    }

    public void PlayAll()
    {
        for(int i =0; i<ActivePlayNodes.Count;i++)
        {
            ActivePlayNodes[i].Play();
        }
    }
    public void StopAll()
    {
        for (int i = 0; i < ActivePlayNodes.Count; i++)
        {
            ActivePlayNodes[i].Stop();
        }
    }
    public void PauseAll()
    {
        for (int i = 0; i < ActivePlayNodes.Count; i++)
        {
            ActivePlayNodes[i].Pause();
        }
    }





}
