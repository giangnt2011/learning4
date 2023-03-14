using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : ProcessingController
{
    public delegate void Die();
    public Die die;

    public void TakeDamage(float damage)
    {
        ChangeValue(currentValue-damage);

        if (die != null && currentValue == 0) { die(); }
    }

    public void SetHP(float maxHP)
    {
        SetValue(maxHP);
    }
}
