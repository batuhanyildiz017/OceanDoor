using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public float O2,speed;  //oksijen seviyesi,barýn düþme hýzý
    private float maxO2,realScale;  //max oksijen seviyesi

    private float timeRemaining = 5;  //düþme deðeri zamanlayýcý
    private bool timerIsRunning = false;  //zamanlayýcýnýn kontrolu

    private string sprite1;
    public SpriteRenderer PlayerSprite;  //player objesinin sprite ý
    // Start is called before the first frame update
    void Start()
    {
        //PlayerSprite = GetComponent<SpriteRenderer>();
        sprite1 = PlayerSprite.sprite.ToString();
        Debug.Log(sprite1);
        if (sprite1.Equals("little_submarine"))   //player objesinin denizaltý seviyesine göre oksijen seviyelerinin ayarlanmasý
        {
            O2 = 100;
        }
        else if (sprite1.Equals("submarine2"))
        {
            O2 = 150;
        }
        else if (sprite1.Equals("submarine3"))
        {
            O2 = 200;
        }
        else if (sprite1.Equals("submarine4"))
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
        if (transform.localScale.x>realScale)  //oksijen barýnýn düþüþünü hesaplama
        {
            transform.localScale = new Vector3(transform.localScale.x-(transform.localScale.x-realScale)/speed,transform.localScale.y,transform.localScale.z);
        }
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (O2 > 0)
                    O2 -= 5;
                timeRemaining = 5;
                timerIsRunning = true;

            }
        }
        if(O2<0)
            O2 = 0;
        if (O2==0)
        {
            GameManager.gameOver = true;  //oksijen bittiðinde oyunu bitirme
        }
    }
}
