using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class E2Movimiento : MonoBehaviour
{
    public Transform target;
    public float radius;
    public float speed;
    public Vector2 direccion;
    public Transform enemyTransform;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = rb.GetComponent<Transform>();
        target = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Vector2.Distance(transform.position, target.position) <= radius)
        { 
            direccion = enemyTransform.position - target.position;
            rb.velocity = direccion.normalized * speed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
