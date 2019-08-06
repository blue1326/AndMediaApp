using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TMPro.TMP_Dropdown))]
public class TempoMarkData : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Dropdown DropDown = null;
    private void Awake()
    {
        if (DropDown == null)
            DropDown = this.GetComponent<TMPro.TMP_Dropdown>();

        

        DropDown.AddOptions(GetOptions());



    }


    private List<string> GetOptions()
    {
        List<string> options = new List<string>();
        options.Add("안단테");
        options.Add("안단티노");
        options.Add("모데라토");
        options.Add("엘레그레토");
        options.Add("알레그로");
        options.Add("기타");
        return options;
    }
}
