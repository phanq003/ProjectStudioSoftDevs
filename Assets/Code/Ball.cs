using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LogicScript logic;
    private float forceMulitplyer = 5f;
    private Rigidbody2D rb;
    private Vector2 startMousePos;
    private Vector2 endMousePos;
    private bool isDragging = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Console.Out.WriteLine("Mouse button pressed");
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Console.Out.WriteLine(startMousePos);
            isDragging = true;
        }

        if(Input.GetMouseButtonDown(0) && isDragging)
        {
            endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 direction = startMousePos - endMousePos;
            rb.AddForce(-direction*forceMulitplyer, ForceMode2D.Impulse);
            isDragging=false;
            logic.addStroke();
        }
    }

}