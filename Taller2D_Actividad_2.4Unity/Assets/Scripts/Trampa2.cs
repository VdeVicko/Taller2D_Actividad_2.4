using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa2 : MonoBehaviour
{
    public float timer, maxTimer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot = false;
    void Start()
    {
        firePoint = transform.GetChild(0).transform;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer && canShoot)
        {
            Shoot();
            
        }
        if(maxTimer <= 0)
        {
            maxTimer = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canShoot = true;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canShoot = false;

        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        timer = 0;
        maxTimer -= 1;
    }
}
