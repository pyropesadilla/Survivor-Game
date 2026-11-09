using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuajeVida : MonoBehaviour
{
    private float puntosVida;
    private TextMeshProUGUI textMesh;
    void Start()
    {
       textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text=puntosVida.ToString("0");
    }
    public void RestarPuntosVida(float puntosEntrada)
    {
        puntosVida= puntosEntrada;
        //Debug.Log("take damage"+ puntosEntrada);
    }
}
