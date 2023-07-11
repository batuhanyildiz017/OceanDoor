using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    //public GameObject objectPool;
    //public ObjectPool op1;
    
    float damage; //engelin verdi�i hasar
    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
        //objectPool= GetComponent<GameObject>();
        //op1 = obstacle.AddComponent<ObjectPool>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().health -= damage; //oyuncunun can� damage ile azal�r
            Debug.Log("Kalan can: "+collision.GetComponent<PlayerMovement>().health);
            //op1.ReturnObstacleToPool(gameObject);
            gameObject.SetActive(false); //engelin g�r�n�rl���n� kapatt�m
                                         //s�resi gelince de objectpooldan kuyru�a tekrar giricek elle yapmaya �al��t���mda hata veriyor :D
        }
        if (collision.CompareTag("Obstacle"))  // engel ba�a bir engelle �arp���yorsa engeli g�r�nmez yap
        {
            gameObject.SetActive(false);

        }
    }
    public void In�t(Vector3 position)
    {
        obstacle.transform.position = position;
    }
}
