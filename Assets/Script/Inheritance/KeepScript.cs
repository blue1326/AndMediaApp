using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScript : MonoBehaviour
{
    public virtual void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
