using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]
public class SoundAnalyzer : MonoBehaviour
{
    private AudioSource aud = null;
    public bool isRunning = false;

    [SerializeField]
    float sensitivity = 1000;


    //Coroutine analyzer = null;
    float[] SpectrumData = null;
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        SpectrumData = new float[256];
    }
    public void StartRecord()
    {
        int min = new int();
        int max = new int();
        Microphone.GetDeviceCaps(Microphone.devices[0], out min, out max);
        Debug.Log($"freqMin : {min},  freqMax : {max}");


        aud.clip = Microphone.Start(Microphone.devices[0], true, 1, 44100);
        aud.loop = true;
        aud.Play(0);
        isRunning = true;
        //aud.mute = true;
        //analyzer = StartCoroutine(AnalyzeSound());
    }
    public void StopRecord()
    {
        Microphone.End(Microphone.devices[0]);
        //StopCoroutine(analyzer);
        isRunning = false;
    }

    public bool isClap = false;

    public bool GetClap()
    {
        bool clap = false;
        aud.GetOutputData(SpectrumData, 0);
        if (AvgVolume() * sensitivity > 1)
        {
            clap = true;
            Debug.Log(AvgVolume()*sensitivity);
        }
        return clap;
    }


    //IEnumerator AnalyzeSound()
    //{
        
        
    //    while (true)
    //    {
            
    //        //aud.GetSpectrumData(SpectrumData, 0, FFTWindow.BlackmanHarris);
    //        aud.GetOutputData(SpectrumData, 0);
    //        if (AvgVolume() * sensitivity > 1)
    //        {
    //            isClap = true;
    //            Debug.Log("Clap");
    //            yield return new WaitForSeconds(0.1f);
    //            isClap = false;
    //        }
    //        yield return null;
    //        //isClap = false;
    //        //SpectrumData = aud.GetSpectrumData
    //    }
    //}
    private float AvgVolume()
    {
        float avg = 0;
        for (int i =0; i<SpectrumData.Length;i++)
        {
            avg += Mathf.Abs(SpectrumData[i]);
        }
       // Debug.Log($"avg { avg / SpectrumData.Length*100}");
        return avg / SpectrumData.Length;
    }
}
