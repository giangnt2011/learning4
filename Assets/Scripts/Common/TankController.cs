using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class TankInfo
{
    public float HP;
    public float Speed;
    public float damage;
}

public abstract class TankController : MovementController, IHit
{
    [SerializeField] Transform body;
    [SerializeField] protected Transform gun;
    [SerializeField] Transform tranShoot;
    [SerializeField] HPController hpController;
    TankInfo tankInfo;

    private void Awake()
    {
        hpController.SetHP(tankInfo.HP);
        hpController.die = TankDestroy;
    }

    public abstract void TankDestroy();

    protected override void Move(Vector3 direction)
    {
        base.Move(direction);
        body.up = direction;
    }
    protected void RotateGun(Vector3 direction)
    {
        gun.up= direction;
    }
    protected void Shoot()
    {
        Creator.Instance.CreateBullet(tranShoot);
    }

    public void OnHit(float damage)
    {
        hpController.TakeDamage(damage);
    }
}
