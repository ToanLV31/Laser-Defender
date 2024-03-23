using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] bool applyShakeCamera;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }


    void Start()
    {

    }



    public int GetHealth()
    {
        return this.GetHealth();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            Debug.Log("Blood:" + health);
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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
