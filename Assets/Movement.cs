using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A-D
        float v = Input.GetAxis("Vertical"); // W-S
        Vector3 moveDir = (transform.forward * v + transform.right * h);
        moveDir.y = 0;
        moveDir.Normalize();
        
        transform.position += moveDir * moveSpeed * Time.deltaTime;


        
    }
}