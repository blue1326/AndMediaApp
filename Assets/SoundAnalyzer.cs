using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class SoundAnalyzer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int Equlizerbar_Cnt = 0;
    [SerializeField]
    private float bar_interval = 0;
    
    private List<GameObject> Sticks = null;
    [SerializeField]
    private GameObject SpectrumParent = null;
    [SerializeField]
    private GameObject barPrefab = null;
    [SerializeField]
    private AudioSource audSource = null;
    [SerializeField]
    private float[] SpectrumData = null;
    [SerializeField]
    private int numSamples = 2;
    [SerializeField]
    private FFTWindow FFTW = FFTWindow.Hamming;

    [SerializeField]
    private float scalex =0;

    private void Awake()
    {
        Sticks = new List<GameObject>();
        for(int i =0; i<Equlizerbar_Cnt; i++)
        {
            GameObject obj = Instantiate(barPrefab);
            if (SpectrumParent)
                obj.transform.parent = SpectrumParent.transform;

            if (scalex == 0)
                obj.transform.localScale = Vector3.one;
            else
                obj.transform.localScale = new Vector3(scalex, scalex, scalex);
            obj.transform.localPosition = new Vector2(bar_interval * i, 0);
            Sticks.Add(obj);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audSource)
        {
            SpectrumData = audSource.GetSpectrumData(64, 0, FFTWindow.Hamming);
            for(int i = 0; i< Sticks.Count; i++)
            {
                Vector2 scale = Sticks[i].transform.localScale;
                scale.y = 0.02f + SpectrumData[i] * 700;
                Sticks[i].transform.localScale = Vector2.MoveTowards(Sticks[i].transform.localScale, scale, 0.1f);
            }


            
        }
    }
}
