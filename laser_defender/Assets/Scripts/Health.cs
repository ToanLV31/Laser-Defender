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


    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;



    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

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
            // Debug.Log("Blood:" + health);
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
            damageDealer.Hit();

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
        // ui.SetHeathSlide((float)currentHealth / 10);
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
            Debug.Log("Điểm số hiện tại" + scoreKeeper.GetCurrentScore());
        }
        else
        {
            scoreKeeper.ResetScore();
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
