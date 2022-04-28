using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int intWaypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[intWaypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(intWaypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[intWaypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                intWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
