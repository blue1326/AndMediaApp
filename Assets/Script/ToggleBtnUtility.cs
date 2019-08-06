using MusicalTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleBtnUtility : MonoBehaviour
{

    private BeatData BData = null;
    private void Awake()
    {
        Toggle tgl = this.GetComponent<Toggle>();
        tgl.onValueChanged.AddListener(this.ToggleValueChange);
        //ToggleValueChange(tgl.isOn);
        BData = this.GetComponent<BeatData>();
    }
    public void ToggleValueChange(bool _value)
    {
        Debug.Log("ch");
        if (_value)
        {
            this.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            this.GetComponent<Toggle>().interactable = true;
           // BData.SendData();
        }
    }
}
