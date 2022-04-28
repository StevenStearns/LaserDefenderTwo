using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float fltMoveSpeed = 5f;
    [SerializeField] float fltTimeBetweenEnemySpawn = 1f;
    [SerializeField] float fltSpawnTimeVariance = 0f;
    [SerializeField] float fltMinimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int intIndex)
    {
        return enemyPrefabs[intIndex];
    }
    
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    } // Get Waypoints

    public float GetMoveSpeed()
    {
        return fltMoveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float fltSpawnTime = Random.Range(fltTimeBetweenEnemySpawn - fltSpawnTimeVariance,
                                          fltTimeBetweenEnemySpawn + fltSpawnTimeVariance);
        return Mathf.Clamp(fltSpawnTime, fltMinimumSpawnTime, float.MaxValue);
    }
}
