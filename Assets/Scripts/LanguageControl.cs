using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageControl : MonoBehaviour
{
    public static bool tr;
    public TMP_Text playButton;
    public TMP_Text upgradesButton;
    public TMP_Text quitButton;
    public GameObject trbutton;
    // Update is called once per frame
    private void Start()
    {
        tr = true;
        /*if (tr==false)
        {
            playButton.text = "play";
            upgradesButton.text = "upgrades";
            quitButton.text = "quit";
        }
        else
        {
            playButton.text = "oyna";
            upgradesButton.text = "gelistirmeler";
            quitButton.text = "cikis";
        }*/
    }
    public void ButtonTR()
    {
        if (tr==true)
        {
            tr=false;
            trbutton.SetActive(false);
            playButton.text = "play";
            upgradesButton.text = "upgrades";
            quitButton.text = "quit";
        }
        else if (tr==false)
        {
            tr = true;
            trbutton.SetActive(true);
            playButton.text = "oyna";
            upgradesButton.text = "gelistirmeler";
            quitButton.text = "cikis";
        }
    }
}
