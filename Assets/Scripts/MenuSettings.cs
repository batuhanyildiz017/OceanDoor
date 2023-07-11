using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public void PlayButton()
    {
        PlayerPrefs.SetInt("Scene", 1);  // oyunda bir sonraki seviyeye geçme sistemi
                                         // daha yapmadýðým için bir sonraki seviyeye geçtiðimde prefsle kaydedicem o zaman bunu kapatýcam
        PlayerPrefs.GetInt("Scene");
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"), LoadSceneMode.Single);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Çýkýþ yapýldý..."); // editörde çalýþmayacaðý için kontrol amaçlý
    }
    public void UpgradesButton()
    {
        Debug.Log("Denzialtý upgrade sahnesine gider...");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        //Denizaltý geliþtirmek için açýlacak olan sahnenin kodu buraya yazýlacak
    }
}
