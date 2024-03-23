using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float speedPlayer = 6f;
    [SerializeField] float paddingLeft = 0f;
    [SerializeField] float paddingRight = 0f;
    [SerializeField] float paddingTop = 0f;
    [SerializeField] float paddingBottom = 0f;


    Vector2 miniBound;
    Vector2 maxiBound;

    Shooter shooter;

    AudioPlayer audioPlayer;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        initBound();
    }



    void Update()
    {
        PlayerMove();
    }

    void initBound()
    {
        Camera camera = Camera.main;
        miniBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxiBound = camera.ViewportToWorldPoint(new Vector2(1, 1));

    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    void PlayerMove()
    {
        Vector2 delta = rawInput * speedPlayer * Time.deltaTime;
        Vector2 trans;
        trans.x = Mathf.Clamp(transform.position.x + delta.x, miniBound.x + paddingLeft, maxiBound.x - paddingRight);
        trans.y = Mathf.Clamp(transform.position.y + delta.y, miniBound.y + paddingBottom, maxiBound.y - paddingTop);
        transform.position = trans;
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
        if (audioPlayer != null)
        {
            audioPlayer.PlayShot();
        }
    }


}
