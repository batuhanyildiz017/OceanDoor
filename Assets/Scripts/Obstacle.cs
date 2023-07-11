using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    //public GameObject objectPool;
    //public ObjectPool op1;
    
    float damage; //engelin verdiði hasar
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
            collision.GetComponent<PlayerMovement>().health -= damage; //oyuncunun caný damage ile azalýr
            Debug.Log("Kalan can: "+collision.GetComponent<PlayerMovement>().health);
            //op1.ReturnObstacleToPool(gameObject);
            gameObject.SetActive(false); //engelin görünürlüðünü kapattým
                                         //süresi gelince de objectpooldan kuyruða tekrar giricek elle yapmaya çalýþtýðýmda hata veriyor :D
        }
        if (collision.CompareTag("Obstacle"))  // engel baþa bir engelle çarpýþýyorsa engeli görünmez yap
        {
            gameObject.SetActive(false);

        }
    }
    public void Inýt(Vector3 position)
    {
        obstacle.transform.position = position;
    }
}
