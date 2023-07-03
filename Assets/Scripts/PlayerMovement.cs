using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool leftclickControl;
    private bool rightclickControl;
    [SerializeField]private float leftRotationAngle;
    [SerializeField] private float rightRotationAngle;
    
    
    Rigidbody2D rb;
    public GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = GetComponent<GameObject>();
        leftRotationAngle = +1f;
        rightRotationAngle = -1f;
        
    }
    public void MakeTrueLeft()
    {
        leftclickControl = true;
    }
    public void MakeFalseLeft()
    {
        leftclickControl=false;
    }
    public void MakeTrueRight()
    {
        rightclickControl = true;
    }
    public void MakeFalseRight()
    {
        rightclickControl = false;
    }


    // Update is called once per frame
    void Update()
    {
        //rb.velocity=new Vector2 (5f*250*Time.deltaTime,rb.velocity.y);
        transform.Translate(new Vector3(5f*Time.deltaTime, 0f, 0f));
        Left();
        Right();
    }
    void Left()
    {
        if (leftclickControl==true)
        {
            player.transform.Rotate(new Vector3(0f, 0f, leftRotationAngle));

        }
    }
    void Right()
    {
        if(rightclickControl==true)
        player.transform.Rotate(new Vector3(0f, 0f, rightRotationAngle));
    }

}
