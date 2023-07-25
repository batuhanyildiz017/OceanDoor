using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public void PlayButton()
    {
        //PlayerPrefs.SetInt("Scene", 1);  // oyunda bir sonraki seviyeye ge�me sistemi
        // daha yapmad���m i�in bir sonraki seviyeye ge�ti�imde prefsle kaydedicem o zaman bunu kapat�cam
        //PlayerPrefs.GetInt("Scene");
        if (PlayerPrefs.GetInt("GameLevel")==0)
        {
            PlayerPrefs.SetInt("GameLevel", 2);
        }
        GameManager.gamePassed = false;
        GameManager.gameOver = false;
        if (PlayerPrefs.GetInt("GameLevel") == 5)  //oyunun 3 levelini de bitirdiyse oynaya bast���nda son leveli a�mas� i�in
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
        Debug.Log("��k�� yap�ld�..."); // edit�rde �al��mayaca�� i�in kontrol ama�l�
    }
    public void UpgradesButton()
    {
        Debug.Log("Denzialt� upgrade sahnesine gider...");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        //Denizalt� geli�tirmek i�in a��lacak olan sahnenin kodu buraya yaz�lacak
    }
}
