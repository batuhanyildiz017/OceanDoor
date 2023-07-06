using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    const int poolSize = 3;  // coin kuyruðu adeti
    Queue<GameObject> coinPool;  // coin kuyruðu
    [SerializeField] GameObject coinPrefab; // coin nesnesi
    [SerializeField] Transform spawnPointTransform;  // coinin oluþturulduðu nokta
    [SerializeField] float coinSpeed = 10f;  // coin hýzý
    [SerializeField] Transform endPointTransform;  //coinin gitmeyi hedeflediði point nokta
    [SerializeField] float coinSpawnInterval = 3f;  // coin oluþturma süresi

    private void Start()
    {

        coinPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)  // poolSize büyüklüðünde coin prefab oluþturarak görünürlüðünü kapatýyor.
        {
            GameObject coin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
            coin.SetActive(false);  //coinin görünürlüðünü kapatma
            coinPool.Enqueue(coin); //oluþturulan coini kuyruða gönder.
        }
        StartCoroutine(SpawnCoin());   // verilen süreye göre spawnpoint noktasýndan coin oluþturuyor
    }

    GameObject GetCoinFromPool()  // kuyruktan coin çýkarma ve görünür kýlma
    {
        if (coinPool.Count > 0)
        {
            GameObject obstacle1 = coinPool.Dequeue();
            obstacle1.SetActive(true);
            return obstacle1;
        }
        return null;
    }
    public void ReturnCoinToPool(GameObject obstacle)  // iþi biten coini tekrar kuyruða sokma ve görünürlüðünü kapatma
    {
        obstacle.SetActive(false);
        coinPool.Enqueue(obstacle);
    }
    IEnumerator DisableCoinAfterDelay(GameObject obstacle, float delay)  //oluþturulan coini deactive etmek için süreli IEnumerator
    {
        yield return new WaitForSeconds(delay);
        ReturnCoinToPool(obstacle);
    }
    void Shooting()  // coin oluþturma ve belirlenen hýzla endpoint noktasýna yollayan metod
    {
        Vector3 endPos = endPointTransform.position;
        Vector3 PosWorld = Camera.main.ScreenToWorldPoint(endPos);
        Vector3 direction = (PosWorld - spawnPointTransform.position).normalized;
        GameObject coin = GetCoinFromPool(); //kuyruktan obejyi alýp coin objesine  atýyor.
        if (coin != null)
        {
            coin.transform.position = spawnPointTransform.position; // engelin pozisyonunu spawnpoint pozisyonu olarak güncelliyor.
            coin.SetActive(true); // engeli görünür yapýyor.

            Rigidbody2D coinRGB = coin.GetComponent<Rigidbody2D>(); // coinin rigidbodysini tanýmlama
            coinRGB.velocity = direction * coinSpeed;  // coine hýz verme
            StartCoroutine(DisableCoinAfterDelay(coin, 8f));  // verilen süre sonunda coini yok etme
        }
    }
    IEnumerator SpawnCoin()  // süreli coin oluþturma coroutine si
    {
        while (GameManager.gameOver != true)  // oyun bitmediði sürece coin oluþtur
        {
            yield return new WaitForSeconds(coinSpawnInterval);
            Shooting();
        }
    }
}
