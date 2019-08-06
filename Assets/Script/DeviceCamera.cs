using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.XR.WSA.WebCam;

public class DeviceCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private WebCamTexture frontCam;
    private Texture defBG;

    public RawImage BG;
    public AspectRatioFitter fit;

    public Text debugText;

    //private VideoCapture test;

    private void Start()
    {
        
        defBG = BG.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("no cam detected");
            camAvailable = false;
            return;
        }

        debugText.text = "";//devices.Length.ToString();
        for(int i =0; i <devices.Length; i++)
        {
            if(!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                
            }
            if (devices[i].isFrontFacing)
            {
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
            debugText.text += devices[i].name + $" -{i}- ";
        }

        if(backCam ==null)
        {
            Debug.Log("unable to find back cam");
            return;
        }

        //backCam.Play();
        frontCam.Play();
        
        BG.texture = frontCam;//backCam;

        camAvailable = true;

    }

    private void Update()
    {
        if(!camAvailable)
         return;

        //float ratio = (float)backCam.width / (float)backCam.height;
        //fit.aspectRatio = ratio;

        //float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;

        //BG.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        //int orient = -backCam.videoRotationAngle;
        //BG.rectTransform.localEulerAngles = new Vector3(0, 0, orient);


        float ratio = (float)frontCam.width / (float)frontCam.height;
        fit.aspectRatio = ratio;

        float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;

        BG.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -frontCam.videoRotationAngle;
        BG.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
