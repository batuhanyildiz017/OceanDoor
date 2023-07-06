using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver; //oyunun bitti�ini kontrol eden bool de�er
    public GameObject Player;
    public GameObject GameOverPanel; //oyun bitti�inde ��kan panel
    public static float playerScore; //oyuncunun kazand��� puan
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("playerScore");
        gameOver = false;
        GameOverPanel.SetActive(false);
        playerScore = PlayerPrefs.GetFloat("playerScore"); // oyuncunun skorunu playerprefs den �ektik
    }
    public void Restart() //Restart butonuna onclick ile ba�l�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()  // Main Menu butonuna onclick ile ba�l�
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().health <= 0) //playerin can� o �n alt�na d��t�yse gameover true yap
        {
            gameOver = true;
            GameOverPanel.SetActive(true);
        }

    }
}
