using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructure 
{
    public class CircularList <T>
    {
        public CircularList() { Init(); }
        private List<T> _datalist;
        int index = 0;
        private void Init()
        {
            Debug.Log("init!");
            _datalist = new List<T>();
        }

        public void Enqueue(T _data)
        {
            _datalist.Add(_data);
        }
        //public void Dequeue(T _data)
        //{
        //    _datalist.
        //}
        public T GetData()
        {
            if (_datalist.Count == 0)
            {
                Debug.Log("List is empty");
                return default(T);
            }
            return _datalist[index];
        }
        public void Clear()
        {
            _datalist.Clear();
        }
        public void MoveNext()
        {
            index++;
            if (index >= _datalist.Count)
                index = 0;
        }
        public void MovePrev()
        {
            index--;
            if (index < 0)
                index = _datalist.Count-1;
        }
        public void ResetIndex()
        {
            index = 0;
        }
    }
}
