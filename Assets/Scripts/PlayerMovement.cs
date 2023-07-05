using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool leftclickControl;  //sol butona bas�ld���n� kontrol eden de�i�ken
    private bool rightclickControl; //sa� tu�a bas�ld���n� kontrol eden de�i�ken
    [SerializeField]private float leftRotationAngle;  //butona bas�ld���nda sola d�nme a��s�
    [SerializeField] private float rightRotationAngle; //butona bas�ld���nda sa�a d�nme a��s�
    public float health; //oyuncu sa�l���
    
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftRotationAngle = +1f;
        rightRotationAngle = -1f;
        health = 5f;
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


    // Update is called once per frame
    void Update()
    {
        //rb.velocity=new Vector2 (5f*250*Time.deltaTime,rb.velocity.y);
        if(GameManager.gameOver==false)  //oyun bitmediyse
            transform.Translate(new Vector3(5f*Time.deltaTime, 0f, 0f)); // x y�n�nde s�rekli hareket ettirir
                                                                        // rotation � de�i�tirdi�imiz i�in x y�n� de de�i�ir hep ileri gider
        if (GameManager.gameOver==false) //oyuncunun can� bitmediyse oyun bitmediyse
        {
            Left();  //rotasyonu sola �evirme
            Right(); //rotasyonu sa�a �evirme
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
