using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float timeBetweenTwoBullet = 0.5f;

    [SerializeField] bool useAI;
    public bool isFiring;
    Coroutine fireCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            Debug.Log("stop");
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            Debug.Log(transform.position);
            GameObject instance = Instantiate(projectilePrefab) as GameObject;
            instance.transform.position = transform.position;
            instance.transform.rotation = transform.rotation;

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifeTime);
            if (useAI)
            {
                timeBetweenTwoBullet = UnityEngine.Random.Range(0.5f, 1f);
            }
            yield return new WaitForSeconds(timeBetweenTwoBullet);
        }
    }
}
