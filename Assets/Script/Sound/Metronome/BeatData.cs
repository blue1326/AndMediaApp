using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MusicalTool
{
    public class BeatData : MonoBehaviour
    {
        private DataStructure.CircularList<string> CList;
        [SerializeField]
        private TMPro.TextMeshProUGUI text = null;

        [SerializeField]
        private NoteHolder noteholder = null;
        private void Awake()
        {
            CList = new DataStructure.CircularList<string>();
            CList.Enqueue("2/4");
            CList.Enqueue("3/4");
            CList.Enqueue("4/4");
            CList.Enqueue("6/8");
            CList.Enqueue("12/8");

            text = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            

        }

        private void Start()
        {
            CopyString();
            SetNotes();
        }
        private enum SPLITTYPE { FRONT, REAR,FULL}
        
        private int SplitBeatDatas(SPLITTYPE _TYPE)
        {
            string data = CList.GetData();
            int spliterIdx = data.IndexOf('/');
            string front = data.Substring(0, spliterIdx);
            string rear = data.Substring(spliterIdx+1);
            //Debug.Log($"{data}  {spliterIdx}  {front}  {rear}");

            switch (_TYPE)
            {
                case SPLITTYPE.FRONT:
                    return int.Parse(front);

                case SPLITTYPE.REAR:
                    return int.Parse(rear);
                default:
                    return -1;
            }
        }

        public float GetBeatDataDeno()
        {
            return SplitBeatDatas(SPLITTYPE.REAR);
        }
        public float GetBeatDataNumer()
        {
            return SplitBeatDatas(SPLITTYPE.FRONT);
        }


        public void NextString()
        {
            CList.MoveNext();
            CopyString();
            SetNotes();
        }
        public void PrevString()
        {
            CList.MovePrev();
            CopyString();
            SetNotes();
        }
        private void CopyString()
        {
            text.text = CList.GetData();
            
        }

        private void SetNotes()
        {
            if (noteholder != null)
                noteholder.SetNotes(SplitBeatDatas(SPLITTYPE.FRONT));
        }
    }
}