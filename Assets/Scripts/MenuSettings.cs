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
        Debug.Log("��k�� yap�ld�..."); // edit�rde �al��mayaca�� i�in kontrol ama�l�
    }
    public void UpgradesButton()
    {
        Debug.Log("Denzialt� upgrade sahnesine gider...");
        //Denizalt� geli�tirmek i�in a��lacak olan sahnenin kodu buraya yaz�lacak
    }
}
