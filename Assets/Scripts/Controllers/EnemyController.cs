using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    Vector2 mousePoint;
    Vector3 mousePointWorld;
    [SerializeField] private Transform player;
    int count = 0;

    protected override void Awake()
    {
        base.Awake();
        expController.SetLevel(1);
        

    }
    public override void TankDestroy()
    {
        Destroy(gameObject);
        Creator.Instance.CreateExplosion(transform.position);
        Observer.Instance.Notify(GameKey.ENEMY_DIE, this);
    }

    private void Update()
    {

        //Vector2.MoveTowards(transform.position, player.position, 1f);

        //RotateGun(player.position);
        //if (player && count > 400)
        //{
        //    count = 0;
        //    Shoot();

        //}
        //count++;


    }
}
