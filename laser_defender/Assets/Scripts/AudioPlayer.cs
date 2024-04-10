using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shotting")]
    [SerializeField] AudioClip shot;
    [SerializeField][Range(0f, 1f)] float volumeShot = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damage;
    [SerializeField][Range(0f, 1f)] float volumeDamage = 1f;


    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    void Start()
    {
    }



    public void PlayShot()
    {
        PlayClip(shot, volumeShot);
    }

    public void PlayDamage()
    {
        PlayClip(damage, volumeDamage);
    }

    private void PlayClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
    }



}
