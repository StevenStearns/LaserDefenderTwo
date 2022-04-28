using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();   
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    void SpawnEnemies()
    {
        for (int intI = 0; intI < currentWave.GetEnemyCount(); intI++)
        {
            Instantiate(currentWave.GetEnemyPrefab(intI),
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);

        }
    }
}
