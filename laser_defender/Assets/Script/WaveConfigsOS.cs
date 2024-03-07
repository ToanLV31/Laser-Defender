using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveConfigs", menuName = "WaveConfigs", order = 1)]
public class WaveConfigsOS : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnsTimeVariance = 0f;

    [SerializeField] float minimumSpawnTime = 0.24f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetListPath()
    {
        List<Transform> listWayPoints = new List<Transform>();
        foreach (Transform item in pathPrefab)
        {
            listWayPoints.Add(item);
        }
        return listWayPoints;
    }

    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }

    public int GetAmountEnemies()
    {
        return this.enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetTimeSpawnEnemy()
    {
        // create a time to spawn a enemy between two value;
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnsTimeVariance,
                                       timeBetweenEnemySpawns + spawnsTimeVariance); //

        return UnityEngine.Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

}
