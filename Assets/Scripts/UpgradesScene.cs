using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UpgradesScene : MonoBehaviour
{
    public SpriteRenderer subMarine;
    public Sprite s0,s1,s2, s3;
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text CoinText;
    int valueOfSprite;
    bool pressed;  // preview butonuna basýlýp basýlmadðýný kontrol etme

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        //PlayerPrefs.SetFloat("PlayerScore", 150f); //test için koydum
        CoinText.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
        valueOfSprite =PlayerPrefs.GetInt("SubMarine");
        if (valueOfSprite==0)
        {
            subMarine.sprite = s0;
            Text1.text = "Little SubMarine";
        }else if (valueOfSprite == 1)
        {
            subMarine.sprite = s1;
            Text1.text = "Mid SubMarine";
        }
        else if (valueOfSprite == 2)
        {
            subMarine.sprite = s2;
            Text1.text = "Big SubMarine";
        }
        else if (valueOfSprite == 3)
        {
            subMarine.sprite = s3;
            Text1.text = "Huge SubMarine";
        }
    }
    private void Update()
    {
        CoinText.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");
    }


    public void PreviewButton()
    {
        pressed = true;  //butona basýlmayý true yap
        if (valueOfSprite == 0)
        {
            //fiyatýný text ile yazdýr.
            subMarine.sprite = s1;
            Text1.text = "Mid SubMarine";
        }
        else if (valueOfSprite == 1)
        {
            subMarine.sprite = s2;
            Text1.text = "Big SubMarine";
        }
        else if (valueOfSprite == 2)
        {
            subMarine.sprite = s3;
            Text1.text = "Huge SubMarine";
        }
        else if (valueOfSprite == 3)
        {
            Text2.text = "Your SubMarine is already the last level.";
        }
    }
    public void ConfirmButton()
    {
        if (pressed == true) {
        if (valueOfSprite == 0)
        {
            if (PlayerPrefs.GetFloat("PlayerScore") > 80f)
            {
                subMarine.sprite = s1;
                PlayerPrefs.SetInt("SubMarine", 1);
                PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 80f));
                Text2.text = "Purchase successful";
            }
            else
            {
                Text2.text = "You dont have enough money";
            }
        }

        if (valueOfSprite == 1)
        {
            if (PlayerPrefs.GetFloat("PlayerScore") > 100f)
            {
                subMarine.sprite = s2;
                PlayerPrefs.SetInt("SubMarine", 2);
                PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 100f));
                Text2.text = "Purchase successful";
            }
            else
            {
                Text2.text = "You dont have enough money";
            }
        }
        if (valueOfSprite == 2)
        {
            if (PlayerPrefs.GetFloat("PlayerScore") > 120f)
            {
                subMarine.sprite = s3;
                PlayerPrefs.SetInt("SubMarine", 3);
                PlayerPrefs.SetFloat("PlayerScore", (PlayerPrefs.GetFloat("PlayerScore") - 120f));
                Text2.text = "Purchase successful";
            }
            else
            {
                Text2.text = "You dont have enough money";
            }
        }
        if (valueOfSprite == 3)
        {
            //Text1.text = "Your SubMarine is already the last level.";
            Text2.text = "Your SubMarine is already the last level.";
        }
        }
        pressed = false;  // butona basýlmayý false yap ki eðer tekrar preview butonuna basmadýysa satýn alým yapamasýn
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); //ana menüye geri dönme tuþu
    }
}
