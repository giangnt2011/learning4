using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    Vector2 mousePoint;
    Vector3 mousePointWorld;
    [SerializeField] private Transform player;
    int count = 0;

    public override void TankDestroy()
    {
        Destroy(gameObject);
        Creator.Instance.CreateExplosion(transform.position);
    }

    private void Update()
    {

        Vector2.MoveTowards(transform.position, player.position, 1f);

        RotateGun(player.position);
        if (player && count > 400)
        {
            Debug.Log(count);
            count = 0;
            Shoot();

        }
        count++;


    }
}
