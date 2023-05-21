using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTrampa2 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public float timer, maxTimer;
    public _Vida _vida;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _vida = GameObject.FindWithTag("Player").GetComponent<_Vida>();
    }

    void Update()
    {
        Move();
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    void Move()
    {
        rb2d.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            _vida._Life -= 1;
        }

    }
}
