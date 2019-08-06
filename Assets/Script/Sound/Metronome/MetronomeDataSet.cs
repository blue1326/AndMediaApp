using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MusicalTool
{
    public class MetronomeDataSet : MonoBehaviour
    {



        //private BeatData.BeatDatas BData = BeatData.BeatDatas.BD_None;


        //[SerializeField]
        [SerializeField]
        private NoteHolder Nholder = null;
        [SerializeField]
        private BpmData bpmData = null;
        [SerializeField]
        private BeatData beatData = null;
        [SerializeField]
        private BeatMode beatMode= null;
        //public BeatData.BeatDatas beatdata
        //{
        //    get => BData;
        //    set {

        //        BData = value;
        //        if(Nholder != null)
        //        {
        //            Nholder.SetNotes(BData);
        //        }
        //    }
        //}
        
        public void Tick()
        {
            Nholder.Tick();
        }


        public BeatMode.MetronomeMode GetMode()
        {
            return beatMode.Mode;
        }

        public float GetBpmData()
        {
            if (bpmData)
                return bpmData.GetBpmData();
            else
                return 0;
        }
        public float GetBeatDataDeno()
        {
            if (beatData)
                return beatData.GetBeatDataDeno();
            else
                return 0;
        }
        public float GetBeatDataNumer()
        {
            if (beatData)
                return beatData.GetBeatDataNumer();
            else
                return 0;
        }

        public void ResetNote()
        {
            if (Nholder)
                Nholder.Reset();
        }



        private void Awake()
        {
            Nholder = FindObjectOfType<NoteHolder>();
            bpmData = FindObjectOfType<BpmData>();
            beatData = FindObjectOfType<BeatData>();
            beatMode = FindObjectOfType<BeatMode>();
        }
        
        
 
    }
}

