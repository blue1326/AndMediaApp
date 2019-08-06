using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BpmSelecter : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown UI_DD = null;
    [SerializeField]
    private TMP_InputField UI_IF = null;
    [SerializeField]
    //private Metronome metro = null;

    private bool IfChangeFlag = false;



    private string SetValueFlagBPM(int _Value)
    {
        switch(_Value)
        {
            case 0: //andante
                return "76";
            case 1://andantino
                return "80";
            case 2: //moderato
                return "108";
            case 3: //allegreto
                return "112";
            case 4: //allegro
                return "120";
        }
        return "20";
    }


    private void Awake()
    {
    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(UI_IF.text);
    }

    public void ValueChangeDropDown(int _value)
    {
        //Debug.Log(_value);
        if(!IfChangeFlag)
            UI_IF.text = SetValueFlagBPM(_value);
    }

    public void ValueChangeInputField(string _value)
    {
        IfChangeFlag = true;
        int val = int.Parse(_value);
        
        if (val >= 76 && val <= 156)
        {
            if(val <=80)//andante
            {
                UI_DD.value = 0;
            }
            else if(val <=108)//andantino
            {
                UI_DD.value = 1;
            }
            else if(val <= 112)//moderato
            {
                UI_DD.value = 2;
            }
            else if(val >= 120)//allegretto
            {
                UI_DD.value = 3;
            }
            else//allegro
            {
                UI_DD.value = 4;
            }
        }
        else
            UI_DD.value = 5;
        IfChangeFlag = false;
        //exceptions on metronome min max
        if (val < 20)
        {
            UI_IF.text = "20";
            val = 20;
        }
        if(val > 240)
        {
            UI_IF.text = "240";
            val = 240;
        }
        //metro.bpm = (short)val;
    }

    public void SetBPM()
    {
        //metro.bpm = short.Parse(UI_IF.text);
    }

}
