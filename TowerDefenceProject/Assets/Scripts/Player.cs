using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp;

    public void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Horizontal"));
        playerInput.Normalize();
        Vector3 moveDir = Mathf.Clamp(transform.position + new Vector3());
        transform.position += new Vector3(inpu);
    }
}
