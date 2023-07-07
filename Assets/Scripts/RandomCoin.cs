using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject Player;
    List<GameObject> coinPool;  // coin listesi
    public GameObject coinPrefab; // Olu�turulacak obje prefab�
    public int numberOfObjects = 100; // Olu�turulacak obje say�s�

    private Vector2 minPoint; // Minimum nokta (sol alt k��e)
    private Vector2 maxPoint; // Maksimum nokta (sa� �st k��e)
    float minX = -150;
    float maxX = 150;
    float minY = -150;
    float maxY = 150;

    private void Start()
    {
        coinPool = new List<GameObject>();
        minPoint = new Vector2(-150, -150);
        maxPoint = new Vector2(150, 150);

        SpawnObjects();

    }
    private void Update()
    {
        SetActiveTrue();
    }
    void SetActiveFalse()
    {
        foreach (var item in coinPool)
        {
            item.SetActive(false);
        }
    }
    void SetActiveTrue()
    {
        bool test1 = false;
        float randomX;
        float randomY;
        if (Player.transform.position.x >= maxX && Player.transform.position.y >= maxY)
        {
            test1 = true;
            minX = maxX;
            maxX += 300;
            minY = maxY;
            maxY += 300;
        }
        else if (Player.transform.position.x >= maxX && Player.transform.position.y <= maxY)
        {
            test1 = true;
            minX = maxX;
            maxX += 300;
        }
        else if (Player.transform.position.x <= maxX && Player.transform.position.y >= maxY)
        {
            test1 = true;
            minY = maxY;
            maxY += 300;
        }
        else if (Player.transform.position.x <= minX && Player.transform.position.y <= minY)
        {
            test1 = true;
            maxX = minX;
            minX -= 300;
            maxY = minY;
            minY -= 300;
        }
        else if (Player.transform.position.x <= minX && Player.transform.position.y >= minY)
        {
            test1 = true;
            maxX = minX;
            minX -= 300;

        }
        else if (Player.transform.position.x >= minX && Player.transform.position.y <= minY)
        {
            test1 = true;
            maxY = minY;
            minY -= 300;
        }
        if (test1 == true)
            foreach (var item in coinPool)
            {
                randomX = Random.Range(minX, maxX);
                randomY = Random.Range(minY, maxY);
                item.transform.position = new Vector2(randomX, randomY);
                item.SetActive(true);

            }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = Random.Range(minPoint.x, maxPoint.x);
            float randomY = Random.Range(minPoint.y, maxPoint.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);  //random konum olu�tur
            GameObject coin = Instantiate(coinPrefab, randomPosition, Quaternion.identity); //random konumda coin olu�tur
            coinPool.Add(coin);  //coini liste sok
        }
    }
}
