using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Vida : MonoBehaviour
{
    public VidaText vidaText;

    [Header("Time Variables")]
    [SerializeField] private float timer;
    [SerializeField] private float maxTimer;

    [Header("Life Variables")]
    [SerializeField] private int _lifeAdd;
    [SerializeField] public int _Life;
    [SerializeField] private int _maxLife;


    private void Awake()
    {
        _Life = 5;
        _maxLife = 5;
        vidaText = GameObject.Find("VidaTMP").GetComponent<VidaText>();
        vidaText.ChangeVidaText(_Life);
    }

    void Update()
    {
        LifeReduction();
        vida();
    }

    private void vida()
    {
        if (_Life >= _maxLife)
        {
            _Life = _maxLife;

        }
            vidaText.ChangeVidaText(_Life);
        if (_Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void LifeReduction()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            _lifeAdd--;
            timer = 0;
        }
        if (_lifeAdd <= 1)
        {
            _lifeAdd = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Chip"))
            {
                _Life += _lifeAdd;
                Destroy(collision.gameObject);
                vidaText.ChangeVidaText(_Life);

            }
        }
    }
}
