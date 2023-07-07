using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver; //oyunun bittiðini kontrol eden bool deðer    
    public static float playerScore; //oyuncunun kazandýðý puan
    float distance; //ardaki mesafe

    public TMP_Text scoretable; //score text i 
    public TMP_Text DistanceText; //mesafe text i
    public Image okImage;
    
    
    public GameObject targetobject; // oyuncunun varacaðý konum
    public GameObject Player;
    public GameObject GameOverPanel; //oyun bittiðinde çýkan panel
    

    // Start is called before the first frame update
    void Start()
    {       
        gameOver = false;
        GameOverPanel.SetActive(false);
        playerScore = PlayerPrefs.GetFloat("PlayerScore"); // oyuncunun skorunu playerprefs den çektik
        scoretable.text = "Gold: "+playerScore.ToString(); // skoru texte yazdýk.
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
        CalculateDistance();
        scoretable.text= "Gold: "+PlayerPrefs.GetFloat("PlayerScore").ToString();  //skoru update metodunda güncelliyoruz
        if (Player.GetComponent<PlayerMovement>().health <= 0) //playerin caný o ýn altýna düþtüyse gameover true yap
        {
            gameOver = true;
            GameOverPanel.SetActive(true); //oyun bitiþ panelinin gözükmesi için
            Player.SetActive(false);  // playerin görünürlüðünü kapama
        }

    }
    void CalculateDistance()
    {
        Vector3 targetDriection = targetobject.transform.position - okImage.rectTransform.position;
        float aci = Mathf.Atan2(targetDriection.y, targetDriection.x) * Mathf.Rad2Deg;
        okImage.rectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, aci));
        distance = Vector2.Distance(Player.transform.position, targetobject.transform.position);
        DistanceText.text = "Kalan Yol: "+distance.ToString();
    }
}
