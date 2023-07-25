using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UpgradesScene : MonoBehaviour
{
    public SpriteRenderer subMarine;
    public Sprite s0,s1,s2;
    public TMP_Text Text1;  //denizaltý isminin yazdýðý text
    public TMP_Text Text2;  //uyarýlarýn yazdýðý text
    public TMP_Text CoinText; //paramýzýn yazdýðý text
    public TMP_Text PriceText; //denizaltý ücretinin yazdýðý text
    public TMP_Text PreviewText; //önizleme buton texti
    public TMP_Text BuyText; //satýn al buton texti
    int valueOfSprite;
    //bool pressed;  // preview butonuna basýlýp basýlmadðýný kontrol etme

    // Start is called before the first frame update
    void Start()
    {
        //pressed = false;
        //PlayerPrefs.SetFloat("PlayerScore", 150f); //test için koydum
        CoinText.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
        valueOfSprite =PlayerPrefs.GetInt("SubMarine");
        if (valueOfSprite==0)
        {
            subMarine.sprite = s0;
            if(LanguageControl.tr==false)
                Text1.text = "little submarine";
            else
                Text1.text = "kucuk denizalti";
        }
        else if (valueOfSprite == 1)
        {
            subMarine.sprite = s1;
            if(LanguageControl.tr==false)
                Text1.text = "mid submarine";
            else
                Text1.text = "orta denizalti";
        }
        else if (valueOfSprite == 2)
        {
            subMarine.sprite = s2;
            if(LanguageControl.tr==false)
                Text1.text = "Big SubMarine";
            else
                Text1.text = "buyuk denizalti";
        }
       /* else if (valueOfSprite == 3)
        {
            subMarine.sprite = s3;
            if(LanguageControl.tr==false)
                Text1.text = "huge Submarine";
            else
                Text1.text = "devasa denizalti";
        } */

        if (LanguageControl.tr==false)
        {
            PreviewText.text = "next";
            BuyText.text = "buy";
        }
        else
        {
            PreviewText.text = "sonraki";
            BuyText.text = "satin al";
        }
    }
    private void Update()
    {
        CoinText.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");
    }


    public void PreviewButton()
    {
        //pressed = true;  //butona basýlmayý true yap
        if (valueOfSprite == 0)
        {

            //fiyatýný text ile yazdýr.
            subMarine.sprite = s1;
            if (LanguageControl.tr == false) {
                Text1.text = "mid submarine";
                PriceText.text = "price:50";
            }
            else { 
                Text1.text = "orta denizalti";
                PriceText.text = "fiyat:50";
            }
        }
        else if (valueOfSprite == 1)
        {
            subMarine.sprite = s2;
            if (LanguageControl.tr == false)
            {
                Text1.text = "big submarine";
                PriceText.text = "price:80";
            }
            else
            {
                Text1.text = "buyuk denizalti";
                PriceText.text = "fiyat:80";
            }
                
        }
       /* else if (valueOfSprite == 2)
        {
            subMarine.sprite = s3;
            if (LanguageControl.tr == false)
            {
                Text1.text = "huge Submarine";
                PriceText.text = "price:100";
            }
            else
            {
                Text1.text = "devasa denizalti";
                PriceText.text = "fiyat:100";
            }
                
        } */
        else if (valueOfSprite == 2)
        {
            PriceText.text = " ";
            if(LanguageControl.tr == false)
                Text2.text = "Your SubMarine is already the last level.";
            else
                Text2.text = "denizaltin zaten son seviye";
        }
    }
    public void ConfirmButton()
    {
        
            if (valueOfSprite == 0)
            {
                if (subMarine.sprite == s0) {
                if(LanguageControl.tr == true)
                    Text2.text = "zaten satin alinmýs";
                else
                    Text2.text = "Already purchased";
                }
                else { 
                if (PlayerPrefs.GetFloat("PlayerScore") >= 50f)
                {
                    subMarine.sprite = s1;
                    PlayerPrefs.SetInt("SubMarine", 1);
                    PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 50f));
                    if (LanguageControl.tr == false)
                        Text2.text = "Purchase successful";
                    else
                        Text2.text = "basariyla satin alindi";
                }
                else
                {
                    if (LanguageControl.tr == false)
                        Text2.text = "you dont have enough money";
                    else
                        Text2.text = "yeterli paran yok.";
                }
                }
            }

            if (valueOfSprite == 1)
            {
            if (subMarine.sprite == s1)
            {
                if (LanguageControl.tr == true)
                    Text2.text = "zaten satin alinmýs";
                else
                    Text2.text = "Already purchased";
            }
            else { 
                if (PlayerPrefs.GetFloat("PlayerScore") >= 80f)
                {
                    subMarine.sprite = s2;
                    PlayerPrefs.SetInt("SubMarine", 2);
                    PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 80f));
                    if (LanguageControl.tr == false)
                        Text2.text = "Purchase successful";
                    else
                        Text2.text = "basariyla satin alindi";
                }
                else
                {
                    if (LanguageControl.tr == false)
                        Text2.text = "you dont have enough money";
                    else
                        Text2.text = "yeterli paran yok.";
                }
                }
            }
          /*  if (valueOfSprite == 2)
            {
            if (subMarine.sprite == s2)
            {
                if (LanguageControl.tr == true)
                    Text2.text = "zaten satin alinmýs";
                else
                    Text2.text = "Already purchased";
            }
            else {
            if (PlayerPrefs.GetFloat("PlayerScore") >= 100f)
                {
                    subMarine.sprite = s3;
                    PlayerPrefs.SetInt("SubMarine", 3);
                    PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 100f));
                    if (LanguageControl.tr == false)
                        Text2.text = "Purchase successful";
                    else
                        Text2.text = "basariyla satin alindi";
                }
                else
                {
                    if (LanguageControl.tr == false)
                        Text2.text = "you dont have enough money";
                    else
                        Text2.text = "yeterli paran yok.";
                }
                }
            } */
        if (valueOfSprite == 2)
        {
            //Text1.text = "Your SubMarine is already the last level.";
            if (LanguageControl.tr == false)
                Text2.text = "Your SubMarine is already the last level.";
            else
                Text2.text = "denizaltin zaten son seviye";
        }
        
        //pressed = false;  // butona basýlmayý false yap ki eðer tekrar preview butonuna basmadýysa satýn alým yapamasýn
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); //ana menüye geri dönme tuþu
    }
}
