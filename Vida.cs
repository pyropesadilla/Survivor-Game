
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easehealthSlider;
    public float maxHealth=100f;
    public float health;
    private float lerpSpeed=0.05f;

    [SerializeField] private PuntuajeVida vidapuntaje;
    void Start()
    {
        vidapuntaje = FindObjectOfType<PuntuajeVida>();
    
        health=maxHealth;
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            // Intentar obtener el componente PlayerTriggerRelay
            PlayerTriggerRelay relay = player.GetComponent<PlayerTriggerRelay>();

            if (relay != null)
            {
                // Asignarse como destino del evento
                relay.vidaScript = this;
            }
            else
            {
                //Debug.LogWarning("El objeto 'Player' no tiene el script PlayerTriggerRelay.");
            }
        }
        else
        {
            //Debug.LogWarning("No se encontró el objeto 'Player' en la jerarquía.");
        }
    }
    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value= health;
        }
        if (healthSlider.value != easehealthSlider.value)
        {
            easehealthSlider.value=Mathf.Lerp(easehealthSlider.value,health,lerpSpeed);
        }
        vidapuntaje.RestarPuntosVida(health);
    }

    public void OnPlayerTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            TakeDamage(10);
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
    
        Debug.Log($"Vida actual: {health}");
    }
}
