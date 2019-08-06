using UnityEngine;
using System;
/// <summary>
/// 수정중
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonGameObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private static WeakReference _container;
    private static WeakReference _instance;

    public static T Instance
    {
        get
        {
            GameObject container;

            if (_container != null)
            {
                container = _container.Target as GameObject;
                if (container != null)
                {
                    return _instance.Target as T;
                }
            }

            container = new GameObject();
            DontDestroyOnLoad(container);
            container.name = "_" + typeof(T).Name;
            T instance = container.AddComponent(typeof(T)) as T;

            _container = new WeakReference(container, false);
            _instance = new WeakReference(instance, false);

            return instance;
        }
    }
}


public class SingletonTypeD<T> where T : new()
{
    private static T _instance;
    private static GameObject _GameObjectInst;


    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }

    

    public class GObjectinst : MonoBehaviour
    {
        [SerializeField]
        private T instance;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SetInst(T _inst)
        {
            instance = _inst;
        }
    }

    public static GameObject GameObjectInst
    {
        get
        {
            if (_GameObjectInst == null)
            {
                _GameObjectInst = new GameObject();

                
            }
            return _GameObjectInst;
        }
    }

}

public class Singleton<T> where T : new()
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }
}