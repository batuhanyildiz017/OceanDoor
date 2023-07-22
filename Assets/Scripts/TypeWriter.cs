using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class TypeWriter : MonoBehaviour
{
    public TMP_Text Text3;  //yazýyý yazdýrdýðýmýz text
    public AudioClip typeSound; //ses
    AudioSource source; //ses kaynaðý
    string TextOpen; //yazýmýz
    bool okey;  //yazý tamamen girildiðinde klavye sesini durdurmak için deðiþken
    private void Start()
    {
        okey = false;
        source = GetComponent<AudioSource>();
        Text3 = GetComponent<TMP_Text>();
        source.PlayOneShot(typeSound);
        if (LanguageControl.tr == true) 
        {
            TextOpen = "bugun karadenizin 2 kilometre altindaki, simdiye kadar bulunan dunyanin en eski gemisine gidecegiz. " +
                "arastirmacilar tarafýndan yapilan aciklamada, bulunan geminin 2400 yil oncesine dayanan eski bir yunan ticaret gemisi oldugu soylendi.";
        }
        else
        {
            TextOpen = "today we will go to the oldest ship in the world found so far, 2 kilometers under the black sea." +
                "In the statement made by the researchers, it was said that the ship found was an ancient greek merchant ship dating back 2400 years.";
        }

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
        
        if (GameManager.gameStarted == false)
            foreach(char i in TextOpen)
            {
                Text3.text += i.ToString();
                yield return new WaitForSeconds(0.1f);
            }

        okey = true;
    }
}
