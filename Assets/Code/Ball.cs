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
    public GameObject golfBallIndicator;
    private float forceMulitplyer = 5f;
    private Rigidbody2D rb;
    private Vector2 startMousePos;
    private Vector2 endMousePos;
    private Vector2 shotStartLocation;
    private bool isDragging = false;
    private float offset = 1.3f;


    void Start()
    {
        golfBallIndicator.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (logic.getPlayerTurnExceeded() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                golfBallIndicator.SetActive(true);
                shotStartLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);            
                isDragging = true;
                float scaleVal = Vector2.SqrMagnitude(shotStartLocation - startMousePos);
                Vector3 testVect = (shotStartLocation - startMousePos).normalized * scaleVal / 30;
                Vector3 direction = (shotStartLocation - startMousePos);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                golfBallIndicator.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
                golfBallIndicator.transform.localScale = new Vector3(scaleVal / 40, scaleVal / 4, 1);
                golfBallIndicator.transform.position = gameObject.transform.position + testVect;
            }

            if (Input.GetMouseButtonDown(0) && isDragging)
            {
                endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                Vector2 direction = startMousePos - endMousePos;
                rb.AddForce(-direction * forceMulitplyer, ForceMode2D.Impulse);
                isDragging = false;
                logic.addStroke();
                golfBallIndicator.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water")){
            transform.position = new Vector3(-6.0f, -1.5f, 0f);
        }
    }
}