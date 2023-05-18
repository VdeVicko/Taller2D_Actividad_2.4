using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    Vector2 move;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        move = new Vector2(horizontal, vertical).normalized;

    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + move * speed * Time.fixedDeltaTime);
    }
}