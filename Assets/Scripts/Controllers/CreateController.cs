using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{

    [SerializeField] private BulletController bulletPrefabs;
    [SerializeField] private GameObject explosionPrefabs;


    public BulletController CreateBullet(Transform tranShoot)
    {
        return Instantiate(bulletPrefabs, tranShoot.position, tranShoot.rotation);
    }

    public void CreateExplosion(Vector3 pos)
    {
        Instantiate(explosionPrefabs, pos, explosionPrefabs.transform.rotation);
    }


}
public class Creator : SingletonMonobehaviour<CreateController>
{

}
