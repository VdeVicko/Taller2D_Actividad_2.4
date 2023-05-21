using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    private bool CanShoot => Input.GetKeyDown(KeyCode.J);
    public Transform FirePoint;
    public float BulletSpeed;

    private void Awake()
    {
        FirePoint = GameObject.Find("FirePoint").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(CanShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet =Instantiate(Bullet,FirePoint.position, Quaternion.identity);
        Rigidbody2D rigidb = bullet.GetComponent<Rigidbody2D>();
        rigidb.AddForce(FirePoint.up * BulletSpeed * 10f, ForceMode2D.Force);
    }
}
