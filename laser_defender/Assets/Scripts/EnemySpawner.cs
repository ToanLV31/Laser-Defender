using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigsOS> listWave;
    WaveConfigsOS currentWave;

    [SerializeField] float timeBetweenWave = 0.4f;

    [SerializeField] bool isLooping = true;


    // Start is called before the first frame update
    void Start()
    {
        // In this we put the method into StartCoroutine;
        StartCoroutine(SpawnEnemyWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public WaveConfigsOS GetCurrentWave()
    {
        return currentWave;
    }


    // IEnumerator and yield are combo to call back method after a time; 
    IEnumerator SpawnEnemyWaves()
    {
        while (isLooping)
        {
            foreach (WaveConfigsOS item in listWave)
            {
                currentWave = item;
                for (int i = 0; i < currentWave.GetAmountEnemies(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0, 0, 180));
                    yield return new WaitForSeconds(currentWave.GetTimeSpawnEnemy());
                }
                yield return new WaitForSeconds(timeBetweenWave);
            }
        }


    }
}
