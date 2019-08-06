using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class PanelCliper : MonoBehaviour
{

    public GameObject top;
    public GameObject bottom;

    [SerializeField]
    RectTransform RT = null;

    private void Awake()
    {
        RT = (RectTransform)this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
