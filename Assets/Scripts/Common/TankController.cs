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
    [SerializeField] protected ExpController expController;
    [SerializeField] TankInfo[] tankInfos;
    TankInfo tankInfo;
    public int Level
    {
        get { return expController.Level; }
    }
    protected virtual void Awake()
    {
        hpController.die = TankDestroy;
        expController.upLevel = OnUpLevel;
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
        BulletController bullet = Creator.Instance.CreateBullet(tranShoot);
        bullet.damage = tankInfo.damage;
    }

    public void OnHit(float damage)
    {
        hpController.TakeDamage(damage);
    }
    void OnUpLevel(int level)
    {
        if(level > tankInfos.Length){ return; }
        tankInfo = tankInfos[level-1];
        hpController.SetHP(tankInfo.HP);
        speed = tankInfo.Speed;
    }
}
