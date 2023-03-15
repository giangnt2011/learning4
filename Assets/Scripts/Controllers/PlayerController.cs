
using UnityEngine;

public class PlayerController : TankController
{
    public static PlayerController Instance;
    float v;
    float h;
    Vector2 mousePoint;
    Vector3 mousePointWorld;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
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
        expController.CollectEXP(enemy.Level*10);
    }
}

public class Player: SingletonMonobehaviour<PlayerController>
{

}
