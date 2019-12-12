using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public float scrollSpeed;
    public float maxFOV;
    public float minFOV;
    public Vector2 maxOffsetCam;
    public float hp;
    public int cash;
    
    public TextMeshProUGUI roundUI;
    public TextMeshProUGUI cashUI;
    public Slider healthbarUI;
    
    private Camera cam;

    public void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        if (hp <= 0)
        {
            GameManager.instance.PlayerDead();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed, minFOV, maxFOV);
        
        Vector3 playerInput = new Vector3(-Input.GetAxisRaw("Horizontal"), 0,-Input.GetAxisRaw("Vertical"));
        Vector3 moveDir = Time.deltaTime * speed * playerInput.normalized;
        float x = Mathf.Clamp(transform.position.x + moveDir.x, -maxOffsetCam.x, maxOffsetCam.x);
        float z = Mathf.Clamp(transform.position.z + moveDir.z, -maxOffsetCam.y, maxOffsetCam.y);
        transform.position = new Vector3(x, 0,z);
    }
}
