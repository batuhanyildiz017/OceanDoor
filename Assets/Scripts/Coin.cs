using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float scoreIncrease;
    // Start is called before the first frame update
    void Start()
    {
        scoreIncrease = 1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.playerScore += scoreIncrease; // oyuncunun skorunu skor artýþý oranýnda arttýrdýk.
            PlayerPrefs.SetFloat("playerScore",GameManager.playerScore);  //oyuncunun skorunu palyerprefsle kaydettik.
            Debug.Log("prefsten gelen skor"+PlayerPrefs.GetFloat("playerScore"));
            Debug.Log("Deðiþkenden gelen skor "+GameManager.playerScore);
            gameObject.SetActive(false); // coin objesinin görünürlüðünü kapattýk.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
