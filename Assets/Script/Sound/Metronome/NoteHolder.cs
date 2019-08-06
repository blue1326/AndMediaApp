using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicalTool
{
    public class NoteHolder : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private MetronomeNote[] Notes;

        [SerializeField]
        //private List<MetronomeNote> ActiveNotes;
        DataStructure.CircularList<MetronomeNote> ActiveNotes;
        // Start is called before the first frame update
        private void Awake()
        {
            ActiveNotes = new DataStructure.CircularList<MetronomeNote>();
            Notes = this.GetComponentsInChildren<MetronomeNote>();
        }


        public void SetNotes(int NoteCount)
        {
            //int noteCnt = 0;
            
            ActiveNotes.Clear();
            for (int i = 0; i < Notes.Length; i++)
            {
                if (i < Notes.Length - NoteCount)
                {
                    Notes[i].gameObject.SetActive(false);
                }
                else
                {
                    Notes[i].gameObject.SetActive(true);
                    ActiveNotes.Enqueue(Notes[i]);
                }
            }
        }

        public void Reset()
        {
            ActiveNotes.ResetIndex();
        }

        public void Tick()
        {
            ActiveNotes.GetData().Chime();
            ActiveNotes.MoveNext();
        }
        public void Chime(int _idx)
        {
            //ActiveNotes[_idx].Chime();
        }
    }
}