using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Coin : MonoBehaviour
{
    public CoinsText coinsText;

    [Header("Time Variables")]
    [SerializeField] private float timer;
    [SerializeField] private float maxTimer;

    [Header("Points Variables")]
    [SerializeField] private int _pointAdd;
    [SerializeField] private int _points;

    private void Awake()
    {
        coinsText = GameObject.Find("CoinTMP").GetComponent<CoinsText>();
        coinsText.ChangeCoinText(_points);
    }
    void Update()
    {
        PointReduction();
        coinsText.ChangeCoinText(_points);
    }
    private void PointReduction()
    {
        timer += Time.deltaTime;

        if(timer >= maxTimer)
        {
            _pointAdd--;
            timer = 0;
        }
        if(_pointAdd <= 1)
        {
            _pointAdd = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Coin"))
            {
                _points += _pointAdd;
                Destroy(collision.gameObject);
                coinsText.ChangeCoinText(_points);
            }

        }
    }
}
