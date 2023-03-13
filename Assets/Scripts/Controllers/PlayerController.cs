
using UnityEngine;

public class PlayerController : TankController
{
    float v;
    float h;
    Vector2 mousePoint;
    Vector3 mousePointWorld;

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
}

public class Player: SingletonMonobehaviour<PlayerController>
{

}
