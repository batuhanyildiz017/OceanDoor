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
    int gamelevel;
    private void Start()
    {
        gamelevel = PlayerPrefs.GetInt("GameLevel");
        okey = false;
        source = GetComponent<AudioSource>();
        Text3 = GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        if (gamelevel == 3) //target noktasýnja geldiði gibi leveli arttýrdýðý için bir fazla gösteriyoz
        { 
            if (LanguageControl.tr == true)
            {
                TextOpen = "23 metre uzunlugundaki gemi, " +
                    "deniz derinligindeki oksijen eksikligi sayesinde neredeyse hic hasar görmemis durumda " +
                    "arastirmacýlarýndan olusan uluslararasi ekip 3 yýllýk bir ozel gorev icin karadenizin derinliklerinde." +
                    "su ana dek 60tan fazla gemi enkazi kesfettiler." +
                    "bir sonraki bolume gecmek icin menuye don ve bir sonraki maceramiz icin denizaltini gelistirmeyi unutma.";
            }
            else
            {
                TextOpen = "The 23 meter long ship is almost undamaged due to the lack of oxygen in the sea depth." +
                    "The international team of researchers is in the depths of the black sea for a special mission of 3 years." +
                    "They have discovered more than 60 shipwrecks so far." +
                    "Go to the menu to skip to the next section and dont forget to upgrade the submarine for our next adventure.";
            }
        }else if (gamelevel == 4) //target noktasýnja geldiði gibi leveli arttýrdýðý için bir fazla gösteriyoz
        {
            if (LanguageControl.tr == true)
            {
                TextOpen = "dip noktasindaki basinc yeryuzundeki basinca gore yaklasik 1000 kat daha fazladýr."+
                    "mariana cukurunda hayat belirtileri vardir."+
                    "yapýlan arastirmalar, asiri basincli ve soguk ortamda yasayabilen bircok mikroorganizma, balik ve yengec turunu ortaya cikarmistir."+
                    "bir sonraki bolume gecmek icin menuye don ve bir sonraki maceramiz icin denizaltini gelistirmeyi unutma.";
            }
            else
            {
                TextOpen = "the pressure at the bottom is about 1000 times higher than the pressure on the earth. there are signs of life in the mariana trench." +
                    "studies have revealed many microorganisms, fish and crab species that can live in extreme pressure and cold environments."+
                    "return to the menu to skip to the next chapter and dont forget to upgrade your sub for our next adventure.";
            }
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
