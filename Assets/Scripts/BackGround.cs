using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private MeshRenderer mRenderer;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        material = mRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x;
        offset.y = transform.position.y / transform.localScale.y;


        material.mainTextureOffset = offset;
    }
}
