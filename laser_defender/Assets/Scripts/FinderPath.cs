using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class FinderPath : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigsOS waveConfigs;

    List<Transform> pathWay;

    int currentIndex = 0;
    // Start is called before the first frame update

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waveConfigs = enemySpawner.GetCurrentWave();
        pathWay = waveConfigs.GetListPath();
        transform.position = pathWay[currentIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (currentIndex < pathWay.Count)
        {
            UnityEngine.Vector3 targetPosition = pathWay[currentIndex].position;
            float delta = waveConfigs.GetMoveSpeed() * Time.deltaTime;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                currentIndex++;
            }
        }
        else
        {
            currentIndex = 0;

            Destroy(gameObject);
        }
    }


}
