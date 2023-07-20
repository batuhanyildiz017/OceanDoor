using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private bool leftclickControl;  //sol butona basýldýðýný kontrol eden deðiþken
    private bool rightclickControl; //sað tuþa basýldýðýný kontrol eden deðiþken
    [SerializeField]private float leftRotationAngle;  //butona basýldýðýnda sola dönme açýsý
    [SerializeField] private float rightRotationAngle; //butona basýldýðýnda saða dönme açýsý
    public float health; //oyuncu saðlýðý
    float shakeStrength; //kamera sallama gücü
    float shakeTime;  //kamera sallama süresi
    float valueOfSprite;  //denzialtý seviyesini tutuyoruz
    float subSpeed;  //denizaltý hýzý
    SpriteRenderer subSprite;  //denizaltý sprite renderer
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        SubMarineLevel(); //denizaltýnýn seviyesine göre canýný ve hýzýný deðiþtiriyoruz
        subSprite =GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        leftRotationAngle = +1f;  //sola dönme açýsý
        rightRotationAngle = -1f;  //saða dönme açýsý
        //health = 5f;   //oyuncu caný
        shakeTime = 1f;  //kamerayý sallama süresi
        shakeStrength = 3f;  //kamerayý sallama gücü
    }
    void SubMarineLevel()  //denizaltýnýn seviyesine göre canýný ve hýzýný deðiþtiriyoruz
    {
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");  //denzialtý seviyesini tutuyoruz
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
    public void MakeTrueLeft()  //sol butona basýldýðýný kontrol etme
    {
        leftclickControl = true;
    }
    public void MakeFalseLeft()  //sol butona basýlmayý býraktýðýný kontrol etme
    {
        leftclickControl=false;
    }
    public void MakeTrueRight() //sað butona basýldýðýný kontrol etme
    {
        rightclickControl = true;
    }
    public void MakeFalseRight() //sað butona basýlmayý býrakýldýðýný kontrol etme
    {
        rightclickControl = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Camera.main.DOShakeRotation(shakeTime,shakeStrength,fadeOut:true);
            Shake.Instance.ShakeCamera(shakeStrength,shakeTime);  // Shake scriptinden çaðýrdýðýmýz kod
                                                                  // belirlediðimiz güçte ve saniyede bir engele çarptýðýmýzda kamerayý sallýyor
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
            transform.Translate(new Vector3(subSpeed*Time.deltaTime, 0f, 0f)); // x yönünde sürekli hareket ettirir  hýza göre
                                                                        // rotation ý deðiþtirdiðimiz için x yönü de deðiþir hep ileri gider
        if (GameManager.gameOver==false && GameManager.gamePassed == false && GameManager.gameStarted == true) //oyuncunun caný bitmediyse oyun bitmediyse
        {
            Left();  //rotasyonu sola çevirme
            Right(); //rotasyonu saða çevirme
        }
        float zRotation = transform.eulerAngles.z;
        if (zRotation >= 100f && zRotation <= 250f)  //denizaltý y ekseninde ters döerse flipy yi true yaaprak düzeltme
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
