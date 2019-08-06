using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PageMgr))]
public class SceneLoader : MonoBehaviour
{
    

    List<IEnumerator> enumerators;

    [SerializeField]
    PageMgr pagemgr = null;

    private void Awake()
    {
        pagemgr = this.GetComponent<PageMgr>();
        enumerators = new List<IEnumerator>();
        enumerators.Add(LoadSceneAdditive("01.Learn"));
        enumerators.Add(LoadSceneAdditive("010.TrackInfo"));
        enumerators.Add(LoadSceneAdditive("011.BeatTest"));
        enumerators.Add(LoadSceneAdditive("012.Pitch"));
        enumerators.Add(LoadSceneAdditive("test.CamUI"));
        enumerators.Add(LoadSceneAdditive("020.Player"));
        //enumerators.Add(LoadSceneAdditive("test4"));


        for (int i =0; i<enumerators.Count; i++)
        {
            StartCoroutine(enumerators[i]);
        }

        StartCoroutine(LoadCompleteTrace(enumerators));
    }

    IEnumerator LoadCompleteTrace(List<IEnumerator> _enumerators)
    {
        while (true)
        {
            bool res = false;
            for (int i = 0; i < _enumerators.Count; i++)
            {
                res = _enumerators[i].MoveNext();
                if (res)
                {
                    break;
                }
            }
            if (!res)
            {
                pagemgr.objects = GameObject.FindGameObjectsWithTag("UICAM");
                pagemgr.IsSetup = true;
                pagemgr.InitPageCondition();
                yield break;
            }

            yield return null;
        }
    }


    IEnumerator LoadSceneAdditive(string _Scene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(_Scene, LoadSceneMode.Additive);
        while(!async.isDone)
        {
            yield return null;
            //Debug.Log($"prog : {async.progress}, name : {_Scene}");
        }
        //Debug.Log($"done! , name : {_Scene}");
    }
    
}
