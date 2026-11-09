using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntuaje puntaje;

     private void Start()
    {
        // Buscar automáticamente el script Puntuaje en la escena
        puntaje = FindObjectOfType<Puntuaje>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Ataque"))
        {
            // Desactiva este mismo objeto

            gameObject.SetActive(false);
            if (puntaje != null)
                puntaje.SumarPuntos(cantidadPuntos);
            else
                Debug.LogWarning("No se encontró el componente Puntuaje en la escena.");
            Debug.Log("El objeto se ha desactivado al entrar el Player en el trigger.");
        }
    }
}
