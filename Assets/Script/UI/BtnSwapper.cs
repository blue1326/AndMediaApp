using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] objects = new GameObject[2];


    public void Swap()
    {
        if (objects[0].activeSelf)
        {
            objects[0].SetActive(false);
            objects[1].SetActive(true);
        }
        else
        {
            objects[1].SetActive(false);
            objects[0].SetActive(true);
        }
    }
}
