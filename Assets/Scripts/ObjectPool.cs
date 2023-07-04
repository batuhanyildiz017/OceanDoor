using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    const int poolSize = 5;
    Queue<GameObject> obstaclePool;
    [SerializeField] GameObject ObstaclePrefab;
    [SerializeField] Transform spawnPointTransform;
    [SerializeField] float obstacleSpeed=10f;
    [SerializeField] Transform playerTransform;
    private void Start()
    {
        obstaclePool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(ObstaclePrefab, Vector3.zero, Quaternion.identity);
            obstacle.SetActive(false);
            obstaclePool.Enqueue(obstacle);
        }
    }
    
    GameObject GetObstacleFromPool()
    {
        if (obstaclePool.Count>0)
        {
            GameObject obstacle1 = obstaclePool.Dequeue();
            obstacle1.SetActive(true);
            return obstacle1;
        }
        return null;
    }
    void ReturnObstacleToPool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
    IEnumerator DisableObstacleAfterDelay(GameObject obstacle,float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObstacleToPool(obstacle);
    }
    IEnumerator ActiveObstacleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Shooting();
    }
    void Shooting()
    {
        Vector3 playerPos = playerTransform.position;
        Vector3 PosWorld=Camera.main.ScreenToWorldPoint(playerPos);
        Vector3 direction=(PosWorld-spawnPointTransform.position).normalized;
        Vector3 pos = new Vector3(-1, 0, 0);
        GameObject obstacle = GetObstacleFromPool();
        if (obstacle!=null)
        {
            obstacle.transform.position = spawnPointTransform.position;
            obstacle.SetActive(true);

            Rigidbody2D obstacleRGB= obstacle.GetComponent<Rigidbody2D>();
            obstacleRGB.velocity = direction * obstacleSpeed;
            StartCoroutine(DisableObstacleAfterDelay(obstacle, 4f));
        }
    }
    private void Update()
    {
        //StartCoroutine(ActiveObstacleAfterDelay(10f));
        //Shooting();
        // Zamanlayýcý etkinse süreyi güncelleyin
        ZamanlayiciyiBaslat();
        if (zamanlayiciAktif)
        {
            sure -= Time.deltaTime;

            // Süre bittiðinde ZamanlayiciyiDurdur fonksiyonunu çaðýrabilirsiniz
            if (sure <= 0f)
            {
                ZamanlayiciyiDurdur();
            }
        }
    }
    public float sure = 3f; // Zamanlayýcýnýn süresi (saniye cinsinden)
    private bool zamanlayiciAktif = false; // Zamanlayýcýnýn etkin olup olmadýðýný belirten bayrak

    // Zamanlayýcýyý baþlatan fonksiyon
    public void ZamanlayiciyiBaslat()
    {
        zamanlayiciAktif = true;
        Invoke("ZamanlayiciyiDurdur", sure);
    }

    // Zamanlayýcýyý durduran fonksiyon
    public void ZamanlayiciyiDurdur()
    {
        zamanlayiciAktif = false;
        Shooting();
        // Zamanlayýcý tamamlandýðýnda yapýlmasý gereken iþlemleri buraya ekleyebilirsiniz
    }

}