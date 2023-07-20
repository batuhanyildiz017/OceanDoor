using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private bool leftclickControl;  //sol butona bas�ld���n� kontrol eden de�i�ken
    private bool rightclickControl; //sa� tu�a bas�ld���n� kontrol eden de�i�ken
    [SerializeField]private float leftRotationAngle;  //butona bas�ld���nda sola d�nme a��s�
    [SerializeField] private float rightRotationAngle; //butona bas�ld���nda sa�a d�nme a��s�
    public float health; //oyuncu sa�l���
    float shakeStrength; //kamera sallama g�c�
    float shakeTime;  //kamera sallama s�resi
    float valueOfSprite;  //denzialt� seviyesini tutuyoruz
    float subSpeed;  //denizalt� h�z�
    SpriteRenderer subSprite;  //denizalt� sprite renderer
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        SubMarineLevel(); //denizalt�n�n seviyesine g�re can�n� ve h�z�n� de�i�tiriyoruz
        subSprite =GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        leftRotationAngle = +1f;  //sola d�nme a��s�
        rightRotationAngle = -1f;  //sa�a d�nme a��s�
        //health = 5f;   //oyuncu can�
        shakeTime = 1f;  //kameray� sallama s�resi
        shakeStrength = 3f;  //kameray� sallama g�c�
    }
    void SubMarineLevel()  //denizalt�n�n seviyesine g�re can�n� ve h�z�n� de�i�tiriyoruz
    {
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");  //denzialt� seviyesini tutuyoruz
        if (valueOfSprite==0)
        {
            health = 4f;
            subSpeed = 5f;
        }else if (valueOfSprite == 1)
        {
            health = 5f;
            subSpeed = 6.5f;
        }
        else if (valueOfSprite==2)
        {
            health = 6f;
            subSpeed = 8f;
        }
        else if (valueOfSprite==3)
        {
            health = 7f;
            subSpeed = 9.5f;
        }
    }
    public void MakeTrueLeft()  //sol butona bas�ld���n� kontrol etme
    {
        leftclickControl = true;
    }
    public void MakeFalseLeft()  //sol butona bas�lmay� b�rakt���n� kontrol etme
    {
        leftclickControl=false;
    }
    public void MakeTrueRight() //sa� butona bas�ld���n� kontrol etme
    {
        rightclickControl = true;
    }
    public void MakeFalseRight() //sa� butona bas�lmay� b�rak�ld���n� kontrol etme
    {
        rightclickControl = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Camera.main.DOShakeRotation(shakeTime,shakeStrength,fadeOut:true);
            Shake.Instance.ShakeCamera(shakeStrength,shakeTime);  // Shake scriptinden �a��rd���m�z kod
                                                                  // belirledi�imiz g��te ve saniyede bir engele �arpt���m�zda kameray� sall�yor
        }
        if (collision.CompareTag("Energy") && O2Bar.O2<O2Bar.maxO2)
        {
            O2Bar.O2 += 20;
            collision.gameObject.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver==false && GameManager.gamePassed==false && GameManager.gameStarted == true)  //oyun bitmediyse
            transform.Translate(new Vector3(subSpeed*Time.deltaTime, 0f, 0f)); // x y�n�nde s�rekli hareket ettirir  h�za g�re
                                                                        // rotation � de�i�tirdi�imiz i�in x y�n� de de�i�ir hep ileri gider
        if (GameManager.gameOver==false && GameManager.gamePassed == false && GameManager.gameStarted == true) //oyuncunun can� bitmediyse oyun bitmediyse
        {
            Left();  //rotasyonu sola �evirme
            Right(); //rotasyonu sa�a �evirme
        }
        float zRotation = transform.eulerAngles.z;
        if (zRotation >= 100f && zRotation <= 250f)  //denizalt� y ekseninde ters d�erse flipy yi true yaaprak d�zeltme
        {
            subSprite.flipY = true;
        }
        else
            subSprite.flipY = false;

        
    }
    void Left()
    {
        if (leftclickControl==true)
        {
            player.transform.Rotate(new Vector3(0f, 0f, leftRotationAngle));

        }
    }
    void Right()
    {
        if(rightclickControl==true)
        player.transform.Rotate(new Vector3(0f, 0f, rightRotationAngle));
    }

}
