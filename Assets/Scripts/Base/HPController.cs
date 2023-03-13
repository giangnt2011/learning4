using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public float currentHP;
    public float maxHP;

    public delegate void Die();
    public Die die;

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        DisplayHP();
        if (currentHP < 0) currentHP = 0;
        if(die != null && currentHP == 0) { die(); }
       
    }

    public void DisplayHP()
    {
        transform.localScale = new Vector3(transform.localScale.x * ( 1 - currentHP/maxHP ), transform.localScale.y, 1);
    }

    public void SetHP(float currentHP)
    {
        this.currentHP = currentHP;
        this.maxHP = currentHP;
        DisplayHP();
    }
}
