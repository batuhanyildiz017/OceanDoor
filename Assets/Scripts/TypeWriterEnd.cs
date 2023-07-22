using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class TypeWriterEnd : MonoBehaviour
{
    public TMP_Text Text3;
    public AudioClip typeSound;
    AudioSource source;
    string TextOpen;
    bool okey;  //yaz� tamamen girildi�inde klavye sesini durdurmak i�in de�i�ken
    private void Start()
    {
        okey = false;
        source = GetComponent<AudioSource>();
        Text3 = GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        TextOpen = "Dolar almis basisni gitmis consectetur adipiscing elit. Aenean suscipit quam nisl, a convallis tortor convallis placerat. ut rutrum viverra lobortis.";
        StartCoroutine(TypeWrite());

    }
    private void Update()
    {
        if (okey == true)
        {
            source.Stop();
        }
    }
    IEnumerator TypeWrite()
    {
            foreach (char i in TextOpen)
            {
                Text3.text += i.ToString();
                yield return new WaitForSeconds(0.1f);
            }

        okey = true;
    }
}
