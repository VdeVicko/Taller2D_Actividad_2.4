using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform target;
    public GameObject e2Bullet;
    public float timer;
    public float maxTimer;
    public float radius;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                Vector2 direccion = target.position - transform.position;

                GameObject obj = Instantiate(e2Bullet);
                obj.transform.position = transform.position;

                obj.GetComponent<E2Bullet>().direction = direccion.normalized;

                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
