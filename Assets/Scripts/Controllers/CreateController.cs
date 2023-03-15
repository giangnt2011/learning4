using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{

    [SerializeField] private BulletController bulletPrefabs;
    [SerializeField] private GameObject explosionPrefabs;

    [SerializeField] private EnemyController enemyPrefabs;
    [SerializeField] private Transform enemies;
    [SerializeField] private Transform player;

    private void Update()
    {
        Debug.Log(enemies.childCount);
    }
    public BulletController CreateBullet(Transform tranShoot)
    {
        return Instantiate(bulletPrefabs, tranShoot.position, tranShoot.rotation);
    }

    public EnemyController CreateEnemyPrefabs(Transform spawnPoint)
    {

        EnemyController enemy = Instantiate(enemyPrefabs, spawnPoint.position, spawnPoint.rotation);
        enemy.player = player;
        enemy.enemies = enemies;
        return enemy;
    }

    public void CreateExplosion(Vector3 pos)
    {
        Instantiate(explosionPrefabs, pos, explosionPrefabs.transform.rotation);
    }


}
public class Creator : SingletonMonobehaviour<CreateController>
{

}
