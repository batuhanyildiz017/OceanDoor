using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    const int poolSize = 3;  // coin kuyru�u adeti
    Queue<GameObject> coinPool;  // coin kuyru�u
    [SerializeField] GameObject coinPrefab; // coin nesnesi
    [SerializeField] Transform spawnPointTransform;  // coinin olu�turuldu�u nokta
    [SerializeField] float coinSpeed = 10f;  // coin h�z�
    [SerializeField] Transform endPointTransform;  //coinin gitmeyi hedefledi�i point nokta
    [SerializeField] float coinSpawnInterval = 3f;  // coin olu�turma s�resi

    private void Start()
    {

        coinPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)  // poolSize b�y�kl���nde coin prefab olu�turarak g�r�n�rl���n� kapat�yor.
        {
            GameObject coin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
            coin.SetActive(false);  //coinin g�r�n�rl���n� kapatma
            coinPool.Enqueue(coin); //olu�turulan coini kuyru�a g�nder.
        }
        StartCoroutine(SpawnCoin());   // verilen s�reye g�re spawnpoint noktas�ndan coin olu�turuyor
    }

    GameObject GetCoinFromPool()  // kuyruktan coin ��karma ve g�r�n�r k�lma
    {
        if (coinPool.Count > 0)
        {
            GameObject obstacle1 = coinPool.Dequeue();
            obstacle1.SetActive(true);
            return obstacle1;
        }
        return null;
    }
    public void ReturnCoinToPool(GameObject obstacle)  // i�i biten coini tekrar kuyru�a sokma ve g�r�n�rl���n� kapatma
    {
        obstacle.SetActive(false);
        coinPool.Enqueue(obstacle);
    }
    IEnumerator DisableCoinAfterDelay(GameObject obstacle, float delay)  //olu�turulan coini deactive etmek i�in s�reli IEnumerator
    {
        yield return new WaitForSeconds(delay);
        ReturnCoinToPool(obstacle);
    }
    void Shooting()  // coin olu�turma ve belirlenen h�zla endpoint noktas�na yollayan metod
    {
        Vector3 endPos = endPointTransform.position;
        Vector3 PosWorld = Camera.main.ScreenToWorldPoint(endPos);
        Vector3 direction = (PosWorld - spawnPointTransform.position).normalized;
        GameObject coin = GetCoinFromPool(); //kuyruktan obejyi al�p coin objesine  at�yor.
        if (coin != null)
        {
            coin.transform.position = spawnPointTransform.position; // engelin pozisyonunu spawnpoint pozisyonu olarak g�ncelliyor.
            coin.SetActive(true); // engeli g�r�n�r yap�yor.

            Rigidbody2D coinRGB = coin.GetComponent<Rigidbody2D>(); // coinin rigidbodysini tan�mlama
            coinRGB.velocity = direction * coinSpeed;  // coine h�z verme
            StartCoroutine(DisableCoinAfterDelay(coin, 8f));  // verilen s�re sonunda coini yok etme
        }
    }
    IEnumerator SpawnCoin()  // s�reli coin olu�turma coroutine si
    {
        while (GameManager.gameOver != true)  // oyun bitmedi�i s�rece coin olu�tur
        {
            yield return new WaitForSeconds(coinSpawnInterval);
            Shooting();
        }
    }
}
