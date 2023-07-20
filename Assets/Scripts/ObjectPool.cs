using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    const int poolSize = 10;  // engel kuyruðu adeti
    Queue<GameObject> obstaclePool;  // engel kuyruðu
    [SerializeField] GameObject ObstaclePrefab; // engel nesnesi
    [SerializeField] Transform spawnPointTransform;  // engelin oluþturulduðu nokta
    [SerializeField] float obstacleSpeed=10f;  // engel hýzý
    [SerializeField] Transform endPointTransform;  //engelin gitmeyi hedeflediði point nokta
    [SerializeField] float obstacleSpawnInterval = .4f;  // engel oluþturma süresi
    
    private void Start()
    {
         
        obstaclePool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)  // poolSize büyüklüðünde engel oluþturarak görünürlüðünü kapatýyor.
        {
            GameObject obstacle = Instantiate(ObstaclePrefab, Vector3.zero, Quaternion.identity);
            obstacle.SetActive(false);  //engelin görünürlüðünü kapatma
            obstaclePool.Enqueue(obstacle); //oluþturulan engeli kuyruða gönder.
        }
            StartCoroutine(SpawnObstacle());   // verilen süreye göre spawnpoint noktasýndan engel oluþturuyor
    }

    GameObject GetObstacleFromPool()  // kuyruktan engel çýkarma ve görünür kýlma
    {
        if (obstaclePool.Count>0)
        {
            GameObject obstacle1 = obstaclePool.Dequeue();
            obstacle1.SetActive(true);
            return obstacle1;
        }
        return null;
    }
    public void ReturnObstacleToPool(GameObject obstacle)  // iþi biten engeli tekrar kuyruða sokma ve görünürlüðünü kapatma
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
    IEnumerator DisableObstacleAfterDelay(GameObject obstacle,float delay)  //oluþturulan engeli deactive etmek için süreli IEnumerator
    {
        yield return new WaitForSeconds(delay);
        ReturnObstacleToPool(obstacle);
    }
  /*  IEnumerator ActiveObstacleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Shooting();
    } */
    void Shooting()  // engel oluþturma ve belirlenen hýzla endpoint noktasýna yollayan metod
    {
        Vector3 endPos = endPointTransform.position;
        Vector3 PosWorld=Camera.main.ScreenToWorldPoint(endPos);
        Vector3 direction=(PosWorld-spawnPointTransform.position).normalized;
        //Vector3 pos = new Vector3(-1, 0, 0);
        GameObject obstacle = GetObstacleFromPool(); //kuyruktan obejyi alýp obstacle a atýyor.
        if (obstacle!=null)
        {
            obstacle.transform.position = spawnPointTransform.position; // engelin pozisyonunu spawnpoint pozisyonu olarak güncelliyor.
            obstacle.SetActive(true); // engeli görünür yapýyor.

            Rigidbody2D obstacleRGB= obstacle.GetComponent<Rigidbody2D>(); // engelin rigidbodysini tanýmlama
            obstacleRGB.velocity = direction * obstacleSpeed;  // engele hýz verme
            StartCoroutine(DisableObstacleAfterDelay(obstacle, 8f));  // verilen süre sonunda engeli yok etme
        }
    }
    /*private void Update()
    {
        StartCoroutine(ActiveObstacleAfterDelay(5f));
        //Shooting();
        
        
    } */
    IEnumerator SpawnObstacle()  // süreli engel oluþturma coroutine si
    {
        
        while (GameManager.gameOver == false && GameManager.gamePassed == false)  // oyun bitmediði sürece engel oluþtur
        {            
            yield return new WaitForSeconds(obstacleSpawnInterval);
            if (GameManager.gameStarted == true)
                Shooting();            
        }        
    }


}