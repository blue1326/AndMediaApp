using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanelAction : MonoBehaviour
{

    Vector3 OriginPos;
    Vector3 TargetPos = Vector3.zero;
    [SerializeField]
    Coroutine cor = null;
    private void Awake()
    {
        OriginPos = this.transform.position;
    }

    public void Atcivate()
    {
        if(cor == null)
            cor =  StartCoroutine(ActivePanel());

    }

    public void Deactivate()
    {
        if (cor == null)
            cor = StartCoroutine(DeactivePanel());
    }


    private void MoveToCenter()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPos, 5f);
    }


    IEnumerator ActivePanel()
    {
        while(true)
        {
            if (this.transform.position != Vector3.zero)
                MoveToCenter();
            else
            {
                cor = null;
                yield break;
            }

            yield return null;
        }
    }

    private void MoveToOrigin()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, OriginPos, 5f);
    }
    IEnumerator DeactivePanel()
    {
        while (true)
        {
            if (this.transform.position != OriginPos)
                MoveToOrigin();
            else
            {
                cor = null;
                yield break;
            }

            yield return null;
        }
    }
}
