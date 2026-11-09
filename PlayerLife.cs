using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int MaxHealth= 100;
    private int daño;

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Vida life;
    

    private void Start()
    {
        // Buscar automáticamente el script Puntuaje en la escena
       life = FindObjectOfType<Vida>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Enemigo"))
        {
            daño +=1;
            if (life != null)
            {
                life.TakeDamage(cantidadPuntos);
            }
            else
            {
                Debug.LogWarning("No se encontró el componente Puntuaje en la escena.");
            }
            if (daño >= MaxHealth)
            {
            SceneManager.LoadScene("GameEnd");
            }
        }    
    }
}
