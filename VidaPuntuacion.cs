using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaPuntuacion : MonoBehaviour
{
    private float puntosVida;
    private TextMeshProUGUI textMesh;
    void Start()
    {
       textMesh = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        textMesh.text=puntosVida.ToString("10");
    }
    public void RestarVida(float vidamenos)
    {
        puntosVida+= vidamenos;
        Debug.Log("-1");
    }
}
