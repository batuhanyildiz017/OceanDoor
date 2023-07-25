using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public void PlayButton()
    {
        //PlayerPrefs.SetInt("Scene", 1);  // oyunda bir sonraki seviyeye geçme sistemi
        // daha yapmadýðým için bir sonraki seviyeye geçtiðimde prefsle kaydedicem o zaman bunu kapatýcam
        //PlayerPrefs.GetInt("Scene");
        if (PlayerPrefs.GetInt("GameLevel")==0)
        {
            PlayerPrefs.SetInt("GameLevel", 2);
        }
        GameManager.gamePassed = false;
        GameManager.gameOver = false;
        if (PlayerPrefs.GetInt("GameLevel") == 5)  //oyunun 3 levelini de bitirdiyse oynaya bastýðýnda son leveli açmasý için
        {
            PlayerPrefs.SetInt("GameLevel", 4);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("GameLevel"), LoadSceneMode.Single);
        GameManager.gameOver = false;
        GameManager.gamePassed = false;
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Çýkýþ yapýldý..."); // editörde çalýþmayacaðý için kontrol amaçlý
    }
    public void UpgradesButton()
    {
        Debug.Log("Denzialtý upgrade sahnesine gider...");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        //Denizaltý geliþtirmek için açýlacak olan sahnenin kodu buraya yazýlacak
    }
}
