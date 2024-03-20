using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScreen : MonoBehaviour
{
    [SerializeField] Vector2 speedMove;
    Vector2 offSet;
    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        offSet = speedMove * Time.deltaTime;
        material.mainTextureOffset += offSet;
    }
}
