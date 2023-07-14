using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    private float O2,speed;  //oksijen seviyesi,barýn düþme hýzý
    private float maxO2,realScale;  //max oksijen seviyesi

    private float timeRemaining = 5;  //düþme deðeri zamanlayýcý
    private bool timerIsRunning = false;  //zamanlayýcýnýn kontrolu
    int valueOfSprite; //kaçýncý lvl denizaltýnda olduðunu gösterecek deðiþken
    // Start is called before the first frame update
    void Start()
    {
        speed = 20; //yavaþlama hýzýna deðer
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");      
        
        
        if (valueOfSprite==0)   //player objesinin denizaltý seviyesine göre oksijen seviyelerinin ayarlanmasý
        {
            //Debug.Log("Girdikk");
            O2 = 100;
            
        }
        else if (valueOfSprite == 1)
        {
            O2 = 150;
            
        }
        else if (valueOfSprite == 2)
        {
            O2 = 200;
        }
        else if (valueOfSprite == 3)
        {
            O2 = 250;
        }
        maxO2 = O2;
        timerIsRunning = true;
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& O2>0)
        {
            O2 += 5;
        }
    } */

    // Update is called once per frame
    void Update()
    {
        realScale = O2 / maxO2;
        if (transform.localScale.x>realScale)  //oksijen barýnýn düþüþünü hesaplama
        {
            transform.localScale = new Vector3(transform.localScale.x-(transform.localScale.x-realScale)/speed,transform.localScale.y,transform.localScale.z);
        }
      /*  if (transform.localScale.x < realScale)
        {
            transform.localScale = new Vector3(transform.localScale.x + (realScale- transform.localScale.x) / speed, transform.localScale.y, transform.localScale.z);
        } */

        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (O2 > 0)
                    O2 -= 5;  //5 saniyede bir oksijenimizi 5 kademe düþürüyor
                timeRemaining = 5;
                timerIsRunning = true;

            }
        }
        if(O2<0)  //barýn - kademeye ya da max kademenin üstüne çýkmasýný engellemek için eþitleme yapýyoruz
            O2 = 0;  
        if (O2 > maxO2)
            O2 = maxO2; 
        if (O2==0)
        {
            GameManager.gameOver = true;  //oksijen bittiðinde oyunu bitirme
        }
    }
}
