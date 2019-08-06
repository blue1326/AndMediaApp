using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisable : MonoBehaviour
{
    [SerializeField]
    Button[] buttons = null;

    bool isDisable = false;


    public void SwitchState()
    {
        if (isDisable)
        {
            EnableButtons();
            isDisable = false;
        }
        else
        {
            DisableButtons();
            isDisable = true;
        }
    }




    public void DisableButtons()
    {
        for(int i =0; i<buttons.Length;i++)
        {
            buttons[i].interactable = false;
        }
    }
    public void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
