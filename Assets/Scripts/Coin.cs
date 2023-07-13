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
            //PlayerPrefs.SetFloat("playerScore", GameManager.playerScore+scoreIncrease);
            GameManager.playerScore += scoreIncrease; // oyuncunun skorunu skor art��� oran�nda artt�rd�k.
            PlayerPrefs.SetFloat("PlayerScore",GameManager.playerScore);  //oyuncunun skorunu palyerprefsle kaydettik.
            Debug.Log("prefsten gelen skor"+PlayerPrefs.GetFloat("PlayerScore"));
            Debug.Log("De�i�kenden gelen skor "+GameManager.playerScore);
            gameObject.SetActive(false); // coin objesinin g�r�n�rl���n� kapatt�k.
        }
    }
}
