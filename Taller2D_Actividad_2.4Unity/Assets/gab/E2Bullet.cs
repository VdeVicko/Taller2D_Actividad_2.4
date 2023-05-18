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
    float x;
    float y;
    public float sizeTimer;
    public float sizeMaxTimer;

    public _Vida playerVida;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerVida = GetComponent<_Vida>();
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
            x = x * 1.05f;
            y = y * 1.05f;
            e2Bullet.transform.localScale = new Vector3 (x,y,1);
        }
    }

}


