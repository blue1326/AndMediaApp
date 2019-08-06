using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnabler : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_objects;
    

    public void EnableAll()
    {
        for(int i =0; i<m_objects.Length;i++)
        {
            m_objects[i].SetActive(true);
        }
    }
    public void DisableAll()
    {
        for (int i = 0; i < m_objects.Length; i++)
        {
            m_objects[i].SetActive(false);
        }
    }
    public void SetActiveState(bool _state)
    {
        for (int i = 0; i < m_objects.Length; i++)
        {
            m_objects[i].SetActive(_state);
        }
    }
}
