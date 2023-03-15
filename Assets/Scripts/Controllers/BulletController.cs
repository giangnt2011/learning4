using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MovementController
{
    int count = 0;
    public float damage;
    // Update is called once per frame
    void Update()
    {
        if (count == 100)
        {
            Destroy(gameObject);
            Creator.Instance.CreateExplosion(transform.position);
            return;
        }
        //transform.position += transform.up * 5f * Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, 0.2f);
        if(hit.transform != null )
        {
            IHit ihit = hit.transform.GetComponent<IHit>();
            if(ihit != null )
            {
                Creator.Instance.CreateExplosion(transform.position);
                ihit.OnHit(damage);
                Destroy(gameObject);
            }
        }
        count++;
        Move(transform.up);
    }

}
