using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMode : MonoBehaviour
{
    public enum MetronomeMode { LEARN,TEST };
    [SerializeField]
    private MetronomeMode m_mode = MetronomeMode.LEARN;

    public MetronomeMode Mode { get => m_mode;}
    [SerializeField]
    private GameObject TestMode = null;
    [SerializeField]
    private GameObject LearnMode = null;

    public void Switch()
    {
        switch (m_mode)
        {
            case MetronomeMode.LEARN:
                m_mode = MetronomeMode.TEST;
                ActiveTestMode();
                break;
            case MetronomeMode.TEST:
                m_mode = MetronomeMode.LEARN;
                ActiveLearnMode();
                break;
        }
    }

    private void ActiveTestMode()
    {
        TestMode.SetActive(true);
        LearnMode.SetActive(false);
    }
    private void ActiveLearnMode()
    {
        TestMode.SetActive(false);
        LearnMode.SetActive(true);
    }


}
