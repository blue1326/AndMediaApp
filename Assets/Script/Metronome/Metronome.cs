using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    enum Tempo_Denominator
    {
        Deno_2 = 2,Deno_4 = 4, Deno_8 = 6, Deno_16 = 8
    }
    private float DenominaotorValue(Tempo_Denominator _D)
    {
        switch(_D)
        {
            case Tempo_Denominator.Deno_2:
                return 2;
            case Tempo_Denominator.Deno_4:
                return 1;
            case Tempo_Denominator.Deno_8:
                return 0.5f;
            case Tempo_Denominator.Deno_16:
                return 0.25f;
        }
        return 0;
    }
    float timeacc;
    float prevtime;

    readonly short baseBPM = 60;

    [SerializeField]
    [Range(20,240)]
    private short BPM = 60;

    [Header("Tempo")]
    [SerializeField]
    [Tooltip("Tempo Denominator")]
    private Tempo_Denominator Tempo_D = Tempo_Denominator.Deno_4;

    [SerializeField]
    [Range(1,16)]
    [Tooltip("Tempo numerator")]
    private short Tempo_N = 4;

    Coroutine cor=null;

    [SerializeField]
    float TickTime = 0;

    [SerializeField]
    AudioSource AudSrc;

    IEnumerator StartMetronome()
    {
        while(true)
        {
            timeacc += Time.time - prevtime;

            Debug.Log($"acc : {timeacc}");
            Debug.Log($"prev : {prevtime}");
            if (timeacc >= TickTime)
            {
                Tick();
                timeacc = 0;
            }
            prevtime = Time.time;
            yield return null;
            //yield return new WaitForSeconds(TickTime);
        }
    }

    private void Tick()
    {
        AudSrc.Play();
    }

    public void SwitchOnOff()
    {
        if (cor == null)
        {
            prevtime = 0;
            timeacc = 0;
            cor = StartCoroutine(StartMetronome());
        }
        else
        {
            StopCoroutine(cor);
            cor = null;

        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TickTime = ((float)BPM / 60) * DenominaotorValue(Tempo_D);
    }
}
