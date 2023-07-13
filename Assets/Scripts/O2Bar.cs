using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public float O2,speed;
    private float maxO2,realScale;

    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        maxO2 = O2;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        realScale = O2 / maxO2;
        if (transform.localScale.x>realScale)
        {
            transform.localScale = new Vector3(transform.localScale.x-(transform.localScale.x-realScale)/speed,transform.localScale.y,transform.localScale.z);
        }
        //Debug.Log("Deneme");
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (O2 > 0)
                    O2 -= 20;
                timeRemaining = 5;
                timerIsRunning = true;

            }
        }
        if(O2<0)
            O2 = 0;
        if (O2==0)
        {
            GameManager.gameOver = true;
        }
    }
}
