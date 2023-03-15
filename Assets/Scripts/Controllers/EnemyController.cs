using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform enemies;
    int count = 0;
    public int levelEnemy;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        expController.SetLevel(levelEnemy);
    }

    public override void TankDestroy()
    {
        Destroy(gameObject);
        Creator.Instance.CreateExplosion(transform.position);
        Observer.Instance.Notify(GameKey.ENEMY_DIE, this);
        if(enemies.childCount == 1)
        {
            Observer.Instance.Notify(GameKey.ALL_ENEMY_DIED, expController.Level);
        }
    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.position, 0.3f * Time.deltaTime);

        RotateGun(player.position);
        if (player && count > 400)
        {
            count = 0;
            Shoot();

        }
        count++;
    }
}
