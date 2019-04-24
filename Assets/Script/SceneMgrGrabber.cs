using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMgrGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(SceneMgr.SceneMgrInst.GetComponent<SceneMgr>().BackToMainMenu);
            //= SceneMgr.SceneMgrInst.GetComponent<SceneMgr>().BackToMainMenu();
    }
}
