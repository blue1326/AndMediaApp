using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TMPro.TMP_InputField))]
public class BpmData : MonoBehaviour
{
    private DataStructure.CircularList<string> CList;
    [SerializeField]
    private TMPro.TextMeshProUGUI text = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI MarkerText = null;

    private void Awake()
    {
        CList = new DataStructure.CircularList<string>();
        CList.Enqueue("76");
        CList.Enqueue("80");
        CList.Enqueue("108");
        CList.Enqueue("112");
        CList.Enqueue("120");

        text = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        CopyString();
        
    }



    public string GetMusicalMarker()
    {
        switch (CList.GetData())
        {
            case "76":
                return "느리게(안단테)";

            case "80":
                return "조금 느리게(안단티노)";
            case "108":
                return "보통 빠르게 (모데라토)";
            case "112":
                return "조금 빠르게 (알레그레토)";
            case "120":
                return "빠르게 (알레그로)";
            default:
                return "";
        }
    }

    public float GetBpmData()
    {
        return float.Parse(CList.GetData());
    }

    public void NextString()
    {
        CList.MoveNext();
        CopyString();

    }
    public void PrevString()
    {
        CList.MovePrev();
        CopyString();
    }
    private void CopyString()
    {
        text.text = CList.GetData();
        if (MarkerText != null)
            MarkerText.text = GetMusicalMarker();
    }
}






//private readonly int MaxBPM = 200;
//private readonly int MinBPM = 20;

//[SerializeField]
//private int BPM = 20;

//private TMPro.TMP_InputField TmpIF = null;

//public void SetBPMData(string _data)
//{
//    BPM = int.Parse(_data);
//}

//private void Awake()
//{
//    TmpIF = this.GetComponent<TMPro.TMP_InputField>();
//    TmpIF.text = BPM.ToString();
//}

//public void IncreaseBPM(int _increase)
//{
//    if (BPM < MaxBPM)
//    {
//        BPM += _increase;
//        TmpIF.text = BPM.ToString();
//    }
//}
//public void DecreaseBPM(int _decrease)
//{
//    if (BPM > MinBPM)
//    {
//        BPM -= _decrease;
//        TmpIF.text = BPM.ToString();
//    }
//}



//public enum HoldFlag
//{
//    HF_INC, HF_DEC
//}

//Coroutine holdroutine;
//public void HoldStartIncrease()
//{
//    //isBtnDown = true;
//    holdroutine = StartCoroutine(PressCheck(HoldFlag.HF_INC));

//}
//public void HoldEnd()
//{
//    StopCoroutine(holdroutine);
//    //isBtnDown = false;
//}

//public void HoldStartDecrease()
//{
//    //isBtnDown = true;
//    holdroutine = StartCoroutine(PressCheck(HoldFlag.HF_DEC));

//}


//IEnumerator PressCheck(HoldFlag _flag)
//{
//    float speed = 0.7f;
//    int cnt = 0;

//    while (true)
//    {
//        switch (_flag)
//        {
//            case HoldFlag.HF_INC:
//                IncreaseBPM(1);
//                break;
//            case HoldFlag.HF_DEC:
//                DecreaseBPM(1);
//                break;
//        }
//        yield return new WaitForSeconds(speed);
//        if (speed > 0.2)
//        {
//            cnt++;
//            if (cnt == 2)
//            {
//                cnt = 0;
//                speed -= 0.1f;
//            }
//        }
//    }
//}