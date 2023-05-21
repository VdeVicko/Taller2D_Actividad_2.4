using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class E2Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private GameObject e2Bullet;
    
    public Vector2 direccion;
    public float timer;
    public float maxTimer;

    public Transform bulletTransform;
    float x = 1;
    float y = 1;
    public float sizeTimer;
    public float sizeMaxTimer;

    public _Vida playerVida;
    public _Coin _coin;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerVida = GameObject.FindWithTag("Player").GetComponent<_Vida>();
        _coin = GameObject.FindWithTag("Player").GetComponent<_Coin>();
        //bullet no crece
    }

    void Update()
    {
        Move();
        Timer();
    }

    void Move()
    { 
        rb.velocity = direccion * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerVida._Life -= 1;
            _coin._points -= 5;
        }
    }

    void Timer()
    { 
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            ChangeSize();
            Destroy(gameObject);
        }
    }

    void ChangeSize()
    {
        sizeTimer += Time.deltaTime;

        if (sizeTimer >= sizeMaxTimer)
        {
            x = x * 3.5f;
            y = y * 3.5f;
            e2Bullet.transform.localScale = new Vector3 (x,y,1);
        }
    }

}


