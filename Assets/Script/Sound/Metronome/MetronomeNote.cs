using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MetronomeNote : MonoBehaviour
{
    
    private Image img= null;
    [SerializeField]
    private Sprite baseSprite = null;
    [SerializeField]
    private Sprite SwitchSprite = null;

    [SerializeField]
    AudioSource aud;

    private void Awake()
    {
        img = GetComponent<Image>();
        baseSprite = img.sprite;
        SwitchSprite = Resources.Load<Sprite>("Sprite/icons/NoteRed");
        aud = this.GetComponent<AudioSource>();
        aud.clip = Resources.Load<AudioClip>("sfx/sfx_1");
    }


    public void Chime()
    {
        StartCoroutine(SwitchImage());
        aud.Play();
    }


    IEnumerator SwitchImage()
    {
        img.sprite = SwitchSprite;
        yield return new WaitForSeconds(0.3f);
        img.sprite = baseSprite;

    }
}
