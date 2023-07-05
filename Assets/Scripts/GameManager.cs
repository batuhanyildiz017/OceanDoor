using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject Player;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GameOverPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
