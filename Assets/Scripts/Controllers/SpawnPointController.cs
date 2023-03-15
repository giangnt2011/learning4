using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    
    [SerializeField] private Transform enemiesTransform;

    private void Awake()
    {
        //Observer.Instance.AddObserver(GameKey.ALL_ENEMY_DIED, SpawnEnemies);
        Observer.Instance.AddObserver(GameKey.ENEMY_DIE, OnEnemyDie);
    }

    private void Start()
    {
        SpawnEnemiesFistTime();
    }
    void SpawnEnemiesFistTime()
    {
        foreach (Transform point in spawnPoints)
        {
            EnemyController enemy = Creator.Instance.CreateEnemyPrefabs(point);
            enemy.levelEnemy = 1;
            enemy.transform.SetParent(enemiesTransform, true);
        }
    }
    void SpawnEnemies(object data)
    {
        int oldLevel = (int)data;
        foreach (Transform point in spawnPoints)
        {
            EnemyController enemy = Creator.Instance.CreateEnemyPrefabs(point);
            enemy.transform.SetParent(enemiesTransform, true);
            enemy.levelEnemy = oldLevel + 1;
            Debug.Log("SpawnPointController: "+enemy.levelEnemy);
        }
    }
     void OnEnemyDie(object data)
    {

    }
}
