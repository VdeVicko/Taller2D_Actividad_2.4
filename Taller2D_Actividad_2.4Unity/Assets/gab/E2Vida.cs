using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Vida : MonoBehaviour
{
    public _Coin _coin;
    public GameObject Enemy;
    public int HP = 2;

    void Awake()
    {
        _coin = GameObject.FindWithTag("Player").GetComponent<_Coin>();
    }

    
    void Life(int value)
    {
        HP += value;

        if (HP <= 0)
        {
            _coin.count++;
            _coin._points+=10;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Life(-1);
        }
    }
}
