using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public static float O2;
    private float speed;  //oksijen seviyesi,bar�n d��me h�z�
    public static float maxO2;
    private float realScale;  //max oksijen seviyesi

    private float timeRemaining = 3;  //d��me de�eri zamanlay�c�
    private bool timerIsRunning = false;  //zamanlay�c�n�n kontrolu
    int valueOfSprite; //ka��nc� lvl denizalt�nda oldu�unu g�sterecek de�i�ken
    // Start is called before the first frame update
    void Start()
    {
        speed = 20; //yava�lama h�z�na de�er
        valueOfSprite = PlayerPrefs.GetInt("SubMarine");      
        
        
        if (valueOfSprite==0)   //player objesinin denizalt� seviyesine g�re oksijen seviyelerinin ayarlanmas�
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

    // Update is called once per frame
    void Update()
    {
        realScale = O2 / maxO2;
        if (transform.localScale.x>realScale)  //oksijen bar�n�n d�����n� hesaplama
        {
            transform.localScale = new Vector3(transform.localScale.x-(transform.localScale.x-realScale)/speed,transform.localScale.y,transform.localScale.z);
        }
        if (transform.localScale.x < realScale)  //oksijen bar�n�n art���n� hesaplama
        {
            transform.localScale = new Vector3(transform.localScale.x + (realScale- transform.localScale.x) / speed, transform.localScale.y, transform.localScale.z);
        } 

        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (O2 > 0 && GameManager.gameOver==false && GameManager.gamePassed == false) 
                    O2 -= 7;  //5 saniyede bir oksijenimizi 7 kademe d���r�yor
                timeRemaining = 3;
                timerIsRunning = true;

            }
        }
        if(O2<0)  //bar�n - kademeye ya da max kademenin �st�ne ��kmas�n� engellemek i�in e�itleme yap�yoruz
            O2 = 0;  
        if (O2 > maxO2)
            O2 = maxO2; 
        if (O2==0)
        {
            GameManager.gameOver = true;  //oksijen bitti�inde oyunu bitirme
        }
    }
}
