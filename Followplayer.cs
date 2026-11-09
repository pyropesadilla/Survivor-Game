using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;       // Transform del objeto con el tag "Player"
    public float minSpeed = 1f;      // Velocidad mínima
    public float maxSpeed = 3f;      // Velocidad máxima
    private float moveSpeed;  
    public float stopDistance = 1f; // Distancia mínima para detenerse

    void Start()
    {
        // Buscar al objeto con el tag "Player"
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calcular la distancia al jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Solo moverse si está más lejos que la distancia mínima
        if (distance > stopDistance)
        {
            // Dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Movimiento
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Rotar suavemente hacia el jugador
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
        }
    }
}