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
    bool okey;  //yazý tamamen girildiðinde klavye sesini durdurmak için deðiþken
    private void Start()
    {
        okey = false;
        source = GetComponent<AudioSource>();
        Text3 = GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        if (LanguageControl.tr==true)
        {
            TextOpen = "23 metre uzunlugundaki gemi, " +
                "deniz derinligindeki oksijen eksikligi sayesinde neredeyse hic hasar görmemis durumda " +
                "arastirmacýlarýndan olusan uluslararasi ekip 3 yýllýk bir ozel gorev icin karadenizin derinliklerinde."+
                "su ana dek 60tan fazla gemi enkazi kesfettiler." +
                "bir sonraki bolume gecmek icin menuye don ve bir sonraki maceramiz icin denizaltini gelistirmeyi unutma.";
        }
        else
        {
            TextOpen = "The 23 meter long ship is almost undamaged due to the lack of oxygen in the sea depth." +
                "The international team of researchers is in the depths of the black sea for a special mission of 3 years." +
                "They have discovered more than 60 shipwrecks so far." +
                "Go to the menu to skip to the next section and don't forget to upgrade the submarine for our next adventure.";
        }
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
