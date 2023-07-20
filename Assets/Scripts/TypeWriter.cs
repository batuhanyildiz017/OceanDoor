using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class TypeWriter : MonoBehaviour
{
    public TMP_Text Text3;
    public AudioClip typeSound;
    AudioSource source;
    string Text1;
    bool okey;
    private void Start()
    {
        okey = false;
        source = GetComponent<AudioSource>();
        Text3=GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        Text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean suscipit quam nisl, a convallis tortor convallis placerat. ut rutrum viverra lobortis.";
        StartCoroutine(TypeWrite());
    }
    private void Update()
    {
        if (GameManager.gameStarted==true || okey==true)
        {
            source.Stop();
        }
    }
    IEnumerator TypeWrite()
    {
        foreach(char i in Text1)
        {
            Text3.text += i.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        okey = true;
    }
}
