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
    
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftRotationAngle = +1f;
        rightRotationAngle = -1f;
        health = 5f;
        shakeTime = 1f;
        shakeStrength = 3f;
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
    }
    // Update is called once per frame
    void Update()
    {
        //rb.velocity=new Vector2 (5f*250*Time.deltaTime,rb.velocity.y);
        if(GameManager.gameOver==false)  //oyun bitmediyse
            transform.Translate(new Vector3(5f*Time.deltaTime, 0f, 0f)); // x yönünde sürekli hareket ettirir
                                                                        // rotation ý deðiþtirdiðimiz için x yönü de deðiþir hep ileri gider
        if (GameManager.gameOver==false) //oyuncunun caný bitmediyse oyun bitmediyse
        {
            Left();  //rotasyonu sola çevirme
            Right(); //rotasyonu saða çevirme
        }
        
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
