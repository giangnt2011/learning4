using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MovementController
{
    int count = 0;
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

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, 1f);
        if(hit.transform != null )
        {
            Debug.Log(hit);
            IHit ihit = hit.transform.GetComponent<IHit>();
            if(ihit != null )
            {
                Creator.Instance.CreateExplosion(transform.position);
                ihit.OnHit();
                Destroy(gameObject);
            }
        }
        count++;
        Move(transform.up);
    }

}
