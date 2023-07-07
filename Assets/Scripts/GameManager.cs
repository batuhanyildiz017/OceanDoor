using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver; //oyunun bittiðini kontrol eden bool deðer
    public GameObject Player;
    public GameObject GameOverPanel; //oyun bittiðinde çýkan panel
    public static float playerScore; //oyuncunun kazandýðý puan
    
    // Start is called before the first frame update
    void Start()
    {       
        gameOver = false;
        GameOverPanel.SetActive(false);
        playerScore = PlayerPrefs.GetFloat("PlayerScore"); // oyuncunun skorunu playerprefs den çektik
    }
    public void Restart() //Restart butonuna onclick ile baðlý
    {
        gameOver = false;
        Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
        Player.GetComponent<PlayerMovement>().health = 5;
    }
    public void MainMenu()  // Main Menu butonuna onclick ile baðlý
    {
        gameOver = false;
        Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        gameOver = false;
        Player.GetComponent<PlayerMovement>().health = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().health <= 0) //playerin caný o ýn altýna düþtüyse gameover true yap
        {
            gameOver = true;
            GameOverPanel.SetActive(true);
        }

    }
}
