using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    public Transform target;     // El objeto a seguir (por ejemplo, el jugador)
    public float smoothSpeed = 0.125f; // Suavidad del movimiento
    public Vector3 offset;       // Desplazamiento opcional respecto al objetivo

    void LateUpdate()
    {
        if (target == null) return;

        // Posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;
        
        // Movimiento suave hacia el objetivo
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;

        // Si quieres que la cámara mire siempre al objetivo:
        // transform.LookAt(target);
    }
}
