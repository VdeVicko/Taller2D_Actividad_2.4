using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa1 : MonoBehaviour
{
    GameObject limite;
    Rigidbody2D _rb;
    private bool topDown;
    public float x;

    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    void TopDown()
    {
        if(topDown)
        {
            _rb.velocity = new Vector2(0, 0);
        _rb.AddForce(new Vector2(0, -x)); 

        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(0, x));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Piso")
        {
            topDown = false;
            if(x <9000)
            {
            x *= 1.8f;

            }
            TopDown();
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limite")
        {
            topDown = true;
            if(x <9000)
            {
            x *= 1.08f;

            }
            TopDown();
        }
    }

}
