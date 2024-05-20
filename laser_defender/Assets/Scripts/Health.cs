using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;


    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem explosionEffect;


    [SerializeField] bool applyShakeCamera;

    [SerializeField] bool isEnemy;
    [SerializeField] bool isPlayer;


    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    ScreenController screenController;



    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        screenController = FindObjectOfType<ScreenController>();

    }


    void Start()
    {


    }

    void Update()
    {

    }







    public int GetHealth()
    {
        return this.health;
    }

    public bool GetIsEnemy()
    {
        return this.isEnemy;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());

            PlayHitEffect();
            if (audioPlayer)
            {
                audioPlayer.PlayDamage();
            }
            if (applyShakeCamera)
            {
                ShakeCamera();
            }

            if(!isEnemy && !isPlayer){
                 damageDealer.Hit();
            }
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake());
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isEnemy)
        {
            scoreKeeper.IncreaseCurrentScore(score);
        }
        
        if(isPlayer)
        {
            screenController.LoadGameOverScene();
            Debug.Log("Điểm số sau khi reset" + scoreKeeper.GetCurrentScore());
        }


        Destroy(gameObject);
    }

    void PlayHitEffect()
    {

        if (explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }


    }
}
