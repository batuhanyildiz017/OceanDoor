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
    string TextOpen;
    string TextClose; //b�l�m� ge�ince a��lacak text
    bool okey;  //yaz� tamamen girildi�inde klavye sesini durdurmak i�in de�i�ken
    private void Start()
    {
        okey = false;
        source = GetComponent<AudioSource>();
        Text3=GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        TextOpen = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean suscipit quam nisl, a convallis tortor convallis placerat. ut rutrum viverra lobortis.";
        TextClose= "lalalalalalalenean suscipit quam nisl, a convallis tortor convallis placerat. ut rutrum viverra lobortis.";
        StartCoroutine(TypeWrite());
    }
    private void Update()
    {
        if (GameManager.gameStarted==true || okey==true)
        {
            source.Stop();
        }
        okey = false;
    }
    IEnumerator TypeWrite()
    {
        if(GameManager.gamePassed==true)
            source.PlayOneShot(typeSound);

        if (GameManager.gameStarted == false)
            foreach(char i in TextOpen)
            {
                Text3.text += i.ToString();
                yield return new WaitForSeconds(0.1f);
            }
        else
            foreach (char i in TextClose)
            {
                Text3.text += i.ToString();
                yield return new WaitForSeconds(0.1f);
            }

        okey = true;
    }
}
