using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosion = Player.Instance.transform.position;
        transform.position = playerPosion + Vector3.back *10;
    }
}
