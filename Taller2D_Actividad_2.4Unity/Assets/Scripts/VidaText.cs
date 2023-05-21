using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaText : MonoBehaviour
{
    public TMP_Text vidaText;
    void Awake()
    {
        vidaText = GameObject.Find("VidaTMP").GetComponent<TMP_Text>();
    }

    public void ChangeVidaText(int vidas)
    {
        vidaText.text = "Vida: " + vidas;
    }
}
