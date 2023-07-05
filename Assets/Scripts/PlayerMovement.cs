using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool leftclickControl;  //sol butona basýldýðýný kontrol eden deðiþken
    private bool rightclickControl; //sað tuþa basýldýðýný kontrol eden deðiþken
    [SerializeField]private float leftRotationAngle;  //butona basýldýðýnda sola dönme açýsý
    [SerializeField] private float rightRotationAngle; //butona basýldýðýnda saða dönme açýsý
    public float health; //oyuncu saðlýðý
    
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftRotationAngle = +1f;
        rightRotationAngle = -1f;
        health = 5f;
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
