using UnityEngine;

public class PlayerTriggerRelay : MonoBehaviour
{
    // Referencia al script Vida que recibirá la notificación
    public Vida vidaScript;

    private void OnTriggerEnter(Collider other)
    {
        if (vidaScript != null)
        {
            vidaScript.OnPlayerTriggerEnter(other);
        }
    }
}