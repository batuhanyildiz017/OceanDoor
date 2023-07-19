using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gamePassed; // oyun geçildiðini kontrol eden deðer
    public static bool gameOver; //oyunun bittiðini kontrol eden bool deðer    
    public static float playerScore; //oyuncunun kazandýðý puan
    float distance; //ardaki mesafe
    int valueOfSprite; // denizaltýnýn seviye deðerini tutan deðiþken
    int gameLevel;


    public TMP_Text scoretable; //score text i 
    public TMP_Text DistanceText; //mesafe text i
    public TMP_Text HealthText;  //caný yazdýracaðýmýz text
    public Image okImage;  //yönümüzü gösteren ok resminin deðiþkeni
    
    
    public GameObject targetobject; // oyuncunun varacaðý konum
    public GameObject Player;
    public GameObject GameOverPanel; //oyun bittiðinde çýkan panel

    public SpriteRenderer subMarine;
    public Sprite s0, s1, s2, s3;
    

    // Start is called before the first frame update
    void Start()
    {
        gamePassed = false;
        gameOver = false;
        GameOverPanel.SetActive(false);
        playerScore = PlayerPrefs.GetFloat("PlayerScore"); // oyuncunun skorunu playerprefs den çektik       
        scoretable.text = "Gold: "+playerScore.ToString(); // skoru texte yazdýk.
        SubMarineLevel(); // denizaltýnýn leveline göre spriteýný güncelledik.
        if (PlayerPrefs.GetInt("GameLevel")==0) //gamelevel 0 ise 2 e eþitle(ilk level sahnemiz yani) 0 deðilse olduðu deðere eþitle
        {
            gameLevel = 2;
            PlayerPrefs.SetInt("GameLevel",2);
        }
        else
            gameLevel = PlayerPrefs.GetInt("GameLevel");
    }
    public void Restart() //Restart butonuna onclick ile baðlý
    {
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
    }
    public void MainMenu()  // Main Menu butonuna onclick ile baðlý
    {
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
    }
    public void ExitButton()  // exit butonuna onclick ile baðlý
    {
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
    }
    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        scoretable.text=PlayerPrefs.GetFloat("PlayerScore").ToString();  //skoru update metodunda güncelliyoruz
        HealthText.text = Player.GetComponent<PlayerMovement>().health.ToString();
        if (Player.GetComponent<PlayerMovement>().health <= 0) //playerin caný o ýn altýna düþtüyse gameover true yap
        {
            gameOver = true;
            GameOverPanel.SetActive(true); //oyun bitiþ panelinin gözükmesi için
            Player.SetActive(false);  // playerin görünürlüðünü kapama
        }
        if (gameOver==true)
        {
            GameOverPanel.SetActive(true); //oyun bitiþ panelinin gözükmesi için
            Player.SetActive(false);  // playerin görünürlüðünü kapama
        }
        if (gamePassed==true)
        {
            Player.SetActive(false);
            PlayerPrefs.SetInt("GameLevel",gameLevel+1);
            
        }

    }
    void CalculateDistance()
    {
        Vector3 targetDirection = targetobject.transform.position - Player.transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        okImage.rectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle)); 
        distance = Vector2.Distance(Player.transform.position, targetobject.transform.position);
        DistanceText.text = ((int)distance).ToString();
    }
    void SubMarineLevel()
    {
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");
        if (valueOfSprite == 0)
        {
            subMarine.sprite = s0;
            
        }
        else if (valueOfSprite == 1)
        {
            subMarine.sprite = s1;
            
        }
        else if (valueOfSprite == 2)
        {
            subMarine.sprite = s2;
            
        }
        else if (valueOfSprite == 3)
        {
            subMarine.sprite = s3;
            
        }
    }
}
