using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemigosDerrotadosText : MonoBehaviour
{
    public TMP_Text enemigosText;
    void Awake()
    {
        enemigosText = GameObject.Find("EnemigosDerrotadosTMP").GetComponent<TMP_Text>();
    }

    public void ChangeEnemigosText(int enemies)
    {
        enemigosText.text = "Enemigos Derrotados: " + enemies;
    }
}
