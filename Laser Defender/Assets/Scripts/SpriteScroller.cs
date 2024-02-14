using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    Material _material;
    [SerializeField] float offsetValue;
    void Awake()
    {
       _material =  GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        _material.mainTextureOffset += Vector2.up*offsetValue*Time.deltaTime;
    }
}
