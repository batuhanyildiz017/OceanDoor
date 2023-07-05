using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Çýkýþ yapýldý..."); // editörde çalýþmayacaðý için kontrol amaçlý
    }
    public void UpgradesButton()
    {
        Debug.Log("Denzialtý upgrade sahnesine gider...");
        //Denizaltý geliþtirmek için açýlacak olan sahnenin kodu buraya yazýlacak
    }
}
