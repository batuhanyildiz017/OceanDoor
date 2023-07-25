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
    int gamelevel;
    private void Start()
    {
        gamelevel = PlayerPrefs.GetInt("GameLevel");
        okey = false;
        source = GetComponent<AudioSource>();
        Text3 = GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        if (gamelevel == 3) //target noktas�nja geldi�i gibi leveli artt�rd��� i�in bir fazla g�steriyoz
        { 
            if (LanguageControl.tr == true)
            {
                TextOpen = "23 metre uzunlugundaki gemi, " +
                    "deniz derinligindeki oksijen eksikligi sayesinde neredeyse hic hasar g�rmemis durumda " +
                    "arastirmac�lar�ndan olusan uluslararasi ekip 3 y�ll�k bir ozel gorev icin karadenizin derinliklerinde." +
                    "su ana dek 60tan fazla gemi enkazi kesfettiler." +
                    "bir sonraki bolume gecmek icin menuye don ve bir sonraki maceramiz icin denizaltini gelistirmeyi unutma.";
            }
            else
            {
                TextOpen = "the 23 meter long ship is almost undamaged due to the lack of oxygen in the sea depth." +
                    "the international team of researchers is in the depths of the black sea for a special mission of 3 years." +
                    "they have discovered more than 60 shipwrecks so far." +
                    "go to the menu to skip to the next section and dont forget to upgrade the submarine for our next adventure.";
            }
        }else if (gamelevel == 4) //target noktas�nja geldi�i gibi leveli artt�rd��� i�in bir fazla g�steriyoz
        {
            if (LanguageControl.tr == true)
            {
                TextOpen = "dip noktasindaki basinc yeryuzundeki basinca gore yaklasik 1000 kat daha fazlad�r."+
                    "mariana cukurunda hayat belirtileri vardir."+
                    "yap�lan arastirmalar, asiri basincli ve soguk ortamda yasayabilen bircok mikroorganizma, balik ve yengec turunu ortaya cikarmistir."+
                    "bir sonraki bolume gecmek icin menuye don ve bir sonraki maceramiz icin denizaltini gelistirmeyi unutma.";
            }
            else
            {
                TextOpen = "the pressure at the bottom is about 1000 times higher than the pressure on the earth. there are signs of life in the mariana trench." +
                    "studies have revealed many microorganisms, fish and crab species that can live in extreme pressure and cold environments."+
                    "return to the menu to skip to the next chapter and dont forget to upgrade your sub for our next adventure.";
            }
        }
        else if (gamelevel==5)
        {
            if (LanguageControl.tr == true)
            {
                TextOpen = "yanina geldigimiz titanic 269 m uzunluk, 28.2 m genislik, 52,310 ton agirliga sahipti. titanic in tam kapasitesi 3.547 kisiydi." +
                    "gemi cok lukstu. ana guvertede yuzme havuzu, spor salonu, turk hamami, kutuphane ve tenis kortu sunulmaktaydi." +
                    "titanic enkazi art�k 3.657 metre derinlikte yatiyor. simdilik maceralarimiz buraya kadar. umarim yakinda yeni maceralarda gorusuruz.";
            }
            else
            {
                TextOpen = "the titanic we came to had a length of 269 m, a width of 28.2 m, and a weight of 52,310 tons. titanic s full capacity was 3,547 people." +
                    " the ship was very luxurious. the main deck housed a swimming pool, gym, turkish bath, library and tennis court." +
                    " the titanic wreckage now lies at a depth of 3,657 meters. our adventures are here for now. i hope to see you in new adventures soon.";
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
