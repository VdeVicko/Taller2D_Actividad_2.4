using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float velX;
    public float velY;
    public float moveSpeed;
    public GameObject Bullet;
    public float BulletSpeed;
    private Transform FirePoint;
    private Vector2 mousePosition;
    Camera cam;

    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        FirePoint = GameObject.Find("FirePoint").transform;
        cam = FindObjectOfType<Camera>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
       
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Move()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePosition - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;

        velX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        velY = Input.GetAxisRaw("Vertical") * moveSpeed;
        _rb.velocity = new Vector2(velX, velY);

    }
    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
        Rigidbody2D rigidb = bullet.GetComponent<Rigidbody2D>();
        rigidb.AddForce(FirePoint.up * BulletSpeed * 10f, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CamTrigger"))
        {
            CameraManager.GetInstance().SwitchToCamera2();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CamTrigger"))
        {
            CameraManager.GetInstance().SwitchToCamera1();
        }
    }
}
