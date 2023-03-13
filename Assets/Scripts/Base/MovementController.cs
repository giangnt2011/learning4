using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    protected virtual void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
