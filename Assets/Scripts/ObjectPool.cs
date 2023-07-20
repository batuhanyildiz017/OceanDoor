using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    const int poolSize = 10;  // engel kuyru�u adeti
    Queue<GameObject> obstaclePool;  // engel kuyru�u
    [SerializeField] GameObject ObstaclePrefab; // engel nesnesi
    [SerializeField] Transform spawnPointTransform;  // engelin olu�turuldu�u nokta
    [SerializeField] float obstacleSpeed=10f;  // engel h�z�
    [SerializeField] Transform endPointTransform;  //engelin gitmeyi hedefledi�i point nokta
    [SerializeField] float obstacleSpawnInterval = .4f;  // engel olu�turma s�resi
    
    private void Start()
    {
         
        obstaclePool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)  // poolSize b�y�kl���nde engel olu�turarak g�r�n�rl���n� kapat�yor.
        {
            GameObject obstacle = Instantiate(ObstaclePrefab, Vector3.zero, Quaternion.identity);
            obstacle.SetActive(false);  //engelin g�r�n�rl���n� kapatma
            obstaclePool.Enqueue(obstacle); //olu�turulan engeli kuyru�a g�nder.
        }
            StartCoroutine(SpawnObstacle());   // verilen s�reye g�re spawnpoint noktas�ndan engel olu�turuyor
    }

    GameObject GetObstacleFromPool()  // kuyruktan engel ��karma ve g�r�n�r k�lma
    {
        if (obstaclePool.Count>0)
        {
            GameObject obstacle1 = obstaclePool.Dequeue();
            obstacle1.SetActive(true);
            return obstacle1;
        }
        return null;
    }
    public void ReturnObstacleToPool(GameObject obstacle)  // i�i biten engeli tekrar kuyru�a sokma ve g�r�n�rl���n� kapatma
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
    IEnumerator DisableObstacleAfterDelay(GameObject obstacle,float delay)  //olu�turulan engeli deactive etmek i�in s�reli IEnumerator
    {
        yield return new WaitForSeconds(delay);
        ReturnObstacleToPool(obstacle);
    }
  /*  IEnumerator ActiveObstacleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Shooting();
    } */
    void Shooting()  // engel olu�turma ve belirlenen h�zla endpoint noktas�na yollayan metod
    {
        Vector3 endPos = endPointTransform.position;
        Vector3 PosWorld=Camera.main.ScreenToWorldPoint(endPos);
        Vector3 direction=(PosWorld-spawnPointTransform.position).normalized;
        //Vector3 pos = new Vector3(-1, 0, 0);
        GameObject obstacle = GetObstacleFromPool(); //kuyruktan obejyi al�p obstacle a at�yor.
        if (obstacle!=null)
        {
            obstacle.transform.position = spawnPointTransform.position; // engelin pozisyonunu spawnpoint pozisyonu olarak g�ncelliyor.
            obstacle.SetActive(true); // engeli g�r�n�r yap�yor.

            Rigidbody2D obstacleRGB= obstacle.GetComponent<Rigidbody2D>(); // engelin rigidbodysini tan�mlama
            obstacleRGB.velocity = direction * obstacleSpeed;  // engele h�z verme
            StartCoroutine(DisableObstacleAfterDelay(obstacle, 8f));  // verilen s�re sonunda engeli yok etme
        }
    }
    /*private void Update()
    {
        StartCoroutine(ActiveObstacleAfterDelay(5f));
        //Shooting();
        
        
    } */
    IEnumerator SpawnObstacle()  // s�reli engel olu�turma coroutine si
    {
        
        while (GameManager.gameOver == false && GameManager.gamePassed == false)  // oyun bitmedi�i s�rece engel olu�tur
        {            
            yield return new WaitForSeconds(obstacleSpawnInterval);
            if (GameManager.gameStarted == true)
                Shooting();            
        }        
    }


}