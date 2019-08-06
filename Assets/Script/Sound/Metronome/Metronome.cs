using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalTool;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{
    private MetronomeDataSet _dataSet;
    // Start is called before the first frame update
    

    [SerializeField]
    float TickTime = 0;


    float timeacc;
    float prevtime;

    [SerializeField]
    BeatMode.MetronomeMode mode = BeatMode.MetronomeMode.LEARN;

    [SerializeField]
    float bpm = 0;

    [SerializeField]
    float DenoValue = 0;

    [SerializeField]
    bool isPlay = false;

    [SerializeField]
    SoundAnalyzer SAnalyzer = null;

    [SerializeField]
    Image decisionimage = null;
    Color defColor = default;
    Color correctColor = default;
    Color wrongColor = default;

    private float DenominatorValue(float value)
    {
        float Dvalue = 0;
        switch (value)
        {
            case 4:
                Dvalue = 1;
                break;
            case 8:
                Dvalue = 0.5f;
                break;
            default:
                break;
        }
        return Dvalue;
    }



    Coroutine cor = null;
    IEnumerator StartMetronome()
    {
        while (true)
        {
            timeacc += Time.time - prevtime;

            //Debug.Log($"acc : {timeacc}");
            //Debug.Log($"prev : {prevtime}");
            if (timeacc >= TickTime - 0.15f)
                StartCoroutine(StartVolumeTest(0.3f));
            
            if (timeacc >= TickTime)
            {
                Tick();
                timeacc = 0;
            }
            prevtime = Time.time;
            yield return null;
            //yield return new WaitForSeconds(TickTime);
        }
    }

    IEnumerator StartBeatTesting()
    {
        while (true)
        {
            timeacc += Time.time - prevtime;

            //Debug.Log($"acc : {timeacc}");
            //Debug.Log($"prev : {prevtime}");
            if (timeacc >= TickTime - 0.15f)
                StartCoroutine(StartVolumeTest(0.3f));

            if (timeacc >= TickTime)
            {
                Tick();
                timeacc = 0;
            }
            prevtime = Time.time;
            yield return null;
            //yield return new WaitForSeconds(TickTime);
        }
    }


    float tacc = 0;
    float preTime = 0;
    IEnumerator StartVolumeTest(float _Ticktime)
    {
        Debug.Log("vteston");
        preTime = 0;
        while(true)
        {
            tacc += Time.time - preTime;
            if (mode == BeatMode.MetronomeMode.TEST && SAnalyzer.GetClap() == true)
            {
                decisionimage.color = correctColor;
                Debug.Log("CLAP!!!");
                yield break;
            }
            else if(mode == BeatMode.MetronomeMode.TEST && SAnalyzer.GetClap() == false)
            {
                decisionimage.color = wrongColor;
                yield break;
            }

            if (tacc >= _Ticktime)
            {
                
                Debug.Log("vtestoff");
                tacc = 0;
                
                yield break;
            }
            preTime = Time.time;
            yield return null;
        }
    }

    IEnumerator DurationHalfSec()
    {
        Debug.Log("det");
        bool res = false;
        //Coroutine detect = StartCoroutine(DetectClap(res));
        yield return new WaitForSeconds(0.2f);
        if (res) Debug.Log("fast");
        yield return new WaitForSeconds(0.1f);
        if (res) Debug.Log("correct");
        yield return new WaitForSeconds(0.2f);
        if (res) Debug.Log("late");
        SAnalyzer.isClap = false;
        //StopCoroutine(detect);
    }

    //IEnumerator DetectClap(bool result)
    //{
        
    //    while(true)
    //    {
    //        result = SAnalyzer.isClap;
    //        yield return null;
    //    }
    //}

    private void Awake()
    {
        _dataSet = FindObjectOfType<MetronomeDataSet>();
        SAnalyzer = GetComponent<SoundAnalyzer>();
        //decisionimage.color = new Color(1, 1, 1);
        defColor = new Color(1, 1, 1);
        correctColor = new Color(0, 1, 0);
        wrongColor = new Color(1, 0, 0);
    }


    private void Tick()
    {
        _dataSet.Tick();
    }




    public void SwitchOnOff()
    {
        if (cor == null) //on
        {
            isPlay = true;
            SetUpDatas();
            if (mode == BeatMode.MetronomeMode.TEST)
                SAnalyzer.StartRecord();
            prevtime = 0;
            timeacc = 0;
            TickTime = (60 / bpm) * DenominatorValue(DenoValue);
            cor = StartCoroutine(StartMetronome());
        }
        else //off
        {
            isPlay = false;
            _dataSet.ResetNote();
            if (SAnalyzer.isRunning)
                SAnalyzer.StopRecord();

            decisionimage.color = defColor;
            StopCoroutine(cor);
            cor = null;

        }
    }

    public void SetUpDatas()
    {
        bpm = _dataSet.GetBpmData();
        DenoValue = _dataSet.GetBeatDataDeno();
        mode = _dataSet.GetMode();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isPlay)
        //{
            
        //    //SetUpDatas();
        //}
    }
}
