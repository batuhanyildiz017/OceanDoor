using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gamePassed; // oyun ge�ildi�ini kontrol eden de�er
    public static bool gameOver; //oyunun bitti�ini kontrol eden bool de�er    
    public static float playerScore; //oyuncunun kazand��� puan
    float distance; //ardaki mesafe
    int valueOfSprite; // denizalt�n�n seviye de�erini tutan de�i�ken
    int gameLevel;


    public TMP_Text scoretable; //score text i 
    public TMP_Text DistanceText; //mesafe text i
    public TMP_Text HealthText;  //can� yazd�raca��m�z text
    public Image okImage;  //y�n�m�z� g�steren ok resminin de�i�keni
    
    
    public GameObject targetobject; // oyuncunun varaca�� konum
    public GameObject Player;
    public GameObject GameOverPanel; //oyun bitti�inde ��kan panel

    public SpriteRenderer subMarine;
    public Sprite s0, s1, s2, s3;
    

    // Start is called before the first frame update
    void Start()
    {
        gamePassed = false;
        gameOver = false;
        GameOverPanel.SetActive(false);
        playerScore = PlayerPrefs.GetFloat("PlayerScore"); // oyuncunun skorunu playerprefs den �ektik       
        scoretable.text = "Gold: "+playerScore.ToString(); // skoru texte yazd�k.
        SubMarineLevel(); // denizalt�n�n leveline g�re sprite�n� g�ncelledik.
        if (PlayerPrefs.GetInt("GameLevel")==0) //gamelevel 0 ise 2 e e�itle(ilk level sahnemiz yani) 0 de�ilse oldu�u de�ere e�itle
        {
            gameLevel = 2;
            PlayerPrefs.SetInt("GameLevel",2);
        }
        else
            gameLevel = PlayerPrefs.GetInt("GameLevel");
    }
    public void Restart() //Restart butonuna onclick ile ba�l�
    {
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
    }
    public void MainMenu()  // Main Menu butonuna onclick ile ba�l�
    {
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        gameOver = false;
        //Player.GetComponent<PlayerMovement>().health = 5;
    }
    public void ExitButton()  // exit butonuna onclick ile ba�l�
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
        scoretable.text=PlayerPrefs.GetFloat("PlayerScore").ToString();  //skoru update metodunda g�ncelliyoruz
        HealthText.text = Player.GetComponent<PlayerMovement>().health.ToString();
        if (Player.GetComponent<PlayerMovement>().health <= 0) //playerin can� o �n alt�na d��t�yse gameover true yap
        {
            gameOver = true;
            GameOverPanel.SetActive(true); //oyun biti� panelinin g�z�kmesi i�in
            Player.SetActive(false);  // playerin g�r�n�rl���n� kapama
        }
        if (gameOver==true)
        {
            GameOverPanel.SetActive(true); //oyun biti� panelinin g�z�kmesi i�in
            Player.SetActive(false);  // playerin g�r�n�rl���n� kapama
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
