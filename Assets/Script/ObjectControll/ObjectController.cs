using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectController //: Singleton<ObjectController>
{
    private ObjectController() { }
    private static ObjectController _inst = null;

    public static ObjectController GetInst()
    {
        if(_inst == null)
        {
            _inst = new ObjectController();
            _inst.Init();
        }

        return _inst;
    }

    public WeakReference GetWeakReference()
    {
        return new WeakReference(_inst);
    }

    private void Init()
    {
        _dic = new Dictionary<string, GameObject>();
        
    }
    

    private Dictionary<string, GameObject> _dic = null;

    //private void Awake()
    //{
    //    _dic = new Dictionary<string, GameObject>();
    //    i = 1;
    //}

    public void AddDic(string _tag, GameObject _obj)
    {
        _dic.Add(_tag, _obj);
    }
}
