using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(EndExplosion());
    }
    IEnumerator EndExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
