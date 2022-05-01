using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float fltTimeBetweenWaves = 0f;
    [SerializeField] WaveConfigSO currentWave;
    [SerializeField] bool blIsLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());   
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int intI = 0; intI < currentWave.GetEnemyCount(); intI++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(intI),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(fltTimeBetweenWaves);
            } // Foreach wave
        }
        while (blIsLooping);
        
    }
}
