
using UnityEngine;

public class PlayerController : TankController
{
    float v;
    float h;
    Vector2 mousePoint;
    Vector3 mousePointWorld;

    protected override void Awake()
    {
        base.Awake();
        expController.SetLevel(1);
        Observer.Instance.AddObserver(GameKey.ENEMY_DIE, OnEnemyDie);

    }
    public override void TankDestroy()
    {
        Debug.Log("You lose");
    }

    private void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(h,v);
        Move(direction);

        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePointWorld = new Vector3(mousePoint.x, mousePoint.y) - gun.position;
        RotateGun(mousePointWorld);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void OnEnemyDie(object data)
    {
        EnemyController enemy= (EnemyController)data;
        expController.CollectEXP(enemy.Level*20);
    }
}

public class Player: SingletonMonobehaviour<PlayerController>
{

}
