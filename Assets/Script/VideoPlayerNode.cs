using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(RawImage))]
public class VideoPlayerNode : MonoBehaviour
{
    public RenderTexture InstanceTex = null;

    [SerializeField]
    RenderTexture ViewTex = null;
    [SerializeField]
    VideoPlayer VP = null;

    [SerializeField]
    RawImage ViewImg = null;

    //[SerializeField]
    //Button btn_Delete = null;
    //[SerializeField]
    //Button btn_Change = null;
    //[SerializeField]
    //Button btn_New = null;


    [SerializeField]
    VideoPlayerController VPController = null;
    //[SerializeField]
    ////VideoPlayerController VController = null;
    //ActiveNodeSender NodeSender = null;
    //[SerializeField]
    //ContentPanelSwaper PanelSwaper = null;
    [SerializeField]
    ActiveNodeSender NodeSender = null; 
    [SerializeField]
    bool isOn = true;

    public void ToggleEnablePlay(bool _val)
    {
        isOn = _val;
    }
    //[SerializeField]
    //Button btn = null;

    private void Awake()
    {
        SetUpDataPath();
        if (InstanceTex)
        {
            ViewTex = Object.Instantiate<RenderTexture>(InstanceTex);
        }
        else
            Debug.Log("Set Render Texture!");

        
    }

    public void SetTargetVP()
    {
        NodeSender.SetTargetVideoPlayer(VP);
    }


    private void Start()
    {
        NodeSender = FindObjectOfType<ActiveNodeSender>();
        VPController = FindObjectOfType<VideoPlayerController>();
        VPController.Enqueue(this);
        Debug.Log("set!");
        this.gameObject.SetActive(false);
    }


    public void SetDeactive()
    {
        Destroy(VP);
        VPController.DeactiveNode(this);
    }

    private void OnEnable()
    {
        VP = this.GetComponent<VideoPlayer>();
        if (VP != null)
        {
            SetUpVideoPlayer();
        }
        else
        {
            VP = this.gameObject.AddComponent<VideoPlayer>();
            SetUpVideoPlayer();
        }
        ViewImg = this.GetComponent<RawImage>();
        if(ViewImg != null)
        {
            SetUpViewImg();
        }
        else
        {
            ViewImg = this.gameObject.AddComponent<RawImage>();
            SetUpViewImg();
        }
       // NodeSender = FindObjectOfType<ActiveNodeSender>();

       // PanelSwaper = FindObjectOfType<ContentPanelSwaper>();

    }


    void test()
    {

    }
    void SetUpVideoPlayer()
    {
        VP.renderMode = VideoRenderMode.RenderTexture;
        VP.targetTexture = ViewTex;
        VP.playOnAwake = false;
        
    }

    void SetUpViewImg()
    {
        ViewImg.texture = ViewTex;
    }

    public void Play()
    {
        if(!string.IsNullOrEmpty(VP.url)&&isOn)
            VP.Play();
    }
    public void Stop()
    {
        VP.Stop();
    }
    public void Pause()
    {
        VP.Pause();
    }

    

    string DataPath = "";
    string FilePath = "";

    void SetUpDataPath()
    {
        DataPath = Application.persistentDataPath;
        FilePath= "/Video/";
    }


    public void LoadVideoClip_Test()
    {
        DirectoryInfo di = new DirectoryInfo(DataPath+FilePath);
        if (di.Exists == false)
        {
            //di.Create();
            //Debug.Log("foldercreated");
            //ColorBlock tmp = btn.colors;
            //tmp.normalColor = new Color(1, 0, 0);
            //btn.colors = tmp;
        }
        string path = DataPath + FilePath + "test3.mp4";
        VP.source = VideoSource.Url;
        VP.url = path;
        Play();


    }


    public void VolumeSliderValueChange(float _value)
    {
        VP.SetDirectAudioVolume(0, _value);
    }
}
