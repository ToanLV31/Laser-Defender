using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;

    [SerializeField] float timeBetweenTwoBullet = 0.1f;

    public bool isFiring;

    Coroutine fireCoroutine;
    // Start is called before the first frame update
    void Start()
    {

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
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponentInChildren<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0f, projectileSpeed);
            }

            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(timeBetweenTwoBullet);
        }
    }
}
